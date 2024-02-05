using Data.Dbcontext;
using Domain.Entities._1Information.Myservices;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class MyserviceRepository : IMyserviceRepository
    {

        #region Ctor
        private readonly ResumeDbContext _Context;
        public MyserviceRepository(ResumeDbContext resumeDbContext)
        {
            _Context = resumeDbContext;
        }
        #endregion

        #region General
        public async Task<List<Myservices>> GetMyservicesAsync(CancellationToken cancellationToken)
        {
            return await _Context.Myservices.ToListAsync(cancellationToken);
        }

        public async Task SaveChanges()
        {
            await _Context.SaveChangesAsync();
        }

        public void Update(Myservices myservices)
        {
            _Context.Myservices.Update(myservices);
        }

        public void Delete(Myservices myservices)
        {
            _Context.Myservices.Remove(myservices);
        }
        #endregion

        #region Admin Side

        public Myservices GetMyserviceById(int ServiceId)
        {
            return _Context.Myservices.FirstOrDefault(x => x.ServiceId == ServiceId);
        }

        public async Task AddService(Myservices service)
        {
             await _Context.Myservices.AddAsync(service);
        }

        

        #endregion
    }
}
