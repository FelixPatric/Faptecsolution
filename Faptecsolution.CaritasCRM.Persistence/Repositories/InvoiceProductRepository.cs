using Faptecsolution.CaritasCRM.Application.Contracts.Persistence;
using Faptecsolution.CaritasCRM.Domain.Entities;
using Faptecsolution.CaritasCRM.Persistence.DatabaseContext;

namespace Faptecsolution.CaritasCRM.Persistence.Repositories
{
    public class InvoiceProductRepository : GenericRepository<InvoiceProduct>, IInvoiceProductRepository
    {
        public InvoiceProductRepository(CaritasCRMDbContext dbContext) : base(dbContext)
        {
        }
    }


}
