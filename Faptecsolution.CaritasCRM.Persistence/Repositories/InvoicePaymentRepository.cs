using Faptecsolution.CaritasCRM.Application.Contracts.Persistence;
using Faptecsolution.CaritasCRM.Domain.Entities;
using Faptecsolution.CaritasCRM.Persistence.DatabaseContext;

namespace Faptecsolution.CaritasCRM.Persistence.Repositories
{
    public class InvoicePaymentRepository : GenericRepository<InvoicePayment>, IInvoicePaymentRepository
    {
        public InvoicePaymentRepository(CaritasCRMDbContext dbContext) : base(dbContext)
        {
        }
    }


}
