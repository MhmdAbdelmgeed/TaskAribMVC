using AutoMapper;
using TaskAribMVC.Business.IBusinessService;
using TaskAribMVC.DTO;
using TaskAribMVC.GenericRepository.ModelsRepository.IService;

namespace TaskAribMVC.Business.BusinessService
{


    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public IEnumerable<TaskDTO> GetAllTasks()
        {
            var tasks = _taskRepository.GetAll();
            return _mapper.Map<IEnumerable<TaskDTO>>(tasks);
        }

        public TaskDTO GetTaskById(int id)
        {
            var task = _taskRepository.GetById(id);
            return _mapper.Map<TaskDTO>(task);
        }

        public void AddTask(TaskDTO taskDTO)
        {
            var task = _mapper.Map<Models.Task>(taskDTO);
            _taskRepository.Add(task);
        }

        public void UpdateTask(TaskDTO taskDTO)
        {
            var task = _mapper.Map<Models.Task>(taskDTO);
            _taskRepository.Update(task);
        }

        public void DeleteTask(int id)
        {
            var task = _taskRepository.GetById(id);
            if (task != null)
            {
                _taskRepository.Delete(task);
            }
        }
    }

}
