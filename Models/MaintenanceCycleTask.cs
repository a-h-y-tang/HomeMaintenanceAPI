using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeMaintenance.Models
{
    /// <summary>
    /// MaintenanceCycle EF entity
    /// </summary>
    public class MaintenanceCycleTask
    {
        /// <summary>
        /// Surrogate primary key for tasks in the maintenance cycle
        /// </summary>
        [Key]
        [Required]
        [Column(name:"Id")]
        public long Id { get; set; }

        /// <summary>
        /// Name of the task to perform
        /// </summary>
        [Required]
        [Column(name:"TaskName")]
        public required string TaskName {  get; set; }

        /// <summary>
        /// Frequency of the task
        /// </summary>
        [Required]
        [Column(name:"TaskFrequency")]
        public required Frequency TaskFrequency {  get; set; }

        /// <summary>
        /// When it's a weekly task, this field captures the week number in a month for it to be preferably performed on.
        /// In this scheme, weeks start on a Monday and end on a Sunday.
        /// The first week will have the value of 1, the second week will have a value of 2 and so forth.  
        /// As tasks are normally completed on a weekend and not during a weekday, and very few months have a 5th weekend, tasks generally shouldn't be set to a WeekNumber of 5.
        /// </summary>
        [Column(name:"WeekNumber")]
        public int? WeekNumber { get; set; }

        public IEnumerable<TaskExecutionHistory>? TaskExecutionHistory { get; set; }
    }

    public enum Frequency : int { Monthly = 0, Quarterly = 1, Semiannual = 2, Yearly = 3}

}
