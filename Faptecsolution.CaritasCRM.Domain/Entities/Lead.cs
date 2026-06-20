using System.Security.Principal;

namespace Faptecsolution.CaritasCRM.Domain.Entities
{
    public class Lead
    {
        public string Topic { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public LeadStatus Status { get; set; } = LeadStatus.New;
        public string StatusReason { get; set; } = string.Empty;
        public LeadSource Source { get; set; } = LeadSource.Web;
        public LeadRating Rating { get; set; } = LeadRating.Warm;
        public decimal EstimatedAmount { get; set; }
        public DateTime EstimatedCloseDate { get; set; }

        // Qualification fields
        public DateTime? QualifiedOn { get; set; }
        public Guid? QualifiedContactId { get; set; }
        public Contact? QualifiedContact { get; set; }
        public Guid? QualifiedAccountId { get; set; }
        public Account? QualifiedAccount { get; set; }
        public Guid? QualifiedOpportunityId { get; set; }
        public Opportunity? QualifiedOpportunity { get; set; }
    }
}
