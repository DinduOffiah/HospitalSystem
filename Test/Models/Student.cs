using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class Student
    {
        [Key]
        public int RegNo { get; set; }
        [Display(Name = "Profile Image")]
        public byte[]? Photo { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? FirstName { get; set; }
    }
}
