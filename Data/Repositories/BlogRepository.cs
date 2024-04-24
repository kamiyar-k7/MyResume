
using Data.Dbcontext;
using Domain.Entities.Blog;
using Domain.IRepositoriesp;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class BlogRepository : IBlogRepository
{
	#region Ctor
	private readonly ResumeDbContext _dbcontext;
    public BlogRepository(ResumeDbContext resumeDbContext)
    {
            _dbcontext  = resumeDbContext;
    }
    #endregion

    public async Task<List<Blog>> GetBlogsAsync()
    {
        return await _dbcontext.blogs.ToListAsync();

    }
}
