using AutoMapper;
using HomeMaintenance.DTOs;
using HomeMaintenance.Models;

namespace HomeMaintenance.Profiles
{
    public class MaintenanceCycleTaskProfile : Profile
    {
        public MaintenanceCycleTaskProfile()
        {
            // Bi-directional Default mapping as property names are the same
            CreateMap<MaintenanceCycleTask, MaintenanceCycleTaskDTO>().ReverseMap();            
        }
    }
}
