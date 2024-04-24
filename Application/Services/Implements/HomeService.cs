

using Application.Services.Intefaces;
using Application.ViewModel;


namespace Application.Services.Implements;

public class HomeService : IHomeService
{

    #region Ctor

    private readonly IUserInformationService _User;
    private readonly IMyServicesService _Myservice;
    private readonly IMySkillService _Myskill;
    private readonly IContactService _ContactService;
    public HomeService(IUserInformationService userInformationService ,
        IMyServicesService myserviceService ,
        IMySkillService mySkillService , 
        IContactService contactService)
    {
            
        _User = userInformationService;
        _Myservice = myserviceService;
        _Myskill = mySkillService;
         _ContactService = contactService; 
    }


    public async Task<MainViewModel> HomeIndex(CancellationToken cancellationToken)
    {
        var info =  _User.GetUserInformation();
        var myservices = await _Myservice.GetMyservicesAsync(cancellationToken);
        var skills = await _Myskill.GetSkillsAsync(cancellationToken);

        MainViewModel model = new MainViewModel()
        {
            Information = info,
            ServiceViewModel = myservices ,
            skillViewModels = skills,

        };

        return model;

    }

    #endregion



}
