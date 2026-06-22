using MediatR;

namespace Faptecsolution.CaritasCRM.Application.Features.Lead.Queries.GetLeadsDetail
{
    public class GetLeadDetailsQuery : IRequest<LeadDetailsDTO>
    {
        public Guid Id { get; set; }
    }
}
