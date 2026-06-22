using Faptecsolution.CaritasCRM.Domain.Common;
using Faptecsolution.CaritasCRM.Domain.Enums;

namespace Faptecsolution.CaritasCRM.Domain.Entities
{
    public class InvoicePayment : BaseEntity
    {
        public string PaymentNumber { get; set; } = string.Empty;
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string TransactionId { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;

        // Relationships
        public Guid InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }
    }

}
