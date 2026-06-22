using Faptecsolution.CaritasCRM.Domain.Entities;
using Faptecsolution.CaritasCRM.Domain.Enums;

namespace Faptecsolution.CaritasCRM.Application.Contracts.Persistence
{
    public interface IActivityRepository : IGenericRepository<Activity>
    {
        Task<IReadOnlyList<Activity>> GetRecentByRegardingAsync(
            Guid regardingObjectId,
            string regardingObjectType,
            int take = 10,
            CancellationToken cancellationToken = default);

        Task<IReadOnlyList<Activity>> GetByRegardingAsync(
            Guid regardingObjectId,
            string regardingObjectType,
            CancellationToken cancellationToken = default);

        Task<IReadOnlyList<Activity>> GetOpenByRegardingAsync(
            Guid regardingObjectId,
            string regardingObjectType,
            CancellationToken cancellationToken = default);

        Task<IReadOnlyList<Activity>> GetByRegardingAndTypeAsync(
            Guid regardingObjectId,
            string regardingObjectType,
            ActivityType activityType,
            CancellationToken cancellationToken = default);
    }
}
