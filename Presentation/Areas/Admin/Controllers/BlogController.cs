using Application.Services.Intefaces;
using Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers;

public class BlogController : AdminBaseController
{
    #region Ctor
    private readonly IBlogServic _blogServic;
    public BlogController(IBlogServic blogServic )
    {
        _blogServic = blogServic;
    }
    #endregion


    public async  Task<IActionResult> ListOfBlogs()
    {
        var model = await _blogServic.ListOfBlogs();

        return View(model);
    }

    #region Edit blog
    [HttpGet]
    public async Task<IActionResult> EditBlog(int Id)
    {
        var model = await _blogServic.GetBlogView(Id);
        return View(model);

    }

    [HttpPost , ValidateAntiForgeryToken]
    public async Task<IActionResult> EditBlog(BlogViewModel model)
    {
       await _blogServic.UpdateBlog(model);
       return RedirectToAction(nameof(ListOfBlogs));

    }
    #endregion

    #region Add Blog
    [HttpGet]
    public async Task<IActionResult> AddBlog( )
    {
        return View();
    }

    [HttpPost , ValidateAntiForgeryToken]
    public async Task<IActionResult> AddBlog(BlogViewModel model)
    {
        if(ModelState.IsValid)
        {

          await _blogServic.AddBlog(model);
            return RedirectToAction(nameof(ListOfBlogs));
        }
        else
        {
            return View(model);
        }
      
    }
    #endregion

    public async Task<IActionResult> DeleteBlog(int Id)
    {
        await  _blogServic.DeleteBlog(Id);

        return RedirectToAction(nameof(ListOfBlogs));


    }
}
