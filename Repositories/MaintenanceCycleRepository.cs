
using AutoMapper;
using HomeMaintenance.DTOs;
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

        private readonly IMapper _Mapper;

        public MaintenanceCycleRepository(EntityContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public async Task<MaintenanceCycleTaskDTO> Add(MaintenanceCycleTaskDTO maintenanceCycle)
        {
            try
            {
                // convert to a model object
                MaintenanceCycleTask newMaintenanceCycleModel = _Mapper.Map<MaintenanceCycleTask>(maintenanceCycle);

                //make database change
                _Context.MaintenanceCycleTasks.Add(newMaintenanceCycleModel);
                await _Context.SaveChangesAsync();

                // convert back to a DTO
                MaintenanceCycleTaskDTO newMaintenanceCycleTaskDTO = _Mapper.Map<MaintenanceCycleTaskDTO>(newMaintenanceCycleModel);
                return newMaintenanceCycleTaskDTO;
            }
            catch (DbUpdateConcurrencyException ex) 
            {
                throw new ApiException("Failed to insert new maintenance cycle task", ex);
            }
        }

        public async Task<MaintenanceCycleTaskDTO?> Get(long maintenanceCycleKey)
        {
            MaintenanceCycleTask task = await _Context.MaintenanceCycleTasks
                .Where(t => t.Id == maintenanceCycleKey)
                .SingleOrDefaultAsync();
            return _Mapper.Map<MaintenanceCycleTaskDTO>(task);
        }

        public async Task<List<MaintenanceCycleTaskDTO>> GetAll()
        {
            var maintenanceTasks = await _Context.MaintenanceCycleTasks.Include(task => task.TaskExecutionHistory).ToListAsync();
            return _Mapper.Map<List<MaintenanceCycleTask>, List<MaintenanceCycleTaskDTO>>(maintenanceTasks);
        }

        public Task<MaintenanceCycleTaskDTO> Update(MaintenanceCycleTaskDTO maintenanceCycle)
        {
            throw new NotImplementedException();
        }
    }
}
