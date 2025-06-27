using System.Text.RegularExpressions;

namespace exercicios
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(RemoveNonDigits("87409217293"));
            //Console.WriteLine(RemoveNonDigits("874092172-93"));
            //Console.WriteLine(RemoveNonDigits("874.092.172-93"));

            Console.WriteLine(ExtractEmailInformation("joao.silva23@yahoo.com.br"));
            Console.WriteLine();
            Console.WriteLine(ExtractEmailInformation("maria123@gmail.com"));

        }

        static string RemoveNonDigits(string str)
        {
            Regex regex = new Regex(@"\D");
            return regex.Replace(str, "");
        }

        public static EmailInfo ExtractEmailInformation(string email)
        {
            string pattern = @"^(?<usuario>[^@]+)@(?<dominio>[a-zA-Z0-9.-]+\.[a-zA-Z]{2,})$";
            Match match = Regex.Match(email,pattern);
            EmailInfo emailInfo = null;

            if (match.Success)
            {
                emailInfo = new EmailInfo(
                    match.Groups["usuario"].Value,
                    match.Groups["dominio"].Value
                );
                if (emailInfo.Dominio.EndsWith(".br"))
                {
                emailInfo.Brasileiro = "Sim";
                }
                else
                {
                    emailInfo.Brasileiro = "Não";

                }


            }
            return emailInfo ?? new EmailInfo("Usuario não encontrado", "Dominio não encontrado");

        }


    }
}
