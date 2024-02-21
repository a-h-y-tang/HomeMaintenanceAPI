using HomeMaintenance.Models;

namespace HomeMaintenance.DTOs
{
    public class MaintenanceCycleTaskDTO
    {
        public long? Id { get; set; }

        public required string TaskName { get; set; }

        public required Frequency TaskFrequency { get; set; }

        public int? WeekNumber { get; set; }
    }
}
