using System;
using MediatR;

namespace Faptecsolution.CaritasCRM.Application.Features.Lead.Commands.DisqualifyLeadCommand
{
    public class DisqualifyLeadCommand : IRequest<Unit>
    {
        public Guid LeadId { get; set; }
        public string Reason { get; set; } = string.Empty;
    }
}
