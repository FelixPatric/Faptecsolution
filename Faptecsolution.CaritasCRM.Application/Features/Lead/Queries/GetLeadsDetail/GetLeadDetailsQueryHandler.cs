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

        public GetLeadDetailsQueryHandler(
            ILeadRepository leadRepository,
            IActivityRepository activityRepository,
            IMapper mapper)
        {
            _leadRepository = leadRepository;
            _activityRepository = activityRepository;
            _mapper = mapper;
        }

        public async Task<LeadDetailsDTO> Handle(GetLeadDetailsQuery request, CancellationToken cancellationToken)
        {
            var lead = await _leadRepository.GetByIdAsync(request.Id);

            if (lead is null)
            {
                throw new NotFoundException(nameof(Lead), request.Id);
            }

            var leadDetailsDTO = _mapper.Map<LeadDetailsDTO>(lead);

            var timeline = await _activityRepository.GetByRegardingAsync(
                lead.Id,
                nameof(Lead),
                cancellationToken);

           
            leadDetailsDTO.Timeline = _mapper.Map<List<TimelineItemDTO>>(timeline)
                .OrderByDescending(x => x.ScheduledStart)
                .ToList();

            return leadDetailsDTO;
        }
    }
}
