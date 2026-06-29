using AutoMapper;
using Faptecsolution.CaritasCRM.Application.Features.Lead.Commands.CreateLeadCommand;
using Faptecsolution.CaritasCRM.Application.Features.Lead.Commands.UpdateLeadCommand;
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

            CreateMap<CreateLeadCommand, Lead>();

            CreateMap<UpdateLeadCommand, Lead>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.CreatedOn, o => o.Ignore())
                .ForMember(d => d.CreatedBy, o => o.Ignore())
                .ForMember(d => d.ModifiedOn, o => o.Ignore())
                .ForMember(d => d.ModifiedBy, o => o.Ignore())
                .ForMember(d => d.IsDeleted, o => o.Ignore())
                .ForMember(d => d.RowVersion, o => o.Ignore())
                .ForMember(d => d.QualifiedContact, o => o.Ignore())
                .ForMember(d => d.QualifiedAccount, o => o.Ignore())
                .ForMember(d => d.QualifiedOpportunity, o => o.Ignore());
        }
    }
}
