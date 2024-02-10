using Application.Services.Intefaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {

        #region Ctor
        private readonly IUserInformationService _userInformationService; 
        public HomeController(IUserInformationService userInformationService)
        {
               _userInformationService = userInformationService;
        }
        #endregion

        public IActionResult Index()
        {
           var info = _userInformationService.GetUserInformation();
            return View(info);
        }

        #region LogOut

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
