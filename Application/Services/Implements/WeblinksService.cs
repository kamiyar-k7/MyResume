

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

    #region admin side 

    public async Task Updatelinks(LinksViewModel model)
    {
        var links = await _repository.GetWebLinksAsync();
            
        links.TelegramUrl = model.TelegramUrl;
        links.LinkedinUrl = model.LinkedinUrl;
        links.InstagramUrl = model.InstagramUrl;
        links.GitHubmUrl = model.GitHubmUrl;

        await _repository.UpdateLinks(links);
       
    }

    #endregion
}
