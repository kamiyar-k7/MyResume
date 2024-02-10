using Application.DTOs;
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
        public HomeController(IUserInformationService userInformationService, IContactService contactService)
        {
            _userInformationService = userInformationService;
            _contactService = contactService;
        }
        #endregion

        [HttpGet]
        public IActionResult Index()
        {
            
           
            
                var user = _userInformationService.GetUserInformation();
                return View(user);
            
            
           
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Index( ContactDtos contactDtos, CancellationToken cancellation)
        {
            if(ModelState.IsValid)
            {
                // SUCCSESS 
                await _contactService.AddContactUsToDataBaseAsync(contactDtos, cancellation);
                TempData["SuccessMessage"] = "Your message has been successfully sent!";
                return RedirectToAction(nameof(Index));
            }
            TempData["ErrorMessage"] = "Failed to send the message. Please check your input.";
            return RedirectToAction(nameof(Index));


        }





    }
}
