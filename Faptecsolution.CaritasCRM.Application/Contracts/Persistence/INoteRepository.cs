using Faptecsolution.CaritasCRM.Domain.Entities;

namespace Faptecsolution.CaritasCRM.Application.Contracts.Persistence
{
    public interface INoteRepository : IGenericRepository<Note>
    {
        Task<IReadOnlyList<Note>> GetByRegardingAsync(Guid regardingObjectId, string regardingObjectType);

        Task<IReadOnlyList<Note>> GetRecentByRegardingAsync(Guid regardingObjectId, string regardingObjectType, int take = 10);
    }
}
