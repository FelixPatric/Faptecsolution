using MediatR;

namespace Faptecsolution.CaritasCRM.Application.Features.Notes.Commands.UpdateNoteCommand
{
    public class UpdateNoteCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public bool IsPinned { get; set; }

        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? ContentType { get; set; }
        public long? FileSizeBytes { get; set; }
    }
}
