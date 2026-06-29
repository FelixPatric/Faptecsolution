using MediatR;

namespace Faptecsolution.CaritasCRM.Application.Features.Lead.Commands.ReactivateLeadCommand
{
    public class ReactivateLeadCommand : IRequest<Unit>
    {
        public Guid LeadId { get; set; }
        public string? ReactivationNote { get; set; }
    }
}
