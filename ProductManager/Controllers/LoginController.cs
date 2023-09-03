using Microsoft.AspNetCore.Mvc;
using ProductManager.Exceptions;
using ProductManager.Models;
using ProductManager.Models.ViewModels;

namespace ProductManager.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public IActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.Login != LoginData.login || model.Password != LoginData.password)
                    {
                        throw new AuthorizationException();
                    }
                    LoginData.isLoggedIn = true;
                }
                catch (AuthorizationException)
                {
                    ModelState.AddModelError("Login", "Логин или пароль неверные");
                }
            }

            return View("Index", model);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            LoginData.isLoggedIn = false;

            return View("Index");
        }
    }
}
