using Application.DTOs.UserSide;
using Application.Services.Intefaces;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        #region Ctor
        private readonly IUserInformationService _userInformationService;
        public HomeController(IUserInformationService userInformationService)
        {
            _userInformationService = userInformationService;
        }
        #endregion

       // [HttpGet]
        public IActionResult Index(ShowAllDto showAllDto)
        {
          var user =  _userInformationService. GetUserInformation();
            return View(user);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Index()
        {
            return View();
        }


    }
}
