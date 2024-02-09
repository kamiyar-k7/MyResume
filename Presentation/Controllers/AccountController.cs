using Application.Services.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class AccountController : Controller
    {

        #region Ctor
        private readonly IUserInformationService _userInformationService;
        public AccountController(IUserInformationService userInformationService)
        {
                _userInformationService = userInformationService;
        }
        #endregion

        #region Login
        public IActionResult LogIn()
        {
            return View();
        }
        #endregion

    }
}
