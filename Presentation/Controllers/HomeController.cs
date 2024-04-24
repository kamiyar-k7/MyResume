using Application.DTOs;
using Application.Services.Intefaces;
using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        
        #region Ctor
    private readonly IHomeService _homeService;
        private readonly IContactService _contactService;
        public HomeController(IHomeService homeService , IContactService contactService)
        {
           
            _homeService = homeService;
            _contactService = contactService;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellation)
        {



            var model = await _homeService.HomeIndex(cancellation);
             return View(model);
            
            
           
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Index( MainViewModel model, CancellationToken cancellation)
        {
            ModelState.Clear();
                // Validate only the ContactViewMdodel
                if (TryValidateModel(model.ContactViewMdodel))
                {
                await _contactService.AddContactUsToDataBaseAsync(model.ContactViewMdodel, cancellation);
                TempData["SuccessMessage"] = "Your message has been successfully sent!";
                return RedirectToAction(nameof(Index));
              
                }
            TempData["ErrorMessage"] = "Failed to send the message. Please check your input.";
            return RedirectToAction(nameof(Index));
            



        }
    }





    
}
