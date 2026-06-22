using AutoMapper;
using Faptecsolution.CaritasCRM.Application.Contracts.Persistence;
using MediatR;

namespace Faptecsolution.CaritasCRM.Application.Features.Lead.Queries.GetAllLeads
{
    public class GetAllLeadsQueryHandler : IRequestHandler<GetAllLeadsQuery, List<LeadDTO>>
    {
        private readonly ILeadRepository _leadRepository;
        private readonly IMapper _mapper;

        public GetAllLeadsQueryHandler(ILeadRepository leadRepository, IMapper mapper)
        {
            _leadRepository = leadRepository;
            _mapper = mapper;
        }

        public async Task<List<LeadDTO>> Handle(GetAllLeadsQuery request, CancellationToken cancellationToken)
        {
            // 1. Query the database
            var leads = await _leadRepository.GetAsync();

            // 2. Convert data objects to DTOs objects
            var data = _mapper.Map<List<LeadDTO>>(leads);

            // 3. Return the list of DTOs
            return data;
        }
    }
}
