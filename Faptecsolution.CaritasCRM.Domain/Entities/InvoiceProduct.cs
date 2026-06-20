using Faptecsolution.CaritasCRM.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Faptecsolution.CaritasCRM.Domain.Entities
{
    public class InvoiceProduct : BaseEntity
    {
        public int Quantity { get; set; } = 1;
        public decimal UnitPrice { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal LineTotal { get; set; }
        public string Description { get; set; } = string.Empty;

        // Relationships
        public Guid InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }

        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
    }

}
