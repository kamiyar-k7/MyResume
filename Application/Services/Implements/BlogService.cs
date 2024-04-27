
using Application.NAmeGenerator;
using Application.Services.Intefaces;
using Application.ViewModel;
using Domain.Entities.Blog;
using Domain.IRepositoriesp;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Reflection;

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
                Id = blog.Id,
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


    #region Admin side

    public async Task<BlogViewModel> GetBlogView(int id)
    {
        var blog = await _blogRepository.Getblog(id);

        BlogViewModel model = new BlogViewModel()
        {
            Id = blog.Id,
            DateOnly = blog.DateOnly,
            Description= blog.Description,
            PictureUrl= blog.PictureUrl,
            Title = blog.Title, 
        };

        return model;
        
    }

    public async Task UpdateBlog(BlogViewModel  model)
    {
        var blog = await _blogRepository.Getblog( model.Id);

            blog.DateOnly = model.DateOnly;
            blog.Title = model.Title;
            blog.Description = model.Description;

        if (model.PictureFile != null)
        {
            if(blog.PictureUrl != null)
            {
                string oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/BlogImages", blog.PictureUrl);
                if (File.Exists(oldImagePath))
                {
                    File.Delete(oldImagePath);
                }
            }
            //Save New Image
            blog.PictureUrl = NameGenerator.GenerateUniqCode() + Path.GetExtension(model.PictureFile.FileName);

            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/BlogImages", blog.PictureUrl);
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                model.PictureFile.CopyTo(stream);
            }

        }


        _blogRepository.UpdateBlog(blog);
        await _blogRepository.savechanges();
        

    }

    public async Task AddBlog(BlogViewModel blog)
    {
      

        if (blog.PictureFile != null)
        {
          
            //Save New Image
            blog.PictureUrl = NameGenerator.GenerateUniqCode() + Path.GetExtension(blog.PictureFile.FileName);

            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/BlogImages", blog.PictureUrl);
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                blog.PictureFile.CopyTo(stream);
            }
        }

        Blog newblog = new Blog()
        {
            Description = blog.Description,
            Title = blog.Title,
            DateOnly = DateOnly.FromDateTime(DateTime.Today),
            PictureUrl = blog.PictureUrl,
        };
        await _blogRepository.AddBlog(newblog);
        await _blogRepository.savechanges();
    }

    public async Task DeleteBlog(int id)
    {
       
        await _blogRepository.DeleteBlog(id);
        await _blogRepository.savechanges();

    }
    #endregion
}
