using Faptecsolution.CaritasCRM.Domain.Common;
using Faptecsolution.CaritasCRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                entry.Entity.ModifiedOn = DateTime.UtcNow;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedOn = DateTime.UtcNow;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
