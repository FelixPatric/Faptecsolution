using AutoMapper;
using Faptecsolution.CaritasCRM.Application.Contracts.Persistence;
using Faptecsolution.CaritasCRM.Application.Exceptions;
using Faptecsolution.CaritasCRM.Domain.Entities;
using MediatR;

namespace Faptecsolution.CaritasCRM.Application.Features.Lead.Commands.UpdateLeadCommand
{
    public class UpdateLeadCommandHandler : IRequestHandler<UpdateLeadCommand, Unit>
    {
        private readonly ILeadRepository _leadRepository;
        private readonly IMapper _mapper;

        public UpdateLeadCommandHandler(ILeadRepository leadRepository, IMapper mapper)
        {
            _leadRepository = leadRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeadCommand request, CancellationToken cancellationToken)
        {
            var leadToUpdate = await _leadRepository.GetByIdAsync(request.Id);

            if (leadToUpdate is null)
            {
                throw new NotFoundException(nameof(Lead), request.Id);
            }

            _mapper.Map(request, leadToUpdate);

            await _leadRepository.UpdateAsync(leadToUpdate);

            return Unit.Value;
        }
    }
}
