using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MySCGP.Controllers
{
    [AllowAnonymous]
    public class ErrorHandlerController : Controller
    {

        public IActionResult NotFound()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
