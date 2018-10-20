using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DOTNET_CodeFirstExample.Models
{
    [Table("Projects")]
    public class Project
    {
        [Key]
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        public ICollection<ProjectJoin> GetProjectJoins { get; set; }
    }
}