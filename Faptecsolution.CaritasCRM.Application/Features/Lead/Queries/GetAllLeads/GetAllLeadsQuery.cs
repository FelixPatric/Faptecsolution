using MediatR;

namespace Faptecsolution.CaritasCRM.Application.Features.Lead.Queries.GetAllLeads
{
    public record GetAllLeadsQuery : IRequest<List<LeadDTO>>
    {
    }
}
