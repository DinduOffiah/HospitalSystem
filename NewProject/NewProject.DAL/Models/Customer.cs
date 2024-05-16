using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.DAL.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int AccountNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }
    }
}
