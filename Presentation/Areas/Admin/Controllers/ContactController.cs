using Application.Services.Intefaces;
using Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers;

public class ContactController : AdminBaseController
{
    #region Ctor
    private readonly IContactService _contactService;
    public ContactController(IContactService contactService)
    {
            _contactService = contactService;
    }
    #endregion

    #region Show mesages
    [HttpGet]
    public async Task<IActionResult> ShowMessages()
    {

        var messages = await _contactService.ListOfMessages();
        return View(messages);

    }
    #endregion

    #region Delete message
    [HttpGet]
    public async Task<IActionResult> DeleteMessage(int SenderId)
    {
        await _contactService.DeleteMessage(SenderId);
        return RedirectToAction(nameof(ShowMessages));
    }
    #endregion


}
