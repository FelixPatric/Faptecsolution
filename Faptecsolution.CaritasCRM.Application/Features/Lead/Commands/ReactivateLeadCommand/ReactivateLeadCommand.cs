using MediatR;

namespace Faptecsolution.CaritasCRM.Application.Features.Lead.Commands.ReactivatLeadCommand
{
    public class ReactivateLeadCommand : IRequest<Unit>
    {
        public Guid LeadId { get; set; }
        public string? ReactivationNote { get; set; }
    }
}
