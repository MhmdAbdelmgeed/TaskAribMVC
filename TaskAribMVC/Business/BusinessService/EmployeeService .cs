using AutoMapper;
using TaskAribMVC.Business.IBusinessService;
using TaskAribMVC.DTO;
using TaskAribMVC.GenericRepository.ModelsRepository.IService;
using TaskAribMVC.Models;

namespace TaskAribMVC.Business.BusinessService
{

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAll();
            return _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            return _mapper.Map<EmployeeDTO>(employee);
        }

        public void AddEmployee(EmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            _employeeRepository.Add(employee);
        }

        public void UpdateEmployee(EmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            _employeeRepository.Update(employee);
        }

        public void DeleteEmployee(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee != null)
            {
                _employeeRepository.Delete(employee);
            }
        }
    }

}
