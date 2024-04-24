using Microsoft.AspNetCore.Http;


namespace Application.DTOs;

public class MyServiceDto
{
    public int ServiceId { get; set; }
    public string ServiceName { get; set; }
    public string ServiceDescription { get; set; }
    public string? ServicePicture { get; set; }
    public IFormFile? pictureFile { get; set; }
}
