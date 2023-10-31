using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PresentationLayer.Controllers
{
    public class HomeController:Controller
    {
		public IActionResult IsEkle()
		{
			return View();
		}

		public IActionResult Bekleyen()
        {
            return View();
        }


    }
}
