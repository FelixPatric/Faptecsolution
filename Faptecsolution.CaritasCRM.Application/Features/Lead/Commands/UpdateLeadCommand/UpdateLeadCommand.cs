using Faptecsolution.CaritasCRM.Domain.Enums;
using MediatR;

namespace Faptecsolution.CaritasCRM.Application.Features.Lead.Commands.UpdateLeadCommand
{
    public class UpdateLeadCommand : IRequest<Unit>
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
        public LeadStatus Status { get; set; } = LeadStatus.New;
        public string StatusReason { get; set; } = string.Empty;
        public LeadSource Source { get; set; } = LeadSource.Web;
        public LeadRating Rating { get; set; } = LeadRating.Warm;
        public decimal EstimatedAmount { get; set; }
        public DateTime EstimatedCloseDate { get; set; }
    }
}
