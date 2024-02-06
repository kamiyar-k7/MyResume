using Application.DTOs;
using Application.DTOs.AdminSide;
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

        #region General
        public async Task AddContactUsToDataBaseAsync(ContactDtos contactDto, CancellationToken cancellationToken)
        {

            Contact contact = new Contact()
            {
                SenderId = contactDto.SenderId,
                SenderName = contactDto.SenderName,
                SenderEmail = contactDto.SenderEmail,
                Subject = contactDto.Subject,
                Message = contactDto.Message,
                DateTime = DateTime.Now,

            };


            await _contactRepository.AddContactUsToDataBaseAsync(contact, cancellationToken);
        }
        #endregion

        #region Admin Side

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
    }
}
