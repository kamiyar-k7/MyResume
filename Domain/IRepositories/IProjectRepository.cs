
using Domain.Entities.Projects;

namespace Domain.IRepositories;

public interface IProjectRepository
{
    Task<List<Project>> GetProjectsAsync();

    //

    Task SaveChanges();

    Task AddProject(Project project);
    Task<Project?> GetProject(int id);
    void UpdateProject(Project project);
    Task RemoveProject(int id);


}
