using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.Dominio
{
    public class Revista : DominioBase
    {
        public string colecaoRevista;
        public double anoRevista;
        public double numeroRevista;

        public Revista()
        {
            id = GeradorId.GerarIdRevista();
        }

        public Revista(int id)
        {
            this.id = id;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "REVISTA_VALIDO";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            Revista c = (Revista)obj;

            if (c != null && c.id == this.id)
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return 0;
        }
    }
}


