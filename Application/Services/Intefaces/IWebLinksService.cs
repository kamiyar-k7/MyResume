

using Application.ViewModel;

namespace Application.Services.Intefaces;

public interface IWebLinksService
{
    Task<LinksViewModel> GetLinks();
    Task Updatelinks(LinksViewModel model);
}
