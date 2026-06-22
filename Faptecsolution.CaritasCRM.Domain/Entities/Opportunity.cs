using Faptecsolution.CaritasCRM.Domain.Common;
using Faptecsolution.CaritasCRM.Domain.Enums;

namespace Faptecsolution.CaritasCRM.Domain.Entities
{
    public class Opportunity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal EstimatedAmount { get; set; }
        public decimal ActualAmount { get; set; }
        public DateTime EstimatedCloseDate { get; set; }
        public DateTime? ActualCloseDate { get; set; }
        public OpportunityStage Stage { get; set; } = OpportunityStage.Qualify;
        public decimal Probability { get; set; }
        public OpportunityRating Rating { get; set; } = OpportunityRating.Warm;
        public string SalesStage { get; set; } = string.Empty;

        // Required parent account (1 Account → many Opportunities)
        public Guid AccountId { get; set; }
        public Account Account { get; set; } = null!;

        // Optional related contact and lead
        public Guid? ContactId { get; set; }
        public Contact? Contact { get; set; }

        public Guid? LeadId { get; set; }
        public Lead? Lead { get; set; }

        // Child records
        public ICollection<Quote> Quotes { get; set; } = new List<Quote>();
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }

}
