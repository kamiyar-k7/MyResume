using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        [Area("Admin")]
        public async Task<IActionResult> Details()
        {
            return View();
        }
         
    }
}
