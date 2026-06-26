using MediatR;

namespace Faptecsolution.CaritasCRM.Application.Features.Lead.Commands.QualifyLeadCommand
{
    public class QualifyLeadCommand : IRequest<Guid>
    {
        public Guid LeadId { get; set; }

        public Guid? AccountId { get; set; }
        public Guid? ContactId { get; set; }

        public bool CreateAccount { get; set; } = true;
        public bool CreateContact { get; set; } = true;
        public bool CreateOpportunity { get; set; } = true;

        public string? AccountName { get; set; }
        public string? AccountEmail { get; set; }
        public string? AccountPhone { get; set; }
        public string? AccountWebsite { get; set; }
        public string? AccountIndustry { get; set; }
        public string? AccountBusinessType { get; set; }

        public string? ContactFirstName { get; set; }
        public string? ContactLastName { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPhone { get; set; }
        public string? ContactJobTitle { get; set; }
        public string? ContactDepartment { get; set; }

        public string? OpportunityName { get; set; }
    }
}
