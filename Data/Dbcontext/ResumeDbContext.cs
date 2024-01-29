using Domain.Entities._1Information;
using Domain.Entities._1Information.Myservices;
using Domain.Entities._1Information.Myskills;
using Domain.Entities._3Contact;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dbcontext
{
    public class ResumeDbContext : DbContext
    {
        public ResumeDbContext(DbContextOptions<ResumeDbContext> options) : base(options)
        {

        }

        public DbSet<UserInformation> Information { get; set; }
        public DbSet<Myservices> Myservices { get; set; }
        public DbSet<Myskills> myskills { get; set; }
        public DbSet<Contact> contacts { get; set; }

    }
}
