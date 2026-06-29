using Faptecsolution.CaritasCRM.Application.Contracts.Persistence;
using Faptecsolution.CaritasCRM.Domain.Entities;
using Faptecsolution.CaritasCRM.Persistence.DatabaseContext;

namespace Faptecsolution.CaritasCRM.Persistence.Repositories
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(CaritasCRMDbContext dbContext) : base(dbContext)
        {
        }
    }


}
