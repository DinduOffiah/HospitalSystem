using System.ComponentModel.DataAnnotations;

namespace Test.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
