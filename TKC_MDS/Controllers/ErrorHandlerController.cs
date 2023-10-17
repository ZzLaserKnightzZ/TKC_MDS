using Microsoft.AspNetCore.Mvc;

namespace MySCGP.Controllers
{
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
