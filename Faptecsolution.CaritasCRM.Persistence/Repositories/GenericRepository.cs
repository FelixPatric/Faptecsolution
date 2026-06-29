using Faptecsolution.CaritasCRM.Application.Contracts.Persistence;
using Faptecsolution.CaritasCRM.Domain.Common;
using Faptecsolution.CaritasCRM.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Faptecsolution.CaritasCRM.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly CaritasCRMDbContext _dbContext;

        public GenericRepository(CaritasCRMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            entity.IsDeleted = true;
            entity.ModifiedOn = DateTime.UtcNow;

            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync()
        {
            return await _dbContext.Set<T>()
                .Where(x => !x.IsDeleted)
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>()
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }
    }
}
