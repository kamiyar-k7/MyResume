using Application.DTOs;
using Application.Services.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Presentation.Areas.Admin.Controllers
{
    public class UserController : AdminBAseController
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
            var user = _userInformationService.GetUserInformation();
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
        public async Task<IActionResult> EditUser(ShowAllDto showAllDto, CancellationToken cancellationToken)
        {

            var res = await _userInformationService.EditUserDto(showAllDto, cancellationToken);
            if (res)
            {
                
                return RedirectToAction(nameof(Details));
            }



            return View(showAllDto);


        }


        #endregion



    }
}
