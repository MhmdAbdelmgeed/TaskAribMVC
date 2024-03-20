using AutoMapper;
using TaskAribMVC.Business.IBusinessService;
using TaskAribMVC.DTO;
using TaskAribMVC.GenericRepository.ModelsRepository.IService;
using TaskAribMVC.Models;

namespace TaskAribMVC.Business.BusinessService
{

    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public IEnumerable<DepartmentDTO> GetAllDepartments()
        {
            var departments = _departmentRepository.GetAll();
            return _mapper.Map<IEnumerable<DepartmentDTO>>(departments);
        }

        public DepartmentDTO GetDepartmentById(int id)
        {
            var department = _departmentRepository.GetById(id);
            return _mapper.Map<DepartmentDTO>(department);
        }

        public void AddDepartment(DepartmentDTO departmentDTO)
        {
            var department = _mapper.Map<Department>(departmentDTO);
            _departmentRepository.Add(department);
        }

        public void UpdateDepartment(DepartmentDTO departmentDTO)
        {
            var department = _mapper.Map<Department>(departmentDTO);
            _departmentRepository.Update(department);
        }

        public void DeleteDepartment(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department != null)
            {
                _departmentRepository.Delete(department);
            }
        }
    }

}
