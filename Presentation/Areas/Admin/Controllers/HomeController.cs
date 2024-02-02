using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers
{
    public class HomeController : AdminBAseController
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
