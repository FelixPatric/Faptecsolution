using Faptecsolution.CaritasCRM.Application.Contracts.Persistence;
using Faptecsolution.CaritasCRM.Domain.Entities;
using Faptecsolution.CaritasCRM.Persistence.DatabaseContext;

namespace Faptecsolution.CaritasCRM.Persistence.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(CaritasCRMDbContext dbContext) : base(dbContext)
        {
        }

    }


}
