using HomeMaintenance.DTOs;

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
        public Task<List<MaintenanceCycleTaskDTO>> GetAll();

        /// <summary>
        /// Retrieve a specific maintenance cycle task
        /// </summary>
        /// <param name="maintenanceCycleKey"></param>
        /// <returns></returns>
        public Task<MaintenanceCycleTaskDTO?> Get(long maintenanceCycleKey);

        /// <summary>
        /// Insert a new maintenance cycle task
        /// </summary>
        /// <param name="maintenanceCycle"></param>
        /// <returns></returns>
        public Task<MaintenanceCycleTaskDTO> Add(MaintenanceCycleTaskDTO maintenanceCycle);

        /// <summary>
        /// Updates an existing maintenance cycle task
        /// </summary>
        /// <param name="maintenanceCycle"></param>
        /// <returns></returns>
        public Task<MaintenanceCycleTaskDTO> Update(MaintenanceCycleTaskDTO maintenanceCycle);

        // Maintenance cycles shouldn't be deleted.  It would cascade and require removal from the task execution history.
    }
}
