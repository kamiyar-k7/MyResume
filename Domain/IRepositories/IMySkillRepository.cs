using Domain.Entities._1Information.Myskills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{

    public interface IMySkillRepository
    {
        #region General
        Task<List<Myskills>> GetMyskillsAsync(CancellationToken cancellationToken);
        Task SaveChanges();
        void Update(Myskills myskills);
            
        #endregion

        #region Admin side
        Task<Myskills?> GetSkillById(int SkillId);
        Task AddSkillToDatabase(Myskills myskills);
        Task DeleteSkill(Myskills myskills);
        #endregion


    }
}
