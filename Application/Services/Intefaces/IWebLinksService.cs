

using Application.ViewModel;

namespace Application.Services.Intefaces;

public interface IWebLinksService
{
    Task<LinksViewModel> GetLinks();
}
