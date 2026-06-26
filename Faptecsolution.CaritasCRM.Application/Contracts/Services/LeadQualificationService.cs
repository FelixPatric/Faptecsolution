using Faptecsolution.CaritasCRM.Application.Contracts.Persistence;
using Faptecsolution.CaritasCRM.Application.Contracts.Services;
using Faptecsolution.CaritasCRM.Application.Exceptions;
using Faptecsolution.CaritasCRM.Domain.Entities;
using Faptecsolution.CaritasCRM.Domain.Enums;

namespace Faptecsolution.CaritasCRM.Application.Features.Lead.Services
{
    public class LeadQualificationService : ILeadQualificationService
    {
        private readonly ILeadRepository _leadRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IOpportunityRepository _opportunityRepository;

        public LeadQualificationService(ILeadRepository leadRepository, IAccountRepository accountRepository, IContactRepository contactRepository, IOpportunityRepository opportunityRepository)
        {
            _leadRepository = leadRepository;
            _accountRepository = accountRepository;
            _contactRepository = contactRepository;
            _opportunityRepository = opportunityRepository;
        }

        public async Task<Guid> QualifyLeadAsync(Guid leadId, Guid? accountId = null, Guid? contactId = null, bool createAccount = true, bool createContact = true, bool createOpportunity = true, string? accountName = null, string? accountEmail = null, string? accountPhone = null, string? accountWebsite = null, string? accountIndustry = null, string? accountBusinessType = null, string? contactFirstName = null, string? contactLastName = null, string? contactEmail = null, string? contactPhone = null, string? contactJobTitle = null, string? contactDepartment = null, string? opportunityName = null, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var lead = await _leadRepository.GetByIdAsync(leadId);

            if (lead is null)
            {
                throw new NotFoundException(nameof(Lead), leadId);
            }

            if (lead.Status is LeadStatus.Qualified or LeadStatus.Disqualified)
            {
                throw new InvalidOperationException(
                    $"Lead ({lead.Id}) cannot be qualified because it is already {lead.Status}.");
            }

            Account? account = null;
            Contact? contact = null;

            if (accountId.HasValue)
            {
                account = await _accountRepository.GetByIdAsync(accountId.Value);

                if (account is null)
                {
                    throw new NotFoundException(nameof(Account), accountId.Value);
                }
            }

            if (contactId.HasValue)
            {
                contact = await _contactRepository.GetByIdAsync(contactId.Value);

                if (contact is null)
                {
                    throw new NotFoundException(nameof(Contact), contactId.Value);
                }

                if (account is not null && contact.AccountId != account.Id)
                {
                    throw new InvalidOperationException("Selected contact does not belong to the selected account.");
                }

                if (account is null)
                {
                    account = await _accountRepository.GetByIdAsync(contact.AccountId);

                    if (account is null)
                    {
                        throw new NotFoundException(nameof(Account), contact.AccountId);
                    }
                }
            }

            if (account is null && createAccount)
            {
                account = new Account
                {
                    Name = string.IsNullOrWhiteSpace(accountName) ? lead.Company : accountName,
                    Email = string.IsNullOrWhiteSpace(accountEmail) ? lead.Email : accountEmail,
                    Phone = string.IsNullOrWhiteSpace(accountPhone) ? lead.Phone : accountPhone,
                    Website = accountWebsite ?? string.Empty,
                    Industry = accountIndustry ?? string.Empty,
                    BusinessType = accountBusinessType ?? string.Empty,
                    Rating = MapAccountRating(lead.Rating)
                };

                await _accountRepository.CreateAsync(account);
            }

            if (contact is null && createContact)
            {
                if (account is null)
                {
                    throw new InvalidOperationException("An account is required before creating a contact.");
                }

                contact = new Contact
                {
                    FirstName = string.IsNullOrWhiteSpace(contactFirstName) ? lead.FirstName : contactFirstName,
                    LastName = string.IsNullOrWhiteSpace(contactLastName) ? lead.LastName : contactLastName,
                    Email = string.IsNullOrWhiteSpace(contactEmail) ? lead.Email : contactEmail,
                    Phone = string.IsNullOrWhiteSpace(contactPhone) ? lead.Phone : contactPhone,
                    JobTitle = string.IsNullOrWhiteSpace(contactJobTitle) ? lead.JobTitle : contactJobTitle,
                    Department = string.IsNullOrWhiteSpace(contactDepartment) ? lead.Department : contactDepartment,
                    AccountId = account.Id,
                    Type = ContactType.Employee
                };

                await _contactRepository.CreateAsync(contact);
            }

            Opportunity? opportunity = null;

            if (createOpportunity)
            {
                if (account is null)
                {
                    throw new InvalidOperationException("An account is required before creating an opportunity.");
                }

                opportunity = new Opportunity
                {
                    Name = string.IsNullOrWhiteSpace(opportunityName) ? lead.Topic : opportunityName,
                    Description = lead.Description,
                    EstimatedAmount = lead.EstimatedAmount,
                    EstimatedCloseDate = lead.EstimatedCloseDate,
                    Stage = OpportunityStage.Qualify,
                    Probability = MapProbability(lead.Rating),
                    Rating = MapOpportunityRating(lead.Rating),
                    SalesStage = "Qualify",
                    AccountId = account.Id,
                    ContactId = contact?.Id,
                    LeadId = lead.Id
                };

                await _opportunityRepository.CreateAsync(opportunity);
            }

            lead.Status = LeadStatus.Qualified;
            lead.StatusReason = "Qualified";
            lead.QualifiedOn = DateTime.UtcNow;
            lead.QualifiedAccountId = account?.Id;
            lead.QualifiedContactId = contact?.Id;
            lead.QualifiedOpportunityId = opportunity?.Id;

            await _leadRepository.UpdateAsync(lead);

            return lead.Id;
        }

        private static decimal MapProbability(LeadRating rating) =>
            rating switch
            {
                LeadRating.Hot => 80,
                LeadRating.Warm => 50,
                LeadRating.Cold => 20,
                _ => 50
            };

        private static OpportunityRating MapOpportunityRating(LeadRating rating) =>
            rating switch
            {
                LeadRating.Hot => OpportunityRating.Hot,
                LeadRating.Warm => OpportunityRating.Warm,
                LeadRating.Cold => OpportunityRating.Cold,
                _ => OpportunityRating.Warm
            };

        private static AccountRating MapAccountRating(LeadRating rating) =>
            rating switch
            {
                LeadRating.Hot => AccountRating.Hot,
                LeadRating.Warm => AccountRating.Warm,
                LeadRating.Cold => AccountRating.Cold,
                _ => AccountRating.Warm
            };
    }
}