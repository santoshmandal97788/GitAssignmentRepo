using System.ComponentModel.DataAnnotations;

namespace StudentCrudAPI.Models
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
    }
}
