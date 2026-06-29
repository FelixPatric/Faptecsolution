using Faptecsolution.CaritasCRM.Application.Contracts.Persistence;
using Faptecsolution.CaritasCRM.Domain.Entities;
using Faptecsolution.CaritasCRM.Persistence.DatabaseContext;

namespace Faptecsolution.CaritasCRM.Persistence.Repositories
{
    public class QuoteProductRepository : GenericRepository<QuoteProduct>, IQuoteProductRepository
    {
        public QuoteProductRepository(CaritasCRMDbContext dbContext) : base(dbContext)
        {
        }
    }


}
