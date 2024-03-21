using TaskAribMVC.DTO;
using TaskAribMVC.Shared.ServiceRegister;

namespace TaskAribMVC.Business.IBusinessService
{
    public interface ITaskService:IScopedService
    {
        IEnumerable<TaskDTO> GetAllTasks();
        TaskDTO GetTaskById(int id);
        void AddTask(TaskDTO task);
        void UpdateTask(TaskDTO task);
        void DeleteTask(int id);
    }
}
