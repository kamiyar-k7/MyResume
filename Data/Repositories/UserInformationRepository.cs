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

        public UserInformation GetUserInformation()
       
            {

            var information = _resumeDbContext.Information
                .Select(x => new UserInformation
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    TitleDescription = x.TitleDescription,
                    Description = x.Description,
                    Email = x.Email,
                    MobilePhone = x.MobilePhone,
                    Location = x.Location,
                    Picture = x.Picture,
                    Resume = x.Resume,
                    
                })
                .FirstOrDefault();

            return information;

        }

        #region Login 

        public async Task<bool?> CheckAdmin(UserInformation userInformation)
        {
            var admin = await _resumeDbContext.Information.FirstOrDefaultAsync(x => x.Id == userInformation.Id && x.Password == userInformation.Password);
            if (admin == null) { return false; }
            return true;

        }

        #endregion

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
        public UserInformation? GetUserInformationAdminSide()

        {

           return  _resumeDbContext.Information.FirstOrDefault();

            

        }
        public async Task<UserInformation?> GetUserById(int id)
        {
            return await _resumeDbContext.Information.FindAsync(id);

        }

        #endregion
    }
}
