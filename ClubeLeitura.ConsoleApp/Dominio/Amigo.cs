using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.Dominio
{
    public class Amigo : DominioBase
    {
        public string nomeAmigo;
        public string nomeResponsavel;
        public string enderecoAmigo;
        public double telefoneResponsavel;


        public Amigo()
        {
            id = GeradorId.GerarIdAmigo();
        }

        public Amigo(int id)
        {
            this.id = id;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "AMIGO_VALIDO";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            Amigo c = (Amigo)obj;

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

