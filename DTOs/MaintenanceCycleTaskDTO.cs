using HomeMaintenance.Models;

namespace HomeMaintenance.DTOs
{
    /// <summary>
    /// Data transfer object for maintenance cycle task
    /// </summary>
    public class MaintenanceCycleTaskDTO
    {
        public long? Id { get; set; }

        public required string TaskName { get; set; }

        public required int TaskFrequency { get; set; }

        public int? WeekNumber { get; set; }

        public IEnumerable<TaskExecutionHistoryDTO>? TaskExecutionHistory { get; set; }
    }
}
