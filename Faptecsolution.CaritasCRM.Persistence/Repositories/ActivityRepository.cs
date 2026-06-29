using Faptecsolution.CaritasCRM.Application.Contracts.Persistence;
using Faptecsolution.CaritasCRM.Domain.Entities;
using Faptecsolution.CaritasCRM.Persistence.DatabaseContext;

namespace Faptecsolution.CaritasCRM.Persistence.Repositories
{
    public class ActivityRepository : GenericRepository<Activity>, IActivityRepository
    {
        public ActivityRepository(CaritasCRMDbContext dbContext) : base(dbContext)
        {
        }
    }


}
