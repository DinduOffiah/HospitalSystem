using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Designition { get; set; }
    }
}
