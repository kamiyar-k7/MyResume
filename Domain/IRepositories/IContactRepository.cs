using Domain.Entities._3Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IContactRepository
    {
        Task AddContactUsToDataBaseAsync(Contact contact, CancellationToken cancellationToken);
        Task<List<Contact>> GetListOfMessages();
        Task<Contact?> GetContactbyId(int id);
        void DeleteMessage(Contact contact);
        Task SaveChanges();
    }
}
