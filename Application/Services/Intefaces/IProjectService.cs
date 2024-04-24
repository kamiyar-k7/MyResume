
using Application.ViewModel;

namespace Application.Services.Intefaces;

public interface IProjectService
{
    Task<List<ProjectViewModel>> ListOfProjects();
}
