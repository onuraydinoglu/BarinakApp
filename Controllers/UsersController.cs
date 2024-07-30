using Microsoft.AspNetCore.Mvc;

namespace Barinak.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

    }
}
