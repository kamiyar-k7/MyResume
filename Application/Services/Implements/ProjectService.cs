

using Application.Services.Intefaces;
using Application.ViewModel;
using Domain.IRepositories;

namespace Application.Services.Implements;

public class ProjectService : IProjectService
{

	#region Ctor
	private readonly IProjectRepository _projectRepository;
    public ProjectService(IProjectRepository projectRepository)

    {
        _projectRepository = projectRepository;
            
    }
    #endregion

    public async Task <List<ProjectViewModel>> ListOfProjects()
    {
        var projects = await _projectRepository.GetProjectsAsync();

        List<ProjectViewModel > model = new List<ProjectViewModel>();
        foreach (var project in projects)
        {
            ProjectViewModel childmodel = new ProjectViewModel()
            {
                Description = project.Description,
                PictureUrl = project.PictureUrl,
                ProjectUrl = project.ProjectUrl,
                Title = project.Title,
            };
            model.Add(childmodel);

        }
        return model;
    }
}
