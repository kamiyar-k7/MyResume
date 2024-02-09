using Data.Dbcontext;
using Domain.Entities._1Information;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserInformationRepository : IUserInformationRepository
    {
        #region Ctor
        private readonly ResumeDbContext _resumeDbContext;
        public UserInformationRepository(ResumeDbContext resumeDbContext)
        {
            _resumeDbContext = resumeDbContext;
        }
        #endregion

        #region General

        public UserInformation? GetUserInformation()
        {
            return _resumeDbContext.Information.FirstOrDefault();
        }

        

        public void Update(UserInformation userInformation)
        {
             _resumeDbContext.Information.Update(userInformation);
        }
        public async Task Save()
        {
            await _resumeDbContext.SaveChangesAsync();
        }
        #endregion

        #region Admin Side
        public async Task<UserInformation?> GetUserById(int id)
        {
            return await _resumeDbContext.Information.FindAsync(id);

        }

        #endregion
    }
}
