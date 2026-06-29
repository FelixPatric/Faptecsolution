using Faptecsolution.CaritasCRM.Domain.Entities;
using Faptecsolution.CaritasCRM.Domain.Enums;

namespace Faptecsolution.CaritasCRM.Application.Contracts.Persistence
{
    public interface ILeadRepository : IGenericRepository<Lead>
    {
        Task<IReadOnlyList<Lead>> SearchAsync(string searchTerm);
        Task<bool> IsEmailUniqueAsync(string email, Guid? excludeId = null);
        Task<IEnumerable<Lead>> GetLeadsByStatusAsync(LeadStatus leadStatus);

    }



}
