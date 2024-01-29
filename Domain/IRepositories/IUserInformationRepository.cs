using Domain.Entities._1Information;
using Domain.Entities._1Information.Myskills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IUserInformationRepository
    {
        UserInformation  GetUserInformation();
        List<Myskills> myskills();
    }
}
