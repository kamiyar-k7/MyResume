using Application.DTOs.UserSide;
using Application.Services.Intefaces;
using Domain.Entities._3Contact;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implements
{
    public class ContactService : IContactService
    {
        #region ctor
        private readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        #endregion
        
        public async Task AddContactUsToDataBaseAsync(ContactDtos contactDto, CancellationToken cancellationToken)
        {

            Contact contact = new Contact()
            {
                SenderId = contactDto.SenderId,
                SenderName = contactDto.SenderName,
                SenderEmail = contactDto.SenderEmail,
                Subject = contactDto.Subject,
                Message = contactDto.Message,
            };


            await _contactRepository.AddContactUsToDataBaseAsync(contact, cancellationToken);
        }
    }
}
