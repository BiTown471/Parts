using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parts.Models
{
    public class Produkty
    {
        [Key]
        public int ID { get; set; }
        [DisplayName("Nazwa:")]
        public string nazwa { get; set; }
        [DisplayName("Cena:")]
        [Required]
        public int cena { get; set; }
        [DisplayName("Ilość magazynowa:")]
        [Required]
        [Range(0,int.MaxValue,ErrorMessage ="wartość nie moze byc ujemna ")]
        public int ilość_magazynowa { get; set; }
       
    }
}
