using AutoMapper;
using TaskAribMVC.Models;

namespace TaskAribMVC.DTO.Mapping
{
    public class MappersProfile:Profile
    {
        public MappersProfile()
        {
            CreateMap<DepartmentDTO, Department>().ReverseMap();
            CreateMap<Models.Task, TaskDTO>().ReverseMap();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();

        }
    }
}
