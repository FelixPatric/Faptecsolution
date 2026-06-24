using Faptecsolution.CaritasCRM.Domain.Entities;

namespace Faptecsolution.CaritasCRM.Application.Contracts.Persistence
{
    public interface ILeadRepository : IGenericRepository<Lead>
    {
        Task<IReadOnlyList<Lead>> SearchAsync(string searchTerm);
    }



}
