using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DOTNET_CodeFirstExample.Models
{
    public class ProjectManagement : DbContext
    {
        public ProjectManagement() : base("ProjectManager")
        {

        }
        public DbSet<Project> Project { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<ProjectJoin> ProjectJoin { get; set; }
    }
}