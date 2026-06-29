using AutoMapper;
using Faptecsolution.CaritasCRM.Application.Contracts.Persistence;
using Faptecsolution.CaritasCRM.Domain.Entities;
using MediatR;

namespace Faptecsolution.CaritasCRM.Application.Features.Notes.Commands.AddNoteCommand
{
    public class AddNoteCommandHandler : IRequestHandler<AddNoteCommand, Guid>
    {
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;

        public AddNoteCommandHandler(INoteRepository noteRepository, IMapper mapper)
        {
            _noteRepository = noteRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AddNoteCommand request, CancellationToken cancellationToken)
        {
            var note = _mapper.Map<Note>(request);

            await _noteRepository.CreateAsync(note);

            return note.Id;
        }
    }
}
