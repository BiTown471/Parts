using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parts.Models
{
    public class Pracownicy
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string imie { get; set; }
        public string nazwisko { get; set; }
        [Display(Name = "Email")]
        [Required]
        [MaxLength(50, ErrorMessage = "Max 50 char")]

        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        public string email { get; set; }
        [Required]
        public string haslo { get; set; }
        public int wypłata { get; set; }
        [Required]
        public int ID_pozycja  { get; set; }
    }
}
