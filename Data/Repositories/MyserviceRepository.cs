using Data.Dbcontext;
using Domain.Entities._1Information.Myservices;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<Myservices>> GetMyservicesAsync(CancellationToken cancellationToken)
        {
            return await _Context.Myservices.ToListAsync(cancellationToken);
        }
    }
}
