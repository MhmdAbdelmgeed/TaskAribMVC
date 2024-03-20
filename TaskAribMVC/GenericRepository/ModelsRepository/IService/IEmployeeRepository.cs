using TaskAribMVC.Models;
using TaskAribMVC.Shared.ServiceRegister;

namespace TaskAribMVC.GenericRepository.ModelsRepository.IService
{
    public interface IEmployeeRepository : IScopedService
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
    }
}
