using System;
using System.Collections.Generic;

namespace Rocket.Models
{
    public partial class Interventions
    {
        public long Id { get; set; }
        public int? AuthorId { get; set; }
        public string EmployeeId { get; set; }
        public int? CustomerId { get; set; }
        public int? BuildingId { get; set; }
        public int? BatteryId { get; set; }
        public int? ColumnId { get; set; }
        public int? ElevatorId { get; set; }
        public DateTime? InterventionStart { get; set; }
        public DateTime? InterventionEnd { get; set; }
        public string InterventionResult { get; set; }
        public string InterventionReport { get; set; }
        public string InterventionStatus { get; set; }
    }
}
