using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parts.Models
{
    public class Zamowienia
    {   
        [Key]
        public int ID { get; set; }
        [Required]
        public int ID_klienta { get; set; }
        [Required]
        public int ID_Produktu { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "wartość nie moze byc ujemna ")]
        public int ilość { get; set; }
        [Required]
        
        public int suma_zamowienia { get; set; }
    }
}
