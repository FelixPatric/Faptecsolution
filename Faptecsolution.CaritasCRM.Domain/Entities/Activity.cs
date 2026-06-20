using Faptecsolution.CaritasCRM.Domain.Common;

namespace Faptecsolution.CaritasCRM.Domain.Entities
{
    public class Activity : BaseEntity
    {
        public string Subject { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ActivityType ActivityType { get; set; }
        public ActivityPriority Priority { get; set; } = ActivityPriority.Normal;
        public DateTime ScheduledStart { get; set; }
        public DateTime ScheduledEnd { get; set; }
        public DateTime? ActualStart { get; set; }
        public DateTime? ActualEnd { get; set; }
        public ActivityStatus Status { get; set; } = ActivityStatus.Scheduled;

        // Generic "Regarding" reference
        public Guid? RegardingObjectId { get; set; }
        public string RegardingObjectType { get; set; } = string.Empty;
    }

}
