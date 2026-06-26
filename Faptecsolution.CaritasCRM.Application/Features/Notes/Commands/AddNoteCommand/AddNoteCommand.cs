using MediatR;

namespace Faptecsolution.CaritasCRM.Application.Features.Notes.Commands.AddNoteCommand
{
    public class AddNoteCommand : IRequest<Guid>
    {
        public string Subject { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;

        public Guid? RegardingObjectId { get; set; }
        public string RegardingObjectType { get; set; } = string.Empty;

        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? ContentType { get; set; }
        public long? FileSizeBytes { get; set; }

        public bool IsPinned { get; set; }
    }
}
