using Microsoft.AspNetCore.Mvc;

namespace TKC_MDS.Controllers
{
	public class Home : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
