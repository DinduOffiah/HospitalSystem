using System.ComponentModel.DataAnnotations;

namespace BlogApplication.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Story { get; set; }
        [Required]
        public string? Image { get; set; }
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime LastModified { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
    }
}
