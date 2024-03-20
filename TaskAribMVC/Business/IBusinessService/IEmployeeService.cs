using TaskAribMVC.DTO;
using TaskAribMVC.Shared.ServiceRegister;

namespace TaskAribMVC.Business.IBusinessService
{
    public interface IEmployeeService:IScopedService
    {
        IEnumerable<EmployeeDTO> GetAllEmployees();
        EmployeeDTO GetEmployeeById(int id);
        void AddEmployee(EmployeeDTO employeeDTO);
        void UpdateEmployee(EmployeeDTO employeeDTO);
        void DeleteEmployee(int id);
    }
}
