﻿using Data.Dbcontext;
using Domain.Entities._3Contact;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
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
        #region General
        public async Task AddContactUsToDataBaseAsync(Contact contact, CancellationToken cancellationToken)
        {
            await _Context.contacts.AddAsync(contact, cancellationToken);
            await _Context.SaveChangesAsync();
        }
        public async Task SaveChanges()
        {
            await _Context.SaveChangesAsync();
        }
        #endregion


        #region Admin side

        public async Task<List<Contact>> GetListOfMessages()
        {
            return await _Context.contacts.OrderByDescending(x => x.SenderId).ToListAsync();
        }
        public async Task<Contact?> GetContactbyId(int id)
        {
            return await _Context.contacts.FindAsync(id);
        }
        public  void DeleteMessage(Contact contact)
        {
             _Context.contacts.Remove(contact);
        }
        #endregion
    }
}
