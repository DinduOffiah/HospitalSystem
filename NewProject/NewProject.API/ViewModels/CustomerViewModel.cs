using System.ComponentModel.DataAnnotations;

namespace NewProject.API.ViewModels
{
    public class CustomerViewModel
    {
        public int AccountNumber { get; set; }
        [StringLength(50)]
        public string? LastName { get; set; }
        [StringLength(50)]
        public string? FirstName { get; set; }
    }
}
