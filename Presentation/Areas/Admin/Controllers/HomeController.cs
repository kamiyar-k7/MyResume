using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
