using AutoMapper;
using TaskAribMVC.Business.IBusinessService;
using TaskAribMVC.DTO;
using TaskAribMVC.GenericRepository.ModelsRepository.IService;
using TaskAribMVC.GenericRepository.ModelsRepository.Service;
using TaskAribMVC.Models;

namespace TaskAribMVC.Business.BusinessService
{

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;


        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, ApplicationDbContext context, IDepartmentRepository departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _context = context;
            _departmentRepository = departmentRepository;
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            var employees = (from employee in _context.Employees
                             join department in _context.Departments on employee.DepartmentId equals department.Id into empDept
                             from dept in empDept.DefaultIfEmpty()
                             select new EmployeeDTO
                             {
                                 Id = employee.Id,
                                 FirstName = employee.FirstName,
                                 LastName = employee.LastName,
                                 ImageUrl = employee.ImageUrl,
                                 Salary = employee.Salary,
                                 ManagerName = employee.ManagerName,
                                 DepartmentId = (int)employee.DepartmentId, // Assign the DepartmentId directly
                                 DepartmentName = dept != null ? dept.Name : "" // Set DepartmentName to department name or empty string if department is null
                             }).ToList();

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
            // Retrieve the department information from the database
            var department = _departmentRepository.GetById((int)employeeDTO.DepartmentId);

            // Update employee's department
            employee.Department = department;
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
