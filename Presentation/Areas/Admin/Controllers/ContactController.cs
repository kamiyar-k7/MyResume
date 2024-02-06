using Application.Services.Intefaces;
using Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers
{
    public class ContactController : AdminBaseController
    {
        #region Ctor
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
                _contactService = contactService;
        }
        #endregion
        [HttpGet]
        public async Task<IActionResult> ShowMessages()
        {
            
            var messages = await _contactService.ListOfMessages();
            return View(messages);

        }
    }
}
