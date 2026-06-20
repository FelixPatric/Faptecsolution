using Faptecsolution.CaritasCRM.Domain.Common;

namespace Faptecsolution.CaritasCRM.Domain.Entities
{
    public class Account : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
        public int NumberOfEmployees { get; set; }
        public decimal AnnualRevenue { get; set; }
        public string BusinessType { get; set; } = string.Empty;
        public AccountRating Rating { get; set; } = AccountRating.Warm;
        public Address? Address { get; set; }

        // Relationships
        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
        public ICollection<Opportunity> Opportunities { get; set; } = new List<Opportunity>();
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
        public ICollection<Quote> Quotes { get; set; } = new List<Quote>();
    }

}
