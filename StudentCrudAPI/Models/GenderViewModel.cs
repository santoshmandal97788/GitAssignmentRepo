using System.ComponentModel.DataAnnotations;

namespace StudentCrudAPI.Models
{
    public class GenderViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}
