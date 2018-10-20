using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DOTNET_CodeFirstExample.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public string EmployeeId { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }

        public ICollection<ProjectJoin> ProjectJoins { get; set; }
    }
}