using Faptecsolution.CaritasCRM.Domain.Common;
using Faptecsolution.CaritasCRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Faptecsolution.CaritasCRM.Persistence.DatabaseContext
{
    public class CaritasCRMDbContext : DbContext
    {
        public CaritasCRMDbContext(DbContextOptions<CaritasCRMDbContext> options) : base(options)
        {
        }

        public DbSet<Lead> Leads { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<QuoteProduct> QuoteProducts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceProduct> InvoiceProducts { get; set; }
        public DbSet<InvoicePayment> InvoicePayments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CaritasCRMDbContext).Assembly);
            ApplySoftDeleteQueryFilters(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyAuditAndSoftDeleteRules();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            ApplyAuditAndSoftDeleteRules();
            return base.SaveChanges();
        }

        private void ApplyAuditAndSoftDeleteRules()
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedOn = DateTime.UtcNow;
                    entry.Entity.ModifiedOn = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.ModifiedOn = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                    entry.Entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }

        private static void ApplySoftDeleteQueryFilters(ModelBuilder modelBuilder)
        {
            var entityTypes = modelBuilder.Model.GetEntityTypes()
                .Where(t => typeof(BaseEntity).IsAssignableFrom(t.ClrType))
                .ToList();

            foreach (var entityType in entityTypes)
            {
                var parameter = Expression.Parameter(entityType.ClrType, "x");
                var propertyMethod = typeof(EF).GetMethod(nameof(EF.Property))!.MakeGenericMethod(typeof(bool));

                var isDeleted = Expression.Call(
                    propertyMethod,
                    parameter,
                    Expression.Constant(nameof(BaseEntity.IsDeleted)));

                var filter = Expression.Lambda(Expression.Equal(isDeleted, Expression.Constant(false)), parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);
            }
        }
    }
}
