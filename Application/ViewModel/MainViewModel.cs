

using Microsoft.AspNetCore.Http;

namespace Application.ViewModel;

public class MainViewModel
{
    public InformationViewModel Information { get; set; }
    public List<ServiceViewModel> ServiceViewModel { get; set; }
    public List<SkillViewModel> skillViewModels { get; set; }
    public List<BlogViewModel> blogViewModels { get; set; }
    public List<ProjectViewModel> projectViewModels { get; set; }
    public ContactViewMdodel ContactViewMdodel { get; set; }
    public LinksViewModel linksViewModel { get; set; }
}


public record InformationViewModel
{
 
    public int Id { get; set; }
    public string UserName { get; set; }

    public string TitleDescription { get; set; }
    public string Description { get; set; }
    public string Email { get; set; }
    public long MobilePhone { get; set; }
    public string Location { get; set; }
    public string? PicName { get; set; }


}

public record ServiceViewModel
{
    public int ServiceId { get; set; }
    public string ServiceName { get; set; }
    public string ServiceDescription { get; set; }
    public string? ServicePicture { get; set; }
    public IFormFile? pictureFile { get; set; }



}

public record SkillViewModel
{
    public int SkillId { get; set; }
    public string SkillName { get; set; }
    public int SkillValue { get; set; }
}

public record ContactViewMdodel
{
    public int SenderId { get; set; }
    public string SenderName { get; set; }
    public string SenderEmail { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
}

public record BlogViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateOnly DateOnly { get; set; }
    public string? PictureUrl { get; set; }
    public IFormFile PictureFile { get; set; }

}

public record ProjectViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ProjectUrl {get; set;}
    public string? PictureUrl { get; set; }
    public IFormFile PictureFile { get; set; }

}

public record LinksViewModel
{
    public int Id { get; set; }
    public string InstagramUrl { get; set; }
    public string TelegramUrl { get; set; }
    public string LinkedinUrl { get; set; }
    public string GitHubmUrl { get; set; }
}