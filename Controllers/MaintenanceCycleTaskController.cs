using AutoMapper;
using HomeMaintenance.DTOs;
using HomeMaintenance.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System;
using System.Linq.Expressions;

namespace HomeMaintenance.Controllers
{

    public class MaintenanceCycleTaskController : ODataController
    {

        private readonly IMaintenanceCycleRepository _Repository;

        private readonly IMapper _Mapper;

        private readonly ILogger<MaintenanceCycleTaskController> _Logger;

        public MaintenanceCycleTaskController(IMaintenanceCycleRepository repository, 
            IMapper mapper,
            ILogger<MaintenanceCycleTaskController> logger)
        {
            _Repository = repository;
            _Mapper = mapper;
            _Logger = logger;
        }

        /// <summary>
        /// Get all maintenance tasks.  
        /// OData pragmas are enabled and can filter and order records retrieved as well as expand
        /// </summary>
        /// <returns></returns>
        [EnableQuery]
        public async Task<ActionResult<List<MaintenanceCycleTaskDTO>>> Get()
        {
            try
            {
                var tasks = await _Repository.GetAll();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "Error getting all maintanence cycle tasks");
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Get a specific maintenance task by id
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [EnableQuery]
        public async Task<ActionResult<MaintenanceCycleTaskDTO>> Get([FromRoute] long key)
        {
            if (key < 0)
            {
                _Logger.LogError("Invalid id used to get maintenance cycle task");
                return BadRequest("Maintenance Cycle Tasks have positive numeric Id values");
            }

            try
            {
                MaintenanceCycleTaskDTO? task = await _Repository.Get(key);
                if (task == null)
                {
                    return NotFound();
                }
                return Ok(task);
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "Error retrieving individual maintenance cycle task");
                return StatusCode(500);
            }
        }


        /// <summary>
        /// Create a maintenance cycle task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] HomeMaintenance.DTOs.MaintenanceCycleTaskDTO taskDTO)
        {
            if (taskDTO == null) return BadRequest();            

            try
            {
                var createdTask = await _Repository.Add(taskDTO);

                return Created(createdTask);
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "Error creating a new maintenance cycle task");
                return StatusCode(500);
            }
        }
    }
}
