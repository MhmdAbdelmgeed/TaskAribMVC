using TaskAribMVC.DTO;
using TaskAribMVC.Shared.ServiceRegister;

namespace TaskAribMVC.Business.IBusinessService
{
    public interface IDepartmentService : IScopedService
    {
        IEnumerable<DepartmentDTO> GetAllDepartments();
        DepartmentDTO GetDepartmentById(int id);
        void AddDepartment(DepartmentDTO department);
        void UpdateDepartment(DepartmentDTO department);
        void DeleteDepartment(int id);
    }
}
