using Faptecsolution.CaritasCRM.Domain.Common;

namespace Faptecsolution.CaritasCRM.Domain.Entities
{
    public class QuoteProduct : BaseEntity
    {
        public int Quantity { get; set; } = 1;
        public decimal UnitPrice { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal LineTotal { get; set; }

        public Guid QuoteId { get; set; }
        public Quote? Quote { get; set; }
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
    }


}
