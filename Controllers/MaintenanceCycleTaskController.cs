using AutoMapper;
using HomeMaintenance.DTOs;
using HomeMaintenance.Models;
using HomeMaintenance.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace HomeMaintenance.Controllers
{

    public class MaintenanceCycleTaskController : ODataController
    {

        private readonly IMaintenanceCycleRepository _repository;

        private readonly IMapper _mapper;

        private readonly ILogger<MaintenanceCycleTaskController> _logger;

        public MaintenanceCycleTaskController(IMaintenanceCycleRepository repository, 
            IMapper mapper,
            ILogger<MaintenanceCycleTaskController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get all maintenance tasks.  
        /// OData pragmas are enabled and can filter and order records retrieved as well as expand
        /// </summary>
        /// <returns></returns>
        [EnableQuery]
        public async Task<ActionResult<List<MaintenanceCycleTask>>> Get()
        {
            var tasks = await _repository.GetAll();
            return Ok(tasks);
        }

        /// <summary>
        /// Get a specific maintenance task by id
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [EnableQuery]
        public async Task<ActionResult<MaintenanceCycleTask>> Get([FromRoute] long key)
        {
            if (key < 0)
            {
                _logger.LogError("Invalid id used to get maintenance cycle task");
                return BadRequest("Maintenance Cycle Tasks have positive numeric Id values");
            }

            try
            {
                MaintenanceCycleTask? task = await _repository.Get(key);
                if (task == null)
                {
                    return NotFound();
                }
                return Ok(task);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving individual maintenance cycle task");
                return StatusCode(500);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MaintenanceCycleTaskDTO taskDTO)
        {
            if (taskDTO == null) return BadRequest();

            MaintenanceCycleTask task = _mapper.Map<MaintenanceCycleTask>(taskDTO);

            var createdTask = await _repository.Add(task);
            return Created(createdTask);
        }
    }
}
