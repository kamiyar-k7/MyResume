

using Application.Services.Intefaces;
using Application.ViewModel;


namespace Application.Services.Implements;

public class HomeService : IHomeService
{

    #region Ctor

    private readonly IUserInformationService _User;
    private readonly IMyServicesService _Myservice;
    private readonly IMySkillService _Myskill;
    private readonly IBlogServic _blog;
    private readonly IProjectService _project;
  private readonly IWebLinksService _weblinks;

    public HomeService(IUserInformationService userInformationService ,
        IMyServicesService myserviceService ,
        IMySkillService mySkillService ,
        IBlogServic blogServic ,
        IProjectService projectService ,
        IWebLinksService webLinksService
       )
    {
            
        _User = userInformationService;
        _Myservice = myserviceService;
        _Myskill = mySkillService;
        _blog = blogServic;
        _project = projectService;
        _weblinks = webLinksService;
    }


    public async Task<MainViewModel> HomeIndex(CancellationToken cancellationToken)
    {
        var info =  _User.GetUserInformation();
        var myservices = await _Myservice.GetMyservicesAsync(cancellationToken);
        var skills = await _Myskill.GetSkillsAsync(cancellationToken);
        var blog = await _blog.ListOfBlogs();
        var project = await _project.ListOfProjects();
        var links = await _weblinks.GetLinks();

        MainViewModel model = new MainViewModel()
        {
            Information = info,
            ServiceViewModel = myservices ,
            skillViewModels = skills,
            blogViewModels = blog,
           projectViewModels = project,
           linksViewModel = links
        };

        return model;

    }

    #endregion



}
