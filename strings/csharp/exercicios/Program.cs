﻿using System.Collections;
using System.Runtime.InteropServices.JavaScript;
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

            //Console.WriteLine(ExtractEmailInformation("joao.silva23@yahoo.com.br"));
            //Console.WriteLine();
            //Console.WriteLine(ExtractEmailInformation("maria123@gmail.com"));
            //Console.WriteLine();
            //Console.WriteLine(ExtractEmailInformation("maria123gmail.com"));

            //Console.WriteLine(ExtractDateData("21/07/2010"));
            //Console.WriteLine();
            //Console.WriteLine(ExtractDateData("32/14/2023"));

            //Console.WriteLine(FormatDate(21, 7, 2010));
            //Console.WriteLine(FormatDate(1, 7, 2010));

            //Console.WriteLine(ValidatePassword("amerca1@"));
            //Console.WriteLine(ValidatePassword("amrca154682"));

            //Console.WriteLine(IsAnagram("anagram", "nagaram"));
            //Console.WriteLine(IsAnagram("cat", "rat"));
            
            Console.WriteLine(IsAnagram2("anagram", "nagaram"));
            Console.WriteLine(IsAnagram2("cat", "rat"));
            
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

            if (!match.Success)
            {
            throw new ArgumentException("Email inválido", nameof(email));
            }
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
            return emailInfo;
        }

        public static DateInfo ExtractDateData(string date)
        {
            string pattern = @"^(?<dia>0[1-9]|[12][0-9]|3[01])/(?<mes>0[1-9]|1[0-2])/(?<ano>\d{4})$";
            Match match = Regex.Match(date, pattern);

            DateInfo dateInfo = null;
            
            if (!match.Success)
            {
                throw new ArgumentException("Data inválida", nameof(date));
            }
            dateInfo = new DateInfo
            {
                Dia = match.Groups["dia"].Value,
                Mes = match.Groups["mes"].Value,
                Ano = match.Groups["ano"].Value
            };
            return dateInfo;
        }

        public static string FormatDate(int day, int month, int year)
        {
            string dayString = day.ToString();
            string monthString = month.ToString();
            string yearString = year.ToString();

            dayString = dayString.PadLeft(2, '0');
            monthString = monthString.PadLeft(2, '0');
            
            return $"{dayString}/{monthString}/{yearString}";
        }

        public static bool ValidatePassword(string senha)
        {
            string pattern = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@#&]).{8,}$";
            
            if (!Regex.IsMatch(senha, pattern))
            {
                return false;
            }
            return true;
        }

        public static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            var sOrder = OrdenarString(s);
            var tOrder = OrdenarString(t);
           
            return sOrder.Equals(tOrder);
        }
        
        static string OrdenarString(string input)
        {
            char[] chars = input.ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }

        static bool IsAnagram2(string s, string t)
        {
            var count = new int[26];
            foreach (char c in s)
            {
                count[c - 'a']++;
            }

            foreach (char c in t)
            {
                count[c - 'a']--;
            }

            foreach (int val in count)
            {
                if(val != 0)
                {
                 return false;   
                }
            }

            return true;
        }


    }
}
