

using Application.Services.Intefaces;
using Application.ViewModel;
using Domain.IRepositories;

namespace Application.Services.Implements;

public class WeblinksService : IWebLinksService
{
	#region Ctor
	private readonly IWebLinksRepository _repository;
    public WeblinksService(IWebLinksRepository webLinksRepository)
    {
            _repository = webLinksRepository;
    }
    #endregion

    #region General
    public async Task<LinksViewModel> GetLinks()
    {
        var links = await _repository.GetWebLinksAsync();

        LinksViewModel linksViewModel = new LinksViewModel()
        {
            GitHubmUrl = links.GitHubmUrl,
            InstagramUrl = links.InstagramUrl,
            LinkedinUrl = links.LinkedinUrl,
            TelegramUrl = links.TelegramUrl,
        };

        return linksViewModel;  

    }
    #endregion
}
