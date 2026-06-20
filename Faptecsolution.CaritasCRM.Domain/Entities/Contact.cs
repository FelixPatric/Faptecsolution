using Faptecsolution.CaritasCRM.Domain.Common;

namespace Faptecsolution.CaritasCRM.Domain.Entities
{
    public class Contact : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public bool IsDecisionMaker { get; set; }
        public ContactType Type { get; set; } = ContactType.Employee;

        // Relationships
        public Guid AccountId { get; set; }
        public Account? Account { get; set; }
        public ICollection<Opportunity> Opportunities { get; set; } = new List<Opportunity>();
    }

}
