using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskAribMVC.Filters;
using TaskAribMVC.Models;
using TaskAribMVC.ViewModels;

namespace TaskAribMVC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //TODO: use viewModel
            var Department = _context.Departments.AsNoTracking().ToList();
            return View(Department);
        }

        [HttpGet]
        [AjaxOnly]
        public IActionResult Create()
        {
            return PartialView("_Form");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DepartmentFormViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Department = new Department { Name = model.Name };
            _context.Add(Department);
            _context.SaveChanges();

            return PartialView("_DepartmentRow", Department);
        }

        [HttpGet]
        [AjaxOnly]
        public IActionResult Edit(int id)
        {
            var Department = _context.Departments.Find(id);

            if (Department is null)
                return NotFound();

            var viewModel = new DepartmentFormViewModel
            {
                Id = id,
                Name = Department.Name
            };

            return PartialView("_Form", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DepartmentFormViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Department = _context.Departments.Find(model.Id);

            if (Department is null)
                return NotFound();

            Department.Name = model.Name;

            _context.SaveChanges();

            return PartialView("_DepartmentRow", Department);
        }


    }

}
