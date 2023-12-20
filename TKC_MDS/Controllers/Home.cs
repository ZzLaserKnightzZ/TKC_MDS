using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TKC_MDS.Controllers
{
	[AllowAnonymous]
	public class Home : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
