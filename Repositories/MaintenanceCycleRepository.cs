
using HomeMaintenance.Exceptions;
using HomeMaintenance.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeMaintenance.Repositories
{
    /// <summary>
    /// Implements the Maintenance Cycle Repository interface.
    /// </summary>
    public class MaintenanceCycleRepository : IMaintenanceCycleRepository
    {

        private readonly EntityContext _Context;

        public MaintenanceCycleRepository(EntityContext context)
        {
            _Context = context;
        }

        public async Task<MaintenanceCycleTask> Add(MaintenanceCycleTask maintenanceCycle)
        {
            try
            {
                _Context.MaintenanceCycleTasks.Add(maintenanceCycle);
                await _Context.SaveChangesAsync();
                return maintenanceCycle;
            }
            catch (DbUpdateConcurrencyException ex) 
            {
                throw new ApiException("Failed to insert new maintenance cycle task", ex);
            }
        }

        public async Task<MaintenanceCycleTask?> Get(long maintenanceCycleKey)
        {
            return await _Context.MaintenanceCycleTasks
                .Where(t => t.Id == maintenanceCycleKey)
                .SingleOrDefaultAsync();
        }

        public async Task<List<MaintenanceCycleTask>> GetAll()
        {
            var maintenanceTasks = await _Context.MaintenanceCycleTasks.Include(task => task.TaskExecutionHistory).ToListAsync();
            return maintenanceTasks;
        }

        public Task<MaintenanceCycleTask> Update(MaintenanceCycleTask maintenanceCycle)
        {
            throw new NotImplementedException();
        }
    }
}
