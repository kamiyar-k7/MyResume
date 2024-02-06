using Application.DTOs;
using Application.Services.Intefaces;
using Domain.Entities._1Information.Myskills;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Presentation.Areas.Admin.Controllers
{
    public class MySkillsController : AdminBaseController
    {
        #region Ctor
        private readonly IMySkillService _Skills;
        public MySkillsController(IMySkillService mySkillService)
        {
            _Skills = mySkillService;

        }
        #endregion

        #region List of skills 
        public async Task<IActionResult> ListOfSkills(CancellationToken cancellation)
        {
            var skills = await _Skills.MySkillDtosAsync(cancellation);
            return View(skills);
        }
        #endregion

        #region Edit skills 
        [HttpGet]
        public async Task<IActionResult> EditMySkills(int SkillId)
        {
            var skill = await _Skills.FillSkillDtoAsync(SkillId);
            return View(skill);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMySkills(MySkillDto mySkillDto)
        {

            var res = await _Skills.EditSkillDto(mySkillDto);
            if (res)
            {
                return RedirectToAction(nameof(ListOfSkills));
            }

            return View(mySkillDto);
        }
        #endregion

        #region Add Skills 

        [HttpGet]
        public async Task<IActionResult> AddSkill()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSkill(MySkillDto mySkillDto)
        {
            if (ModelState.IsValid)
            {
                await _Skills.AddSkill(mySkillDto);
                return RedirectToAction(nameof(ListOfSkills));
            }
            return View(mySkillDto);
        }


        #endregion

        #region Delete Skill
      
       
        public async Task<IActionResult> DeleteSkill(int SkillId)
        {
            
               var res =  await _Skills.DeleteSkill(SkillId);
                if (res)
                {
                    return RedirectToAction(nameof(ListOfSkills));
                }
        
            return RedirectToAction(nameof(ListOfSkills));

        }
        #endregion
    }
}
