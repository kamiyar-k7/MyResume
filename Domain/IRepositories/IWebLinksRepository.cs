
using Domain.Entities.Website;

namespace Domain.IRepositories;

public interface IWebLinksRepository
{
    Task<WebLinks?> GetWebLinksAsync();
}
