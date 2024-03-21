using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskAribMVC.Business.BusinessService;
using TaskAribMVC.Business.IBusinessService;
using TaskAribMVC.DTO;

namespace TaskAribMVC.Controllers
{

    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var employees = _employeeService.GetAllEmployees();
            return View(employees);
        }

        public IActionResult Create()
        {
            var departments = _departmentService.GetAllDepartments();

            ViewBag.Departments = new SelectList(departments ?? new List<DepartmentDTO>(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeDTO employeeDTO)
        {
            if (ModelState.IsValid)
            {
                if (employeeDTO.DepartmentId.HasValue)
                {
                    var department = _departmentService.GetDepartmentById(employeeDTO.DepartmentId.Value);
                    if (department != null)
                    {
                        employeeDTO.DepartmentName = department.Name;
                    }
                }

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

            var departments = _departmentService.GetAllDepartments();
            ViewBag.Departments = new SelectList(departments, "Id", "Name", employee.DepartmentId);

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

            var departments = _departmentService.GetAllDepartments();
            ViewBag.Departments = new SelectList(departments, "Id", "Name", employeeDTO.DepartmentId);

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
