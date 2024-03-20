using TaskAribMVC.GenericRepository.ModelsRepository.IService;
using TaskAribMVC.Models;

namespace TaskAribMVC.GenericRepository.ModelsRepository.Service
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Models.Task> GetAll()
        {
            return _context.Tasks.ToList();
        }

        public Models.Task GetById(int id)
        {
            return _context.Tasks.FirstOrDefault(t => t.Id == id);
        }

        public void Add(Models.Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void Update(Models.Task  task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void Delete(Models.Task task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
    }
}
