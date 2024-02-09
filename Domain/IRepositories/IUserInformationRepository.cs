using Domain.Entities._1Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IUserInformationRepository
    {
        #region General
        UserInformation GetUserInformation();
         Task<UserInformation?> GetUserById(int id);
        Task<bool?> CheckAdmin(UserInformation userInformation);
        void Update(UserInformation userInformation);
        Task Save();
        #endregion

    }
}
