using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PresentationLayer.Controllers
{
    public class HomeController:Controller
    {
        public IActionResult Bekleyen()
        {
            return View();
        }
    }
}
