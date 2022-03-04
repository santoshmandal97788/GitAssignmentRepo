using System.ComponentModel.DataAnnotations;

namespace StudentCrudAPI.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MaxLength(20, ErrorMessage = "First Name Cannot exceed 20 character")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(20, ErrorMessage = "Last Name Cannot exceed 20 character")]
        public string lastName { get; set; }

        [Display(Name = "Student Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public int GenderId { get; set; }
        public string Gender { get; set; }
        public int DepartmentId { get; set; }
        public string Department { get; set; }

    }
}
