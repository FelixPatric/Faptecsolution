using AutoMapper;
using Faptecsolution.CaritasCRM.Application.Contracts.Persistence;
using Faptecsolution.CaritasCRM.Application.Exceptions;
using MediatR;

namespace Faptecsolution.CaritasCRM.Application.Features.Lead.Commands.CreateLeadCommand
{
    public class CreateLeadCommandHandler : IRequestHandler<CreateLeadCommand, Guid>
    {
        private readonly ILeadRepository _leadRepository;
        private readonly IMapper _mapper;

        public CreateLeadCommandHandler(ILeadRepository leadRepository, IMapper mapper)
        {
            _leadRepository = leadRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateLeadCommand request, CancellationToken cancellationToken)
        {
            // 1. Validate the incoming data 
            var validator = new CreateLeadCommandValidator(_leadRepository);

            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid lead data.", validationResult);
            }

            // 2. Convert to domain entity object
            var leadToCreate = _mapper.Map<Domain.Entities.Lead>(request);

            // 3. Add to database
            await _leadRepository.CreateAsync(leadToCreate);


            // 4. Return the ID of the newly created lead
            return leadToCreate.Id;
        }
    }
}
