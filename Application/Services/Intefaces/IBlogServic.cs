
using Application.ViewModel;

namespace Application.Services.Intefaces;

public interface IBlogServic
{
    Task<List<BlogViewModel>> ListOfBlogs();
}
