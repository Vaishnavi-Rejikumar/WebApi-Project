using System.ComponentModel.DataAnnotations;

namespace Web.Models.Entities
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        public required string DepartmentName { get; set; }
    }
}

