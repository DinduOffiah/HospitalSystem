using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.DAL.Models
{
    public class Deposit
    {
        [Key]
        public int DepositId { get; set; }
        [Required]
        public long Amount { get; set;}
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
