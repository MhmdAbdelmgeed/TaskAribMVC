using TaskAribMVC.Models;
using TaskAribMVC.Shared.ServiceRegister;

namespace TaskAribMVC.GenericRepository.ModelsRepository.IService
{
    public interface IDepartmentRepository:IScopedService
    {
        IEnumerable<Department> GetAll();
        Department GetById(int id);
        void Add(Department department);
        void Update(Department department);
        void Delete(Department department);
    }
}
