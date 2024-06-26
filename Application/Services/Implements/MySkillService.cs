﻿using Application.DTOs;
using Application.Services.Intefaces;
using Application.ViewModel;
using Domain.Entities._1Information.Myskills;
using Domain.IRepositories;

namespace Application.Services.Implements;

public class MySkillService : IMySkillService
{
    #region Ctoe
    private readonly IMySkillRepository _skillRepository;
    public MySkillService(IMySkillRepository mySkillRepository)
    {
        _skillRepository = mySkillRepository;
    }

    #endregion

    #region general

    public async Task<List<SkillViewModel>> GetSkillsAsync(CancellationToken cancellationToken)
    {
        var skill = await _skillRepository.GetMyskillsAsync(cancellationToken);
        List<SkillViewModel> model = new List<SkillViewModel>();
        foreach (var skillDto in skill)
        {

            SkillViewModel Childmodel = new SkillViewModel()
            {
                SkillId = skillDto.SkillId,
                SkillName = skillDto.SkillName,
                SkillValue = skillDto.SkillValue,
            };
            model.Add(Childmodel);


        }

        return model;
    }
    #endregion

    #region Admin side

 

    #region Edit skill 
    public async Task<MySkillDto> FillSkillDtoAsync(int SkillId)
    {

        #region Get skill by id 

        var skill = await _skillRepository.GetSkillById(SkillId);
        // var skill = await GetSkillByID(SkillId);
        if (skill == null) { return null; }


        #endregion

        #region Fill Dto


        MySkillDto myskills = new MySkillDto()
        {
            SkillId = skill.SkillId,
            SkillName = skill.SkillName,
            SkillValue = skill.SkillValue,

        };


        return myskills;
        #endregion

    }

    public async Task<bool> EditSkillDto(MySkillDto model)
    {

        #region Get skil by id 
        var user = await _skillRepository.GetSkillById(model.SkillId);
        //    var user =  GetSkillByID(model.SkillId);
        if (user == null) { return false; }

        #endregion


        #region update skill 


        user.SkillName = model.SkillName;
        user.SkillValue = model.SkillValue;

        #endregion

        _skillRepository.Update(user);
        await _skillRepository.SaveChanges();
        return true;


    }
    #endregion

    #region Add Skill

    public async Task AddSkill(MySkillDto model)
    {

        Myskills myskills = new Myskills()
        {
           
            SkillName = model.SkillName,
            SkillValue = model.SkillValue,
        };

        await _skillRepository.AddSkillToDatabase(myskills);
        await _skillRepository.SaveChanges();
    }
    #endregion

    #region Delete Skill 

    public async Task<bool> DeleteSkill(int id)
    {

        #region get user by id 

        var user = await _skillRepository.GetSkillById(id);
        if (user == null) { return false; }

        #endregion

        await _skillRepository.DeleteSkill(user);
        await _skillRepository.SaveChanges();

        return true;

    }

    #endregion


    #endregion
}
