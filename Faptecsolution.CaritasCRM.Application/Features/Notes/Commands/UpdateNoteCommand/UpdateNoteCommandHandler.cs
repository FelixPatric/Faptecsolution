using Faptecsolution.CaritasCRM.Application.Contracts.Persistence;
using Faptecsolution.CaritasCRM.Application.Exceptions;
using Faptecsolution.CaritasCRM.Domain.Entities;
using MediatR;

namespace Faptecsolution.CaritasCRM.Application.Features.Notes.Commands.UpdateNoteCommand
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, Unit>
    {
        private readonly INoteRepository _noteRepository;

        public UpdateNoteCommandHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var noteToUpdate = await _noteRepository.GetByIdAsync(request.Id);

            if (noteToUpdate is null)
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }

            noteToUpdate.Subject = request.Subject;
            noteToUpdate.Text = request.Text;
            noteToUpdate.IsPinned = request.IsPinned;
            noteToUpdate.FileName = request.FileName;
            noteToUpdate.FilePath = request.FilePath;
            noteToUpdate.ContentType = request.ContentType;
            noteToUpdate.FileSizeBytes = request.FileSizeBytes;

            await _noteRepository.UpdateAsync(noteToUpdate);

            return Unit.Value;
        }
    }
}
