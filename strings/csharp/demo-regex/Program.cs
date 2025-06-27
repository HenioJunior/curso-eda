using System.Runtime.Intrinsics.X86;
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

            //Console.WriteLine(RemoveNonDigits("94923784799"));       // 94923784799
            //Console.WriteLine(RemoveNonDigits("213.445.034-82"));    // 21344503482

            //Console.WriteLine(ValidateBrDomain("batata.com.br"));
            //Console.WriteLine(ValidateBrDomain("batata.com")); // false

            //Console.WriteLine(ValidateBrDomain("batata.com.br"));     // true
            //Console.WriteLine(ValidateBrDomain("banana.org.br"));     // true
            //Console.WriteLine(ValidateBrDomain("site.gov.br"));       // true
            //Console.WriteLine(ValidateBrDomain("invalido.com"));      // false
            //Console.WriteLine(ValidateBrDomain("outro.br"));          // false
            //Console.WriteLine(ValidateBrDomain("123.com.br"));        // true
            //Console.WriteLine(ValidateBrDomain("-errado.com.br"));    // false

            string text = "Para mais informações, contate-nos em contato@exemplo.com ou suporte@exemplo.com.br.";

            var emails = FindEmails(text);

            if (emails.Length > 0)
            {
                Console.WriteLine("Emails encontrados: " + emails);
            }
            else
            {
                Console.WriteLine("Nenhum email encontrado.");
            }

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

        static bool ValidateBrDomain(string domain)
        {
        Regex regex = new Regex(@"\.br$");
            return regex.IsMatch(domain);
        }

        static bool ValidateDomain(string domain)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9]+(-?[a-zA-Z0-9]+)*\.(com|org|gov)\.br$");
            return regex.IsMatch(domain);
        }

        //^[a-zA-Z0-9]+(-?[a-zA-Z0-9]+)* → nome do domínio, com opção de hífen no meio (mas não no início/fim).

        //^ → Início da string.

        //[a-zA-Z0-9]+ → Um ou mais caracteres alfanuméricos (letras ou números).

        //Isso significa que o domínio deve começar com uma letra ou número(ex: batata, loja123, x9).

        //(-?[a-zA-Z0-9]+)* → Permite hífens no meio do nome, mas não no início ou fim (ex: loja-123, batata-doce).

        // -? → Um hífen opcional(o hífen pode ou não aparecer).

        // [a-zA-Z0-9]+ → uma ou mais letras ou números.

        //* → Esse grupo pode se repetir zero ou mais vezes.

        //\.(com|org|gov)\.br$ → termina com um dos domínios válidos brasileiros.


        static string FindEmails(string texto) 
        {
        Regex regex = new Regex(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}");
            MatchCollection matches = regex.Matches(texto);
            return string.Join(", ", matches.Select(m => m.Value));
        }
    }
}
