using Application.DTOs;
using Application.DTOs.AdminSide;
using Application.ViewModel;


namespace Application.Services.Intefaces;

public interface IContactService
{
    Task AddContactUsToDataBaseAsync(ContactViewMdodel contactView, CancellationToken cancellationToken);
     Task<List<AdminSideContactDto>> ListOfMessages();
    Task<bool> DeleteMessage(int id);
}
