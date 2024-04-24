
using Domain.Entities.Blog;

namespace Domain.IRepositoriesp;

public interface IBlogRepository
{
    Task<List<Blog>> GetBlogsAsync();
}
