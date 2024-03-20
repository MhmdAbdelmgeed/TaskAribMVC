using TaskAribMVC.Shared.ServiceRegister;

namespace TaskAribMVC.GenericRepository.ModelsRepository.IService
{
    public interface ITaskRepository : IScopedService
    {
        IEnumerable<Models.Task> GetAll();
        Models.Task GetById(int id);
        void Add(Models.Task task);
        void Update(Models.Task task);
        void Delete(Models.Task task);
    }
}
