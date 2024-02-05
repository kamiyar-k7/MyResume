using Application.DTOs;
using Application.Services.Intefaces;
using Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers
{
    public class MyServicesController : AdminBAseController
    {

        #region Ctor
        private readonly IMyServicesService _myserviceServices;
        public MyServicesController(IMyServicesService myServicesService)
        {
            _myserviceServices = myServicesService;
        }
        #endregion

        #region  List OF Services 
        public async Task<IActionResult> ListOfServices(CancellationToken cancellationToken)
        {
            var services = await _myserviceServices.GetMyservicesAsync(cancellationToken);
            return View(services);
        }
        #endregion

        #region Edit Services 
        [HttpGet]
        public async Task<IActionResult> EditService(int ServiceId)
        {

            var service = await _myserviceServices.FillMyServiceDto(ServiceId);
            return View(service);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditService(MyServiceDto myServiceDto)
        {


            var res = await _myserviceServices.UpdateMyService(myServiceDto);
            if (res)
            {
                return RedirectToAction(nameof(ListOfServices));
            }

            return View(myServiceDto);

        }
        #endregion

        #region Add New Service
        [HttpGet]
        public async Task<IActionResult> AddService()
        {
            return View();
        }
        [HttpPost , ValidateAntiForgeryToken]
        public async Task<IActionResult> AddService(MyServiceDto myServiceDto)
        {
            if(ModelState.IsValid)
            {
                await _myserviceServices.AddService(myServiceDto);
                return RedirectToAction(nameof(ListOfServices));
            }

            return View(myServiceDto);

        }

        #endregion

        #region Delete Service 
        public async Task<IActionResult> DeleteService(int ServiceId)
        {
            if(ModelState.IsValid)
            {
                var res = await _myserviceServices.DeleteMyService(ServiceId);
                if (res)
                {
                    return RedirectToAction(nameof(ListOfServices));
                }
            }


            return RedirectToAction(nameof(ListOfServices));
        }
        #endregion
    }
}
