using Application.DTOs;
using Application.DTOs.AdminSide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Intefaces
{
    public interface IContactService
    {
        Task AddContactUsToDataBaseAsync(ContactDtos contactDtos, CancellationToken cancellationToken);
         Task<List<AdminSideContactDto>> ListOfMessages();
    }
}
