using AutoMapper;
using HomeMaintenance.DTOs;
using HomeMaintenance.Models;

namespace HomeMaintenance.Profiles
{
    public class MaintenanceCycleTaskProfile : Profile
    {
        public MaintenanceCycleTaskProfile()
        {
            // Default mapping as property names are the same
            CreateMap<MaintenanceCycleTaskDTO, MaintenanceCycleTask>();            
        }
    }
}
