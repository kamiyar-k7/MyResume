
using Application.Services.Intefaces;
using Application.ViewModel;
using Domain.IRepositoriesp;

namespace Application.Services.Implements;

public class BlogService : IBlogServic
{
    #region Ctor
    private readonly IBlogRepository _blogRepository;
    public BlogService(IBlogRepository blogRepository)
    {
            _blogRepository = blogRepository;
    }
    #endregion

    #region Generel

    public async Task<List< BlogViewModel>> ListOfBlogs()
    {
        var blogs = await _blogRepository.GetBlogsAsync();

        List<BlogViewModel> model = new List<BlogViewModel>();

        foreach (var blog in blogs)
        {
            BlogViewModel childmodel = new BlogViewModel()
            {
                DateOnly = blog.DateOnly,
                Description = blog.Description,
                PictureUrl = blog.PictureUrl,
                Title = blog.Title,
            };
            model.Add(childmodel);  
        }

        return model;
    }
    #endregion
}
