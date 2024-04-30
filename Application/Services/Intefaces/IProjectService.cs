
using Application.ViewModel;


namespace Application.Services.Intefaces;

public interface IProjectService
{
    Task<List<ProjectViewModel>> ListOfProjects();

    //

   Task AddProject(ProjectViewModel project);

    Task<ProjectViewModel> FillProjectModel(int id);
    Task UpdateProject(ProjectViewModel model);
    Task RemoveProject(int Id);
}