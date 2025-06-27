using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicios
{
    internal class EmailInfo
    {
        public string Usuario { get; set; }
        public string Dominio { get; set; }
        public string Brasileiro { get; set; }
    
    public EmailInfo(string usuario, string dominio)
        {
            Usuario = usuario;
            Dominio = dominio;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Usuario: " + Usuario + "\n");
            sb.Append("Domínio: " + Dominio + "\n");
            sb.Append("Brasileiro: " + Brasileiro);

            return sb.ToString();
        }
    }
}
