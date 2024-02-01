using Application.DTOs.UserSide;
using Application.Services.Intefaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace Presentation.ViewComponents
{
    public class ContactViewComponent
    {
        #region ctor
         private readonly IContactService _contactService;
        public ContactViewComponent(IContactService contact)
        {
            _contactService = contact;
        }
        #endregion

        //[HttpGet]
        //public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        //{
        //    // Return the view for displaying the contact form
        //    return View("Contact");
        //}

        //[HttpPost , ValidateAntiForgeryToken]
        //public async Task<IViewComponentResult> InvokeAsync(ContactDto contactDto, CancellationToken cancellationToken)
        //{
        //    //if (!ModelState.IsValid)
        //    //{
        //    //    // If model validation fails, return the same view with validation errors
        //    //    return View("Contact", contactDto);
        //    //}

        //    // Add contact to the database
           
           

        //    // Redirect to a success page or return a different view indicating success
        //    return View("Contact",  _contactService.AddContactUsToDataBaseAsync(contactDto, cancellationToken)); // Adjust this to the appropriate view
        //}
    }

}

