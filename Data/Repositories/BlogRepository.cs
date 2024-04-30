
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

    #region Admin Side

    public async Task<Blog?> Getblog(int id)
    {
        return await _dbcontext.blogs.FindAsync(id);  
    }

    public async Task savechanges()
    {
        await _dbcontext.SaveChangesAsync();
    }

    public  void UpdateBlog(Blog blog)
    {
         _dbcontext.blogs.Update(blog);
    }

    public async Task AddBlog(Blog blog)
    {
        await _dbcontext.blogs.AddAsync(blog);
    }

    public async Task DeleteBlog(int id)
    {
      var blog =  await Getblog(id);
         _dbcontext.blogs.Remove(blog);
    }

    #endregion
}
