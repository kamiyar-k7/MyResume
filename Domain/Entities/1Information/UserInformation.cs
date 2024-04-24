

namespace Domain.Entities._1Information;

public class UserInformation
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string TitleDescription { get; set; }
    public string Description { get; set; }
    public string Email { get; set; }
    public long MobilePhone { get; set; }
    public string Location { get; set; }
    public string? Picture { get; set; }
    public bool IsAdmin { get; set; }



}
