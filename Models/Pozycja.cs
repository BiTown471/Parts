using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parts.Models
{
    public class Pozycja
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string nazwa { get; set; }
    }
}
