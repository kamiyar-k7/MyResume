
using Application.ViewModel;

namespace Application.Services.Intefaces;

public interface IBlogServic
{
    Task<List<BlogViewModel>> ListOfBlogs();

    //
    Task<BlogViewModel> GetBlogView(int id);
    Task UpdateBlog(BlogViewModel model);

    Task AddBlog(BlogViewModel blog);
    Task DeleteBlog(int id);
}
