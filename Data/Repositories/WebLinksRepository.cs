
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

    #endregion
}
