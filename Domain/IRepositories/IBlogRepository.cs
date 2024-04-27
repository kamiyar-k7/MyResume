
using Domain.Entities.Blog;

namespace Domain.IRepositoriesp;

public interface IBlogRepository
{
    Task<List<Blog>> GetBlogsAsync();

    //

    Task<Blog?> Getblog(int id);

    Task savechanges();

    void  UpdateBlog(Blog blog);

    Task AddBlog(Blog blog);

    Task DeleteBlog(int id);
}
