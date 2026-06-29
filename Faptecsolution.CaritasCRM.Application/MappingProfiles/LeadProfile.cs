using AutoMapper;
using Faptecsolution.CaritasCRM.Application.Features.Lead.Queries.GetAllLeads;
using Faptecsolution.CaritasCRM.Application.Features.Lead.Queries.GetLeadsDetail;
using Faptecsolution.CaritasCRM.Domain.Entities;

namespace Faptecsolution.CaritasCRM.Application.MappingProfiles
{
    public class LeadProfile : Profile
    {
        public LeadProfile()
        {
            CreateMap<LeadDTO, Lead>().ReverseMap();

            CreateMap<Lead, LeadDetailsDTO>()
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status.ToString()))
                .ForMember(d => d.Source, o => o.MapFrom(s => s.Source.ToString()))
                .ForMember(d => d.Rating, o => o.MapFrom(s => s.Rating.ToString()))
                .ForMember(d => d.Timeline, o => o.Ignore());
        }
    }
}
