
using Data.Dbcontext;
using Domain.Entities.Website;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class WebLinksRepository : IWebLinksRepository
{
    #region Ctor
    private readonly ResumeDbContext _dbContext;
    public WebLinksRepository(ResumeDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    #endregion

    #region General

    public async Task<WebLinks?> GetWebLinksAsync()
    {
        return await _dbContext.links.FirstOrDefaultAsync();
    }



    public async Task UpdateLinks(WebLinks webLinks )
    {
        //var links = await _dbContext.links.FindAsync(webLinks.Id);
        _dbContext.links.Update(webLinks);
      await  _dbContext.SaveChangesAsync();
    }
    #endregion
}
