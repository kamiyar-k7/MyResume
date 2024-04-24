
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

}
