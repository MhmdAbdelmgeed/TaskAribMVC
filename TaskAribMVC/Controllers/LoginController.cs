using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskAribMVC.Business.IBusinessService;
using TaskAribMVC.DTO;
using TaskAribMVC.Models;

namespace TaskAribMVC.Controllers
{

    public class LoginController : Controller
    {
        private readonly IAccountService _accountService;

        public LoginController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.ValidateUser(model);
                if (response.StatusCodes == StatusCodes.Status200OK)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, response.Message);
                }
            }
            return View(model);
        }
    }

}
