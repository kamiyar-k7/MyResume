using Data.Dbcontext;
using Domain.Entities._3Contact;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ContactRepository : IContactRepository
    {
        #region ctor
        private readonly ResumeDbContext _Context;
        public ContactRepository(ResumeDbContext resumeDbContext)
        {
            _Context = resumeDbContext;
                
        }
          #endregion
        public async Task AddContactUsToDataBaseAsync(Contact contact, CancellationToken cancellationToken)
        {
            await _Context.contacts.AddAsync(contact , cancellationToken);
            await _Context.SaveChangesAsync();  
        }
    }
}
