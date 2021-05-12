using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.Dominio
{
    public class Emprestimo : DominioBase
    {
        public Caixa caixa;
        public Revista revista;
        public Amigo amigo;
        public string amigoEmprestimo;
        public string caixaEmprestimo;
        public string revistaEmprestimo;

        public Emprestimo()
        {
            id = GeradorId.GerarIdEmprestimo();
        }

        public Emprestimo(int id)
        {
            this.id = id;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "EMPRESTIMO_VALIDO";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            Emprestimo c = (Emprestimo)obj;

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

