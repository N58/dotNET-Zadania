using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Podaj liczbę: ");
                    var number = int.Parse(Console.ReadLine());
                    string result = "";
                    if (number % 3 == 0)
                        result += "Fizz";
                    if (number % 5 == 0)
                        result += "Buzz";

                    result = string.IsNullOrEmpty(result) ? number.ToString() : result;
                    Console.WriteLine(result);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Musisz podać liczbę całkowitą!");
                }
            }
        }
    }
}
