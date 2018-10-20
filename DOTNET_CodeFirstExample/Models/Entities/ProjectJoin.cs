using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DOTNET_CodeFirstExample.Models
{
    [Table("ProjectJoin")]
    public class ProjectJoin
    {
        [Key]
        public int PropjectJoinId { get; set; }
        [ForeignKey("Employee")]
        public string EmployeeId { get; set; }
        [ForeignKey("Project")]
        public string ProjectId { get; set; }
        public DateTime StarDate { get; set; }
        public DateTime? FinishDate { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Project  Project { get; set; }
    }
}