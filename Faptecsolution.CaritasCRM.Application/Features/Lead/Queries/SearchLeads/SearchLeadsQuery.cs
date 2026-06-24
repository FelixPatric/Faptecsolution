using Faptecsolution.CaritasCRM.Application.Features.Lead.Queries.GetAllLeads;
using MediatR;

namespace Faptecsolution.CaritasCRM.Application.Features.Lead.Queries.SearchLeads
{
    public record SearchLeadsQuery(string SearchTerm) : IRequest<List<LeadDTO>>;
}
