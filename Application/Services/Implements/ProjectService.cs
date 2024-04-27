

using Application.NAmeGenerator;
using Application.Services.Intefaces;
using Application.ViewModel;
using Domain.Entities.Blog;
using Domain.Entities.Projects;
using Domain.IRepositories;
using System.Reflection;
using System.Reflection.Metadata;

namespace Application.Services.Implements;

public class ProjectService : IProjectService
{

	#region Ctor
	private readonly IProjectRepository _projectRepository;
    public ProjectService(IProjectRepository projectRepository)

    {
        _projectRepository = projectRepository;
            
    }
    #endregion

    #region Genereal
    public async Task<List<ProjectViewModel>> ListOfProjects()
    {
        var projects = await _projectRepository.GetProjectsAsync();

        List<ProjectViewModel> model = new List<ProjectViewModel>();
        foreach (var project in projects)
        {
            ProjectViewModel childmodel = new ProjectViewModel()
            {
                Id = project.Id,
                Description = project.Description,
                PictureUrl = project.PictureUrl,
                ProjectUrl = project.ProjectUrl,
                Title = project.Title,
            };
            model.Add(childmodel);

        }
        return model;
    }
    #endregion

    #region Admin side

    public async Task AddProject(ProjectViewModel project)
    {
        Project NewProj = new Project();


        if (project.PictureFile != null)
        {
         
            //Save New Image
            project.PictureUrl = NameGenerator.GenerateUniqCode() + Path.GetExtension(project.PictureFile.FileName);

            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/ProjectImages", project.PictureUrl);
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                project.PictureFile.CopyTo(stream);
            }
        }

        NewProj.ProjectUrl = project.ProjectUrl;
        NewProj.Title = project.Title;  
        NewProj.Description = project.Description;
        NewProj.PictureUrl = project.PictureUrl;

        await _projectRepository.AddProject(NewProj);
        await _projectRepository.SaveChanges();
    }

    public async Task<ProjectViewModel> FillProjectModel(int id)
    {
        var project = await _projectRepository.GetProject(id);

        ProjectViewModel model = new ProjectViewModel()
        {
            Id = id,
            Description = project.Description,
            PictureUrl = project.PictureUrl,
            ProjectUrl = project.ProjectUrl,
            Title = project.Title,
        };

        return model;
    }

    public async Task UpdateProject( ProjectViewModel  model)
    {
        var project = await _projectRepository.GetProject(model.Id);

        if (model.PictureFile != null)
        {
            if (project.PictureUrl != null)
            {
                string oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/BlogImages", project.PictureUrl);
                if (File.Exists(oldImagePath))
                {
                    File.Delete(oldImagePath);
                }
            }
            //Save New Image
            model.PictureUrl = NameGenerator.GenerateUniqCode() + Path.GetExtension(model.PictureFile.FileName);

            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/ProjectImages", model.PictureUrl);
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                model.PictureFile.CopyTo(stream);
            }
        }

        project.ProjectUrl = model.ProjectUrl;
        project.Title = model.Title;
        project.Description = model.Description;
        project.PictureUrl = model.PictureUrl;

        _projectRepository.UpdateProject(project);
        await _projectRepository.SaveChanges();

    }

    public async Task RemoveProject(int Id)
    {
       await  _projectRepository.RemoveProject(Id);
        await _projectRepository.SaveChanges();
    }
    #endregion

}
