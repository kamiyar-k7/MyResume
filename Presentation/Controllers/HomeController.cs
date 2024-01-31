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
        private readonly IContactService _contactService;
        public HomeController(IUserInformationService userInformationService , IContactService contactService)
        {
            _userInformationService = userInformationService;
            _contactService = contactService;
        }
        #endregion

       [HttpGet]
        public IActionResult Index(ShowAllDto showAllDto)
        {
          var user =  _userInformationService. GetUserInformation();
            return View(user);
        }
        

      


    }
}
