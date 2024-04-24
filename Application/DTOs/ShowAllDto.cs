using Microsoft.AspNetCore.Http;

namespace Application.DTOs;

public class ShowAllDto
{
    #region Information
    public int Id { get; set; }
    public string UserName { get; set; }
   
    public string TitleDescription { get; set; }
    public string Description { get; set; }
    public string Email { get; set; }
    public long MobilePhone { get; set; }
    public string Location { get; set; }
    public string? PicName { get; set; }
  
    #endregion

    

    #region Contacts


    public ContactDtos ContactDtos { get; set; }
    #endregion

}
public class ContactDtos
{
    public int SenderId { get; set; }
    public string SenderName { get; set; }
    public string SenderEmail { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
}
