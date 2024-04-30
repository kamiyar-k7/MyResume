
using Application.ViewModel;
using Data.Dbcontext;
using Domain.Entities.Projects;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ProjectRepository : IProjectRepository
{

	#region Ctor
	private readonly ResumeDbContext _dbcontext;
    public ProjectRepository(ResumeDbContext resumeDbContext)
    {
            _dbcontext = resumeDbContext;
    }

    #endregion

    #region General
    
    public async Task<List<Project>> GetProjectsAsync()
    {
        return await _dbcontext.projects.ToListAsync();
    }

    #endregion

    #region Admin side

    public async Task SaveChanges()
    {
        await _dbcontext.SaveChangesAsync();
    }

    public async Task AddProject(Project project)
    {
        await _dbcontext.projects.AddAsync(project);
    }

    public async Task<Project?> GetProject(int id)
    {
        return await _dbcontext.projects.FindAsync(id);
    }

    public void  UpdateProject(Project project)
    {
         _dbcontext.projects.Update(project);
    }

    public async Task RemoveProject(int id)
    {
       var p =  await GetProject(id);
        _dbcontext.projects.Remove(p);
    }
    #endregion
}
