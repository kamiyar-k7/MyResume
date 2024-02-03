using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Intefaces
{
    public interface IMySkillService
    {
        #region general
        Task<List<MySkillDto>> MySkillDtosAsync(CancellationToken cancellationToken);
        #endregion
        #region Admin side
        Task<MySkillDto> FillSkillDtoAsync(int SkillId);
        Task<bool> EditSkillDto(MySkillDto model);
        Task AddSkill(MySkillDto model);
        #endregion

    }
}
