namespace Faptecsolution.CaritasCRM.Application.Features.Lead.Queries.GetAllLeads
{
    public class LeadDTO
    {
        public Guid Id { get; set; }
        public string Topic { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Rating { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
    }

}
