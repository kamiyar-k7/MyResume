using Domain.Entities._1Information;
using Domain.Entities._1Information.Myservices;
using Domain.Entities._1Information.Myskills;
using Domain.Entities._3Contact;
using Domain.Entities.Blog;
using Domain.Entities.Projects;
using Domain.Entities.Website;
using Microsoft.EntityFrameworkCore;

namespace Data.Dbcontext;

public class ResumeDbContext : DbContext
{
    public ResumeDbContext(DbContextOptions<ResumeDbContext> options) : base(options)
    {

    }

    public DbSet<UserInformation> Information { get; set; }
    public DbSet<Myservices> Myservices { get; set; }
    public DbSet<Myskills> myskills { get; set; }
    public DbSet<Blog> blogs { get; set; }
    public DbSet<Project> projects { get; set; }
    public DbSet<Contact> contacts { get; set; }
    public DbSet<WebLinks> links { get; set; }

}
