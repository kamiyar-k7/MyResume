using Data.Dbcontext;
using Domain.Entities._1Information.Myskills;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class MySkillRepository : IMySkillRepository
    {
        #region Ctor
        private readonly ResumeDbContext _context;
        public MySkillRepository(ResumeDbContext resumeDbContext)
        {
            _context = resumeDbContext;
        }
        #endregion

        public async Task<List<Myskills>> GetMyskillsAsync(CancellationToken cancellationToken)
        {
            return await _context.myskills.ToListAsync(cancellationToken); 
        }

    }
}
