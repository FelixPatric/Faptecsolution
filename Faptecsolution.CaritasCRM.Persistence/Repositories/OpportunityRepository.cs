using Faptecsolution.CaritasCRM.Application.Contracts.Persistence;
using Faptecsolution.CaritasCRM.Domain.Entities;
using Faptecsolution.CaritasCRM.Persistence.DatabaseContext;

namespace Faptecsolution.CaritasCRM.Persistence.Repositories
{
    public class OpportunityRepository : GenericRepository<Opportunity>, IOpportunityRepository
    {
        public OpportunityRepository(CaritasCRMDbContext dbContext) : base(dbContext)
        {
        }
    }


}
