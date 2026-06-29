using Faptecsolution.CaritasCRM.Application.Contracts.Persistence;
using Faptecsolution.CaritasCRM.Domain.Entities;
using Faptecsolution.CaritasCRM.Persistence.DatabaseContext;

namespace Faptecsolution.CaritasCRM.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(CaritasCRMDbContext dbContext) : base(dbContext)
        {
        }
    }


}
