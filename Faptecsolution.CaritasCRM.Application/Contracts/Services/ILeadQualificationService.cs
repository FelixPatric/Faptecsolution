namespace Faptecsolution.CaritasCRM.Application.Contracts.Services
{
    public interface ILeadQualificationService
    {
        Task<Guid> QualifyLeadAsync(
            Guid leadId,
            Guid? accountId = null,
            Guid? contactId = null,
            bool createAccount = true,
            bool createContact = true,
            bool createOpportunity = true,
            string? accountName = null,
            string? accountEmail = null,
            string? accountPhone = null,
            string? accountWebsite = null,
            string? accountIndustry = null,
            string? accountBusinessType = null,
            string? contactFirstName = null,
            string? contactLastName = null,
            string? contactEmail = null,
            string? contactPhone = null,
            string? contactJobTitle = null,
            string? contactDepartment = null,
            string? opportunityName = null,
            CancellationToken cancellationToken = default);
    }
}
