using Faptecsolution.CaritasCRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Faptecsolution.CaritasCRM.Persistence.Configurations
{
    public class LeadConfiguration : IEntityTypeConfiguration<Lead>
    {
        public void Configure(EntityTypeBuilder<Lead> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Topic)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Company)
                .HasMaxLength(100);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Phone)
                .HasMaxLength(20);

            builder.Property(x => x.JobTitle)
                .HasMaxLength(50);

            builder.Property(x => x.Department)
                .HasMaxLength(50);

            builder.Property(x => x.Description)
                .HasMaxLength(500);

            builder.Property(x => x.StatusReason)
                .HasMaxLength(200);

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.HasData(new Lead
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Topic = "Lead 1",
                FirstName = "John",
                LastName = "Doe",
                Phone = "1234567890",
                Email = "john.doe@abc.com",
                Company = "ABC Company",
                JobTitle = "Manager",
                Department = "Sales",
                Description = "Seeded lead record",
                StatusReason = "New",
                CreatedOn = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsDeleted = false
            });
        }
    }
}
