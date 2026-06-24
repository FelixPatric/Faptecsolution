using AutoMapper;
using Faptecsolution.CaritasCRM.Application.Contracts.Persistence;
using Faptecsolution.CaritasCRM.Application.Features.Lead.Queries.GetAllLeads;
using MediatR;

namespace Faptecsolution.CaritasCRM.Application.Features.Lead.Queries.SearchLeads
{
    public class SearchLeadsQueryHandler : IRequestHandler<SearchLeadsQuery, List<LeadDTO>>
    {
        private readonly ILeadRepository _leadRepository;
        private readonly IMapper _mapper;

        public SearchLeadsQueryHandler(ILeadRepository leadRepository, IMapper mapper)
        {
            _leadRepository = leadRepository;
            _mapper = mapper;
        }

        public async Task<List<LeadDTO>> Handle(SearchLeadsQuery request, CancellationToken cancellationToken)
        {
            var leads = await _leadRepository.SearchAsync(request.SearchTerm);

            return _mapper.Map<List<LeadDTO>>(leads);
        }
    }
}
