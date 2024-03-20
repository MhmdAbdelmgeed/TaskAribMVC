using Microsoft.AspNetCore.Mvc;
using TaskAribMVC.Business.IBusinessService;
using TaskAribMVC.DTO;

namespace TaskAribMVC.Controllers
{

    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var employees = _employeeService.GetAllEmployees();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeDTO employeeDTO)
        {
            if (ModelState.IsValid)
            {
                _employeeService.AddEmployee(employeeDTO);
                return RedirectToAction("Index");
            }
            return View(employeeDTO);
        }

        public IActionResult Edit(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(int id, EmployeeDTO employeeDTO)
        {
            if (id != employeeDTO.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _employeeService.UpdateEmployee(employeeDTO);
                return RedirectToAction("Index");
            }
            return View(employeeDTO);
        }

        public IActionResult Delete(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _employeeService.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }

}
