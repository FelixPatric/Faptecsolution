using Faptecsolution.CaritasCRM.Domain.Common;

namespace Faptecsolution.CaritasCRM.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProductNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public ProductCategory Category { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<QuoteProduct> QuoteProducts { get; set; } = new List<QuoteProduct>();
        public ICollection<InvoiceProduct> InvoiceProducts { get; set; } = new List<InvoiceProduct>();
    }

}
