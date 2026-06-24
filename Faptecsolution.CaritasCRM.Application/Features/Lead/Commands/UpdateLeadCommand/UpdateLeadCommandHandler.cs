using AutoMapper;
using Faptecsolution.CaritasCRM.Application.Contracts.Persistence;
using Faptecsolution.CaritasCRM.Application.Exceptions;
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
            // 1. Validate the incoming data 
            var validator = new UpdateLeadCommandValidator(_leadRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid lead data.", validationResult);
            }

            // 2. Convert to domain entity object
            var leadToUpdate = _mapper.Map<Domain.Entities.Lead>(request);

            // 3. Update in database
            await _leadRepository.UpdateAsync(leadToUpdate);


            // 4. Return the ID of the updated lead
            return Unit.Value;
        }
    }
}
