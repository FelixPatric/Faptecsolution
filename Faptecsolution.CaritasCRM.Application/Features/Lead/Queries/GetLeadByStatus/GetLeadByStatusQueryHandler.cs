using AutoMapper;
using Faptecsolution.CaritasCRM.Application.Contracts.Persistence;
using Faptecsolution.CaritasCRM.Application.Features.Lead.Queries.GetAllLeads;
using MediatR;

namespace Faptecsolution.CaritasCRM.Application.Features.Lead.Queries.GetLeadByStatus
{
    public class GetLeadByStatusQueryHandler : IRequestHandler<GetLeadByStatusQuery, IEnumerable<LeadDTO>>
    {
        private readonly ILeadRepository _leadRepository;
        private readonly IMapper _mapper;

        public GetLeadByStatusQueryHandler(ILeadRepository leadRepository, IMapper mapper)
        {
            _leadRepository = leadRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LeadDTO>> Handle(GetLeadByStatusQuery request, CancellationToken cancellationToken)
        {
            var leadsByStatus = await _leadRepository.GetLeadsByStatusAsync(request.leadStatus);

            return _mapper.Map<IEnumerable<LeadDTO>>(leadsByStatus);
        }
    }
}
