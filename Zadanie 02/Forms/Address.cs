using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zadanie2.Forms
{
    public class Address
    {
        [Display(Name = "Moja ulica"), Required(ErrorMessage = "Musisz podać ulicę!")]
        public string Street { get; set; }
        [Display(Name = "Kod pocztowy"), Required(ErrorMessage = "Musisz podać kod pocztowy!")]
        public string ZipCode { get; set; }
        [Display(Name = "Miasto"), Required(ErrorMessage = "Musisz podać miasto!")]
        public string City { get; set; }
        [Display(Name = "Numer"), Required(ErrorMessage = "Musisz podać numer domu!")]
        public int Number { get; set; }

    }
}
