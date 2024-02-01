using Application.DTOs.UserSide;
using Application.Services.Intefaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace Presentation.ViewComponents
{
    public class MyServicesViewComponent : ViewComponent
    {

        #region Ctor
        private readonly IMyServicesService _myServicesService;
        public MyServicesViewComponent(IMyServicesService myServicesService)
        {
                   _myServicesService = myServicesService;
        }
        #endregion

        
        public async Task<IViewComponentResult> InvokeAsync( CancellationToken cancellationToken)
        {
            return View("MyServices", await _myServicesService.GetMyservicesAsync(cancellationToken));
        }

    }
}
