namespace Faptecsolution.CaritasCRM.Application.Features.Lead.Queries.GetLeadsDetail
{
    public class NoteSummaryDTO
    {
        public Guid Id { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public bool IsPinned { get; set; }
        public bool HasAttachment { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
