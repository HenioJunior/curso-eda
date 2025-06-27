using System.Text.RegularExpressions;

namespace demo_regex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(ValidateCEP("12345-678")); // true
            //Console.WriteLine(ValidateCEP("12345678"));  // true
            //Console.WriteLine(ValidateCEP("1234-5678"));

            Console.WriteLine(RemoveNonDigits("94923784799"));       // 94923784799
            Console.WriteLine(RemoveNonDigits("213.445.034-82"));    // 21344503482

        }

        static bool ValidateCEP(string cep)
        {
            Regex regex = new Regex(@"^\d{5}-?\d{3}$");
            return regex.IsMatch(cep);
        }

        //Usamos System.Text.RegularExpressions.Regex para trabalhar com expressões regulares.
        //A regex ^\d{5}-?\d{3}$ continua a mesma: permite CEP com ou sem hífen (ex: "12345-678" ou "12345678").


        static string RemoveNonDigits(string input)
        {
            Regex regex = new Regex(@"\D"); // \D corresponde a qualquer caractere que não seja dígito
            return regex.Replace(input, "");
        }
    }
}
