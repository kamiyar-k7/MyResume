using Application.DTOs.UserSide;
using Application.Services.Implements;
using Application.Services.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.ViewComponents
{
    public class MySkillViewComponent : ViewComponent
    {
        #region Ctor
        private readonly IMySkillService _skillService;
        public MySkillViewComponent( IMySkillService mySkillService)
        {
                _skillService = mySkillService;
        }
        #endregion

        public async Task<IViewComponentResult> InvokeAsync( CancellationToken cancellationToken)
        {
            var skill = await _skillService.MySkillDtosAsync(cancellationToken);
            return View("MySkill", skill);

        }

    }
}
