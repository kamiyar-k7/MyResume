using Application.DTOs;
using Application.ViewModel;


namespace Application.Services.Intefaces;

public interface IMySkillService
{
    #region general
    Task<List<SkillViewModel>> GetSkillsAsync(CancellationToken cancellationToken);
    #endregion

    #region Admin side
    Task<MySkillDto> FillSkillDtoAsync(int SkillId);
    Task<bool> EditSkillDto(MySkillDto model);
    Task AddSkill(MySkillDto model);
    Task<bool> DeleteSkill(int id);
    
    #endregion

}
