using Faptecsolution.CaritasCRM.Application.Contracts.Persistence;
using MediatR;

namespace Faptecsolution.CaritasCRM.Application.Features.Lead.Commands.DeleteLeadCommand
{
    public class DeleteLeadCommandHandler : IRequestHandler<DeleteLeadCommand, Unit>
    {
        private readonly ILeadRepository _leadRepository;

        public DeleteLeadCommandHandler(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        public async Task<Unit> Handle(DeleteLeadCommand request, CancellationToken cancellationToken)
        {
            var leadToDelete = await _leadRepository.GetByIdAsync(request.Id);

            // Check if the lead exists
            //if (leadToDelete == null)
            //{
            //    throw new NotFoundException(nameof(Lead), request.Id);
            //}
            leadToDelete.IsDeleted = true;
            await _leadRepository.DeleteAsync(leadToDelete);

            return Unit.Value;

        }
    }
}
