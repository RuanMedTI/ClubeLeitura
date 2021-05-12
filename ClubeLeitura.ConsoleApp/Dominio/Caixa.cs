using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.Dominio
{
    public class Caixa : DominioBase
    {
        public string corCaixa;
        public string etiquetaCaixa;
        public double numeroCaixa;

        public Caixa()
        {
            id = GeradorId.GerarIdCaixa();
        }

        public Caixa(int id)
        {
            this.id = id;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "CAIXA_VALIDO";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            Caixa c = (Caixa)obj;

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
