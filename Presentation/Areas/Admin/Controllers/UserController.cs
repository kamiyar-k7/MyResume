using Application.DTOs;
using Application.DTOs.AdminSide;
using Application.Services.Intefaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Presentation.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        #region Ctor
        private readonly IUserInformationService _userInformationService;
        public UserController(IUserInformationService userInformationService)
        {
            _userInformationService = userInformationService;
        }
        #endregion
        public IActionResult Details()
        {
            var user = _userInformationService.GetUserInformationAdminSide();
            return View(user);
        }

        #region Edit user
        [HttpGet]
        public async Task<IActionResult> EditUser(int id, CancellationToken cancellationToken)
        {
            var user = await _userInformationService.FillUserDto(id, cancellationToken);
            return View(user);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(AdminSideUserDto model, CancellationToken cancellationToken)
        {

            var res = await _userInformationService.EditUserDto(model, cancellationToken);
            if (res)
            {
                
                return RedirectToAction(nameof(Details));
            }

            return View(model);

        }


        #endregion


       
    }
}
