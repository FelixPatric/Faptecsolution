using AutoMapper;
using Faptecsolution.CaritasCRM.Application.Contracts.Persistence;
using Faptecsolution.CaritasCRM.Application.Exceptions;
using MediatR;

namespace Faptecsolution.CaritasCRM.Application.Features.Lead.Queries.GetLeadsDetail
{
    public class GetLeadDetailsQueryHandler : IRequestHandler<GetLeadDetailsQuery, LeadDetailsDTO>
    {
        private readonly ILeadRepository _leadRepository;
        private readonly IActivityRepository _activityRepository;
        private readonly IMapper _mapper;

        public GetLeadDetailsQueryHandler(ILeadRepository leadRepository, IActivityRepository activityRepository, IMapper mapper)
        {
            _leadRepository = leadRepository;
            _activityRepository = activityRepository;
            _mapper = mapper;
        }

        public async Task<LeadDetailsDTO> Handle(GetLeadDetailsQuery request, CancellationToken cancellationToken)
        {
            // 1. Query the database 
            var lead = await _leadRepository.GetByIdAsync(request.Id);

            // 2. verify if the lead exists, if not throw a NotFoundException
            if (lead is null)
            {
                throw new NotFoundException(nameof(Lead), request.Id);
            }

            // 3. Map the lead entity to a DTO
            var leadDetailsDTO = _mapper.Map<LeadDetailsDTO>(lead);

            // for leads with any most recent activity records
            var recentActivities = await _activityRepository.GetRecentByRegardingAsync(
                lead.Id,
                nameof(Lead),
                take: 10,
                cancellationToken);

            leadDetailsDTO.RecentActivities = _mapper.Map<List<ActivitySummaryDTO>>(recentActivities);
            // 4. Return the DTO
            return leadDetailsDTO;
        }
    }
}
