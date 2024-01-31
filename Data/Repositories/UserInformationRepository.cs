using Data.Dbcontext;
using Domain.Entities._1Information;
using Domain.IRepositories;
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

        public UserInformation  GetUserInformation()
        {
            return _resumeDbContext.Information.FirstOrDefault();
        }

    }
}
