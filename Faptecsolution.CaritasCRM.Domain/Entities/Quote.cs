using Faptecsolution.CaritasCRM.Domain.Common;

namespace Faptecsolution.CaritasCRM.Domain.Entities
{
    public class Quote : BaseEntity
    {
        public string QuoteNumber { get; set; } = string.Empty; // Auto-generated
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ExpirationDate { get; set; }
        public QuoteStatus Status { get; set; } = QuoteStatus.Draft;
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FreightAmount { get; set; }
        public decimal NetAmount { get; set; }

        // Relationships
        public Guid OpportunityId { get; set; }
        public Opportunity Opportunity { get; set; } = null!;
        public Guid AccountId { get; set; }
        public Account Account { get; set; } = null!;
        public Guid? ContactId { get; set; }
        public Contact? Contact { get; set; }
        public ICollection<QuoteProduct> QuoteProducts { get; set; } = new List<QuoteProduct>();
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }

}
