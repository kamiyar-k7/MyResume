using Application.Services.Intefaces;
using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers;

public class ProjectController : AdminBaseController
{

	#region Ctor
	private readonly IProjectService _projectService;
    public ProjectController(IProjectService projectService)
    {
            _projectService = projectService;
    }
    #endregion

    public async Task<IActionResult> ListOfProjects()
	{
        var projects = await _projectService.ListOfProjects();

		return View(projects);
	}

    #region Add Project


    [HttpGet]
    public   IActionResult AddProject()
    {
        return View();
    }

    [HttpPost , ValidateAntiForgeryToken]
    public async Task<IActionResult> AddProject(ProjectViewModel model)
    {
        if(ModelState.IsValid)
        {
            await _projectService.AddProject(model);
            return RedirectToAction(nameof(ListOfProjects));
         
        }

        return View(model);
    }

    #endregion

    #region Edit Project

    
    [HttpGet]
    public async Task<IActionResult> EditProject(int id)
    {
        var model = await _projectService.FillProjectModel(id); 

        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> EditProject(ProjectViewModel model)
    {
        if (ModelState.IsValid)
        {
            await _projectService.UpdateProject(model);
            return RedirectToAction(nameof(ListOfProjects));

        }

        return View(model);
    }
    #endregion

    [HttpGet]
    public async Task<IActionResult> DeleteProject(int Id)
    {
        await _projectService.RemoveProject(Id);
        return RedirectToAction(nameof(ListOfProjects));
    }
}
