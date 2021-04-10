using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zadanie_4.Forms
{
    public class FizzNumber
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Musisz podać liczbę!")]
        [Range(1, 1000, ErrorMessage = "Liczba musi być z zakresu od 1 do 1000")]
        [Display(Name = "Liczba")]
        public int? Number { get; set; }

        [Display(Name = "Wynik")]
        public int Result { get; set; }

        [Display(Name = "Data")]
        public DateTime DateTime { get; set; }
    }
}
