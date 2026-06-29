using Faptecsolution.CaritasCRM.Application.Contracts.Persistence;
using Faptecsolution.CaritasCRM.Application.Exceptions;
using Faptecsolution.CaritasCRM.Domain.Enums;
using MediatR;

namespace Faptecsolution.CaritasCRM.Application.Features.Lead.Commands.DisqualifyLeadCommand
{
    public class DisqualifyLeadCommandHandler : IRequestHandler<DisqualifyLeadCommand, Unit>
    {
        private readonly ILeadRepository _leadRepository;

        public DisqualifyLeadCommandHandler(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        public async Task<Unit> Handle(DisqualifyLeadCommand request, CancellationToken cancellationToken)
        {
            var leadToDisqualify = await _leadRepository.GetByIdAsync(request.LeadId);
            if (leadToDisqualify is null)
            {
                throw new NotFoundException(nameof(Lead), request.LeadId);
            }

            if (leadToDisqualify.Status == LeadStatus.Disqualified)
            {
                throw new InvalidOperationException($"Lead with ID {request.LeadId} is already disqualified.");
            }

            leadToDisqualify.Status = LeadStatus.Disqualified;
            leadToDisqualify.StatusReason = request.Reason;
            leadToDisqualify.ModifiedOn = DateTime.UtcNow;

            await _leadRepository.UpdateAsync(leadToDisqualify);

            return Unit.Value;
        }
    }
}
