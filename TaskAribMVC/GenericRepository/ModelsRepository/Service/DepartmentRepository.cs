using TaskAribMVC.GenericRepository.ModelsRepository.IService;
using TaskAribMVC.Models;

namespace TaskAribMVC.GenericRepository.ModelsRepository.Service
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public void Delete(Department department)
        {
            _context.Departments.Remove(department);
            _context.SaveChanges();
        }

        public IEnumerable<Department> GetAll()
        {
            return _context.Departments.ToList();

        }

        public Department GetById(int id)
        {
            return _context.Departments.FirstOrDefault(e => e.Id == id);

        }

        public void Update(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
        }
    }
}
