using Microsoft.AspNetCore.Mvc;
using TaskAribMVC.Business.BusinessService;
using TaskAribMVC.Business.IBusinessService;
using TaskAribMVC.DTO;

namespace TaskAribMVC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();
            return View(departments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentDTO departmentDTO)
        {
            if (ModelState.IsValid)
            {
                _departmentService.AddDepartment(departmentDTO);
                return RedirectToAction("Index");
            }
            return View(departmentDTO);
        }
        public IActionResult Edit(int id)
        {
            var department = _departmentService.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(int id, DepartmentDTO department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _departmentService.UpdateDepartment(department);
                return RedirectToAction("Index");
            }
            return View(department);
        }

        public IActionResult Delete(int id)
        {
            var departemnt = _departmentService.GetDepartmentById(id);
            if (departemnt == null)
            {
                return NotFound();
            }
            return View(departemnt);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _departmentService.DeleteDepartment(id);
            return RedirectToAction("Index");
        }
    }

}
