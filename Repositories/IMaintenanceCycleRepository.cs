using HomeMaintenance.Models;

namespace HomeMaintenance.Repositories
{
    /// <summary>
    /// Maintenance cycle repository interface
    /// </summary>
    public interface IMaintenanceCycleRepository
    {
        /// <summary>
        /// Get all records of the maintenance cycle
        /// </summary>
        /// <returns></returns>
        public Task<List<MaintenanceCycleTask>> GetAll();

        /// <summary>
        /// Retrieve a specific maintenance cycle task
        /// </summary>
        /// <param name="maintenanceCycleKey"></param>
        /// <returns></returns>
        public Task<MaintenanceCycleTask?> Get(long maintenanceCycleKey);

        /// <summary>
        /// Insert a new maintenance cycle task
        /// </summary>
        /// <param name="maintenanceCycle"></param>
        /// <returns></returns>
        public Task<MaintenanceCycleTask> Add(MaintenanceCycleTask maintenanceCycle);

        /// <summary>
        /// Updates an existing maintenance cycle task
        /// </summary>
        /// <param name="maintenanceCycle"></param>
        /// <returns></returns>
        public Task<MaintenanceCycleTask> Update(MaintenanceCycleTask maintenanceCycle);

        // Maintenance cycles shouldn't be deleted.  It would cascade and require removal from the task execution history.
    }
}
