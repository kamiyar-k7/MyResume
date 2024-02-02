using Application.Services.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers
{
    public class MySkillsController : AdminBAseController
    {
        #region Ctor
        private readonly IMySkillService _Skills;
        public MySkillsController(IMySkillService mySkillService )
        {
            _Skills = mySkillService;
                
        }
        #endregion
        public async  Task<IActionResult> ListOfSkills(CancellationToken cancellation)
        {
           var skills = await _Skills.MySkillDtosAsync(cancellation);
            return View(skills);
        }
        public IActionResult EditMySkills()
        {
            return View();
        }
    }
}
