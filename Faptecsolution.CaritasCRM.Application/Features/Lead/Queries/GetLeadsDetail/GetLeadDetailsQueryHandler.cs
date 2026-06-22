using AutoMapper;
using Faptecsolution.CaritasCRM.Application.Contracts.Persistence;
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

            //if (lead is null)
            //{
            //    throw new notfoundexception($"lead with id '{request.id}' was not found.");
            //}

            // 2. Map the lead entity to a DTO
            var leadDetailsDTO = _mapper.Map<LeadDetailsDTO>(lead);

            var recentActivities = await _activityRepository.GetRecentByRegardingAsync(
                lead.Id,
                nameof(Lead),
                take: 10,
                cancellationToken);

            leadDetailsDTO.RecentActivities = _mapper.Map<List<ActivitySummaryDTO>>(recentActivities);
            // 3. Return the DTO
            return leadDetailsDTO;
        }
    }
}
