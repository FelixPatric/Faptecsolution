using AutoMapper;
using Faptecsolution.CaritasCRM.Application.Features.Notes.Commands.AddNoteCommand;
using Faptecsolution.CaritasCRM.Domain.Entities;

namespace Faptecsolution.CaritasCRM.Application.MappingProfiles
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<AddNoteCommand, Note>();
        }
    }
}
