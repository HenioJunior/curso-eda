using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicios
{
    internal class DateInfo
    {
        public string Dia { get; set; }
        public string Mes { get; set; }
        public string Ano { get; set; }

        
        override
        public string ToString()
            {
            StringBuilder sb = new StringBuilder();
            sb.Append("Dia: " + Dia + "\n");
            sb.Append("Mês: " + Mes + "\n");
            sb.Append("Ano: " + Ano + "\n");
            return sb.ToString();
        }

    }
}
