using Application.DTOs;
using Application.Services.Intefaces;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implements
{
    public class MySkillService : IMySkillService
    {
        #region Ctoe
        private readonly IMySkillRepository _skillRepository;
        public MySkillService(IMySkillRepository mySkillRepository)
        {
            _skillRepository = mySkillRepository;
        }

        #endregion

        public async Task<List<MySkillDto>> MySkillDtosAsync(CancellationToken cancellationToken)
        {
            var skill = await _skillRepository.GetMyskillsAsync(cancellationToken);
            List<MySkillDto> model = new List<MySkillDto>();
            foreach (var skillDto in skill)
            {
              
                MySkillDto Childmodel = new MySkillDto()
                {
                    SkillId = skillDto.SkillId,
                    SkillName = skillDto.SkillName,
                    SkillValue = skillDto.SkillValue,
                };
                model.Add(Childmodel);
                

            }

            return model;
        }
    }
}
