using Faptecsolution.CaritasCRM.Domain.Common;

namespace Faptecsolution.CaritasCRM.Domain.Entities
{
    public class Invoice : BaseEntity
    {
        public string InvoiceNumber { get; set; } = string.Empty; // Auto-generated (e.g., INV-2024-001)
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime InvoiceDate { get; set; } = DateTime.UtcNow;
        public DateTime DueDate { get; set; }

        // Status Information
        public InvoiceStatus Status { get; set; } = InvoiceStatus.Draft;
        public DateTime? SentDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public DateTime? CanceledDate { get; set; }
        public string StatusReason { get; set; } = string.Empty;

        // Amount Information
        public decimal Subtotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal FreightAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal BalanceDue { get; set; }

        // Payment Information
        public string PaymentTerms { get; set; } = "Net 30";
        public DateTime? LastPaymentDate { get; set; }
        public decimal TotalPayments { get; set; }

        // Shipping Information
        public string ShippingMethod { get; set; } = string.Empty;
        public DateTime? ShippedDate { get; set; }
        public string TrackingNumber { get; set; } = string.Empty;

        // Address Information
        public Address BillingAddress { get; set; } = null!;
        public Address ShippingAddress { get; set; } = null!;

        // Relationships (D365 Style)
        public Guid? QuoteId { get; set; }
        public Quote? Quote { get; set; }

        public Guid AccountId { get; set; }
        public Account Account { get; set; } = null!;

        public Guid? ContactId { get; set; }
        public Contact? Contact { get; set; }

        public Guid? OpportunityId { get; set; }
        public Opportunity? Opportunity { get; set; }

        // Collections
        public ICollection<InvoiceProduct> InvoiceProducts { get; set; } = new List<InvoiceProduct>();
        public ICollection<InvoicePayment> Payments { get; set; } = new List<InvoicePayment>();
    }

}
