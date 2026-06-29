using Faptecsolution.CaritasCRM.Application.Contracts.Persistence;
using Faptecsolution.CaritasCRM.Application.Exceptions;
using Faptecsolution.CaritasCRM.Domain.Enums;
using MediatR;

namespace Faptecsolution.CaritasCRM.Application.Features.Lead.Commands.ReactivateLeadCommand
{
    public class ReactivateLeadCommandHandler : IRequestHandler<ReactivateLeadCommand, Unit>
    {
        private readonly ILeadRepository _leadRepository;

        public ReactivateLeadCommandHandler(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        public async Task<Unit> Handle(ReactivateLeadCommand request, CancellationToken cancellationToken)
        {
            var lead = await _leadRepository.GetByIdAsync(request.LeadId);

            if (lead is null)
            {
                throw new NotFoundException(nameof(Lead), request.LeadId);
            }

            if (lead.Status != LeadStatus.Disqualified)
            {
                throw new InvalidOperationException(
                    $"Lead '{request.LeadId}' cannot be reactivated because it is not disqualified.");
            }

            lead.Status = LeadStatus.New;
            lead.StatusReason = string.IsNullOrWhiteSpace(request.ReactivationNote)
                ? "Reactivated"
                : request.ReactivationNote;
            lead.ModifiedOn = DateTime.UtcNow;

            await _leadRepository.UpdateAsync(lead);

            return Unit.Value;
        }
    }
}
