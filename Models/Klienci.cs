using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parts.Models
{
    public class Klienci
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string nazwa { get; set; }
        [Required]
        public string adres { get; set; }
        [Display(Name = "Email")]
        [Required]
        [MaxLength(50, ErrorMessage = "Max 50 char")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        public string email { get; set; }
        [Required]
        public string haslo { get; set; }
        [Required]
        public int nr_tel{ get; set; }
    }
}
