using Faptecsolution.CaritasCRM.Domain.Common;

namespace Faptecsolution.CaritasCRM.Domain.Entities
{
    public class Note : BaseEntity
    {
        public string Subject { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;

        // Generic "Regarding" reference
        public Guid? RegardingObjectId { get; set; }
        public string RegardingObjectType { get; set; } = string.Empty;

        // Optional attachment support
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? ContentType { get; set; }
        public long? FileSizeBytes { get; set; }

        public bool IsPinned { get; set; }
    }
}
