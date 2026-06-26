using Faptecsolution.CaritasCRM.Application.Contracts.Persistence;
using MediatR;

namespace Faptecsolution.CaritasCRM.Application.Features.Notes.Commands.AddNoteCommand
{
    public class AddNoteCommandHandler : IRequestHandler<AddNoteCommand, Guid>
    {
        private readonly INoteRepository _noteRepository;

        public AddNoteCommandHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<Guid> Handle(AddNoteCommand request, CancellationToken cancellationToken)
        {
            var note = new Domain.Entities.Note
            {
                Subject = request.Subject,
                Text = request.Text,
                RegardingObjectId = request.RegardingObjectId,
                RegardingObjectType = request.RegardingObjectType,
                FileName = request.FileName,
                FilePath = request.FilePath,
                ContentType = request.ContentType,
                FileSizeBytes = request.FileSizeBytes,
                IsPinned = request.IsPinned
            };

            await _noteRepository.CreateAsync(note);

            return note.Id;
        }
    }
}
