using Application.DTOs.UserSide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Intefaces
{
    public interface IMySkillService
    {
        Task<List<MySkillDto>> MySkillDtosAsync(CancellationToken cancellationToken);
    }
}
