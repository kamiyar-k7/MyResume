using Application.DTOs;
using Application.Services.Intefaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        [HttpGet]
        public IActionResult LogIn()
        {

            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(AdminLoginDto model)
        {
            if (ModelState.IsValid)
            {
                var admin = await _userInformationService.LogIn(model);
                if (admin)
                {
                    var claims = new List<Claim>
                      {
                         new (ClaimTypes.NameIdentifier, model.Id.ToString()),
                         new (ClaimTypes.Name , model.Id.ToString()),


                      };

                    var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(claimIdentity);

                    var authProps = new AuthenticationProperties();
                    authProps.IsPersistent = model.RememberMe;

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProps);
                    
                    return RedirectToAction("Index", "Home");
                   

                }
              
            }
            TempData["ErrorMessage"] = "Failed to log in. Please check your inputs.";
            return View();
        }
        #endregion

    }
}
