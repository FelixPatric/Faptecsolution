namespace Faptecsolution.CaritasCRM.Application.Features.Lead.Queries.GetLeadsDetail
{
    public class LeadDetailsDTO
    {
        public Guid Id { get; set; }
        public string Topic { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string StatusReason { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public string Rating { get; set; } = string.Empty;
        public decimal EstimatedAmount { get; set; }
        public DateTime EstimatedCloseDate { get; set; }

        public DateTime? QualifiedOn { get; set; }
        public Guid? QualifiedContactId { get; set; }
        public Guid? QualifiedAccountId { get; set; }
        public Guid? QualifiedOpportunityId { get; set; }

        public List<TimelineItemDTO> Timeline { get; set; } = [];
    }
}
