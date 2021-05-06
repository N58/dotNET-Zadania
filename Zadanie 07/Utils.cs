using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadanie_7.Forms;

namespace Zadanie_7
{
    public static class Utils
    {
        public static string GetFizzString(FizzNumber fizz)
        {
            // For none: result == 0
            // For 3: result == 1
            // For 5: result == 2
            // For 3 and 5: result == 3
            return fizz.Result switch
            {
                0 => "Liczba " + fizz.Number + " nie spełnia kryteriów Fizz/Buzz",
                1 => "Fizz",
                2 => "Buzz",
                3 => "FizzBuzz",
                _ => "Error",
            };
        }
    }
}
