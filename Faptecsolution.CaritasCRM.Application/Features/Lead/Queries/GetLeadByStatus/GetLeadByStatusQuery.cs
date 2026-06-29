using Faptecsolution.CaritasCRM.Application.Features.Lead.Queries.GetAllLeads;
using Faptecsolution.CaritasCRM.Domain.Enums;
using MediatR;

namespace Faptecsolution.CaritasCRM.Application.Features.Lead.Queries.GetLeadByStatus
{
    public record GetLeadByStatusQuery(LeadStatus leadStatus) : IRequest<IEnumerable<LeadDTO>>
    {
    }
}
