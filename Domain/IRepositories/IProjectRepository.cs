
using Domain.Entities.Projects;

namespace Domain.IRepositories;

public interface IProjectRepository
{
    Task<List<Project>> GetProjectsAsync();
}
