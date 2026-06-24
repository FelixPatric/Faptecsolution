using MediatR;

namespace Faptecsolution.CaritasCRM.Application.Features.Lead.Commands.DeleteLeadCommand
{
    public class DeleteLeadCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
