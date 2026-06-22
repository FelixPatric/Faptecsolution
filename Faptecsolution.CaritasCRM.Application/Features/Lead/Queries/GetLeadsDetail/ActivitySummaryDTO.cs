using System;
using System.Collections.Generic;
using System.Text;

namespace Faptecsolution.CaritasCRM.Application.Features.Lead.Queries.GetLeadsDetail
{
    public class ActivitySummaryDTO
    {
        public Guid Id { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ActivityType { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime ScheduledStart { get; set; }
        public DateTime ScheduledEnd { get; set; }
    }
}
