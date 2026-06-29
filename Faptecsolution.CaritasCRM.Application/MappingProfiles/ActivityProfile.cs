using AutoMapper;
using Faptecsolution.CaritasCRM.Application.Features.Lead.Queries.GetLeadsDetail;
using Faptecsolution.CaritasCRM.Domain.Entities;

namespace Faptecsolution.CaritasCRM.Application.MappingProfiles
{
    public class ActivityProfile : Profile
    {
        public ActivityProfile()
        {
            CreateMap<Activity, TimelineItemDTO>()
                .ForMember(d => d.ActivityType, o => o.MapFrom(s => s.ActivityType.ToString()))
                .ForMember(d => d.Priority, o => o.MapFrom(s => s.Priority.ToString()))
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status.ToString()));
        }
    }
}
