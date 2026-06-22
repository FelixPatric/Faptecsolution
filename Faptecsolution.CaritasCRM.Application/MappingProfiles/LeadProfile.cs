using AutoMapper;
using Faptecsolution.CaritasCRM.Application.Features.Lead.Queries.GetAllLeads;
using Faptecsolution.CaritasCRM.Domain.Entities;

namespace Faptecsolution.CaritasCRM.Application.MappingProfiles
{
    public class LeadProfile : Profile
    {
        public LeadProfile()
        {
            CreateMap<LeadDTO, Lead>().ReverseMap();
        }
    }
}
