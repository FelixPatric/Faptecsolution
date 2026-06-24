using Faptecsolution.CaritasCRM.Application.Contracts.Persistence;
using Faptecsolution.CaritasCRM.Application.Exceptions;
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
            // 1. Retrieve domain entity object
            var leadToDelete = await _leadRepository.GetByIdAsync(request.Id);

            // 2. Check if the lead exists
            if (leadToDelete is null)
            {
                throw new NotFoundException(nameof(Lead), request.Id);
            }

            // 3. Mark the lead as deleted
            leadToDelete.IsDeleted = true;
            await _leadRepository.DeleteAsync(leadToDelete);

            // 4. Return Unit.Value to indicate successful completion
            return Unit.Value;

        }
    }
}
