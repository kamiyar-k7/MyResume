
using Application.DTOs.AdminSide;
using Application.Services.Intefaces;
using Application.ViewModel;
using Domain.Entities._3Contact;
using Domain.IRepositories;


namespace Application.Services.Implements;

public class ContactService : IContactService
{
    #region ctor
    private readonly IContactRepository _contactRepository;
    public ContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }
    #endregion

    #region General
    public async Task AddContactUsToDataBaseAsync(ContactViewMdodel contactView, CancellationToken cancellationToken)
    {

        Contact contact = new Contact()
        {
            SenderId = contactView.SenderId,
            SenderName = contactView.SenderName,
            SenderEmail = contactView.SenderEmail,
            Subject = contactView.Subject,
            Message = contactView.Message,
            DateTime = DateTime.Now,

        };


        await _contactRepository.AddContactUsToDataBaseAsync(contact, cancellationToken);
    }
    #endregion

    #region Admin Side

    #region list of messages 
    public async Task<List<AdminSideContactDto>> ListOfMessages()
    {

        #region GEt list

        var messages = await _contactRepository.GetListOfMessages();
        if (messages == null) { return null; }

        #endregion

        List<AdminSideContactDto> model = new List<AdminSideContactDto>();

        foreach (var item in messages)
        {

            AdminSideContactDto childmodel = new AdminSideContactDto()
            {
                Message = item.Message,
                SenderEmail = item.SenderEmail,
                SenderId = item.SenderId,
                SenderName = item.SenderName,
                Subject = item.Subject,
                DateTime = item.DateTime,
            };
            model.Add(childmodel);
        }
        return model;
    }

    #endregion

    #region Delete message 

    public async Task<bool> DeleteMessage(int id)
    {
        var message = await _contactRepository.GetContactbyId(id);
        if (message == null) { return false; }

        _contactRepository.DeleteMessage(message);
        await _contactRepository.SaveChanges();
        return true;
    }

    #endregion
    #endregion
}
