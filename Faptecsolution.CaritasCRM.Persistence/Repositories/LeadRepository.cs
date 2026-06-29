using Faptecsolution.CaritasCRM.Application.Contracts.Persistence;
using Faptecsolution.CaritasCRM.Domain.Entities;
using Faptecsolution.CaritasCRM.Domain.Enums;
using Faptecsolution.CaritasCRM.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Faptecsolution.CaritasCRM.Persistence.Repositories
{
    public class LeadRepository : GenericRepository<Lead>, ILeadRepository
    {
        public LeadRepository(CaritasCRMDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Lead>> GetLeadsByStatusAsync(LeadStatus leadStatus)
        {
            return await _dbContext.Leads
                .Where(l => l.Status == leadStatus)
                .OrderByDescending(l => l.CreatedOn)
                .ToListAsync();
        }

        public async Task<bool> IsEmailUniqueAsync(string email, Guid? excludeId = null)
        {
            email = email.Trim();

            var exists = await _dbContext.Leads
                .AnyAsync(l =>
                    l.Email == email &&
                    (!excludeId.HasValue || l.Id != excludeId.Value));

            return !exists;
        }

        public async Task<IReadOnlyList<Lead>> SearchAsync(string searchTerm)
        {
            searchTerm = searchTerm.Trim();

            return await _dbContext.Leads
                .Where(l =>
                    EF.Functions.Like(l.Topic, $"%{searchTerm}%") ||
                    EF.Functions.Like(l.FirstName, $"%{searchTerm}%") ||
                    EF.Functions.Like(l.LastName, $"%{searchTerm}%") ||
                    EF.Functions.Like(l.Company, $"%{searchTerm}%") ||
                    EF.Functions.Like(l.Email, $"%{searchTerm}%") ||
                    EF.Functions.Like(l.Phone, $"%{searchTerm}%"))
                .OrderByDescending(l => l.CreatedOn)
                .ToListAsync();
        }
    }
}
