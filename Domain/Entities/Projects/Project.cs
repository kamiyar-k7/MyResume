
namespace Domain.Entities.Projects;

public class Project
{
    public int Id { get; set; } 
    public string Title { get; set; }
    public string Description { get; set; }
    public string ProjectUrl { get; set; }
    public string PictureUrl { get; set; }
}
