using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeLeitura.ConsoleApp.Tela;

namespace ClubeLeitura.ConsoleApp
{
    class Program
    {
        const int CAPACIDADE_REGISTROS = 100;

        static void Main(string[] args)
        {
            TelaBase telaBase = new TelaCaixa(null);

            ICadastravel d = new TelaAmigo(null);

            Console.Clear();

            while (true)
            {

                TelaBase tela = (TelaBase)telaBase.ObterTela();


                if (tela == null)
                {
                    break;
                }

                string opcao = tela.ObterOpcao();

                if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    continue;

                Console.Clear();

                if (opcao == "1")
                    tela.Registrar(0);

                else if (opcao == "2")
                    tela.VisualizarRegistros();

                else if (opcao == "3")
                    tela.EditarRegistro();

                else if (opcao == "4")
                    tela.ExcluirRegistro();

                else if (opcao == "5")
                    tela.Historico();

                else if (opcao == "Devolver")
                    tela.Devolver(0);

                else if (opcao == "Abertos")
                    tela.VisualizarRegistrosAbertos();

                Console.Clear();
            }
        }
    }
}
