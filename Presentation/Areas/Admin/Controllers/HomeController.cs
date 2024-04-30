using Application.Services.Intefaces;
using Application.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers;

public class HomeController : AdminBaseController
{

    #region Ctor
    private readonly IUserInformationService _userInformationService; 
    private readonly IWebLinksService _webLinksService;
    public HomeController(IUserInformationService userInformationService , IWebLinksService webLinksService)
    {
           _userInformationService = userInformationService;
        _webLinksService = webLinksService;
    }
    #endregion

    public  IActionResult Index()
    {
       var info =  _userInformationService.GetUserInformationAdminSide();
        return View(info);
    }

    #region WebLinks
    [HttpGet]
    public async Task<IActionResult> WebLinks()
    {
        var model = await _webLinksService.GetLinks(); 

        return View(model);
    }
    [HttpPost , ValidateAntiForgeryToken]
    public async Task<IActionResult> WebLinks(LinksViewModel model)
    {
        if (ModelState.IsValid)
        {
           await _webLinksService.Updatelinks(model);
                
            return View(model);
        }
        return View(model);
    }
    #endregion



    #region LogOut

    public async Task<IActionResult> LogOut()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction(nameof(Index));
    }
    #endregion
}
