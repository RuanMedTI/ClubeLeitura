using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeLeitura.ConsoleApp.Controlador;
using ClubeLeitura.ConsoleApp.Dominio;

namespace ClubeLeitura.ConsoleApp.Tela
{
    public class TelaRevista : TelaBase, ICadastravel
    {
        private ControladorRevista controladorRevista;

        public TelaRevista(ControladorRevista controlador)
        {
            controladorRevista = controlador;
        }
        override public string ObterOpcao()
        {
            //apresenta as opções
            Console.Clear();
            Console.WriteLine("Digite 1 para inserir uma revista");
            Console.WriteLine("Digite 2 para visualizar as revistas");
            Console.WriteLine("Digite 3 para editar uma revista");
            Console.WriteLine("Digite 4 para excluir uma revista");

            Console.WriteLine("Digite S para sair");

            //solicita qual opção
            string opcao = Console.ReadLine();

            return opcao;
        }

        override public void Registrar(int id)
        {
            Console.Clear();

            string resultadoValidacao = "";

            do
            {
                string colecaoRevista = ObterInputString("Digite a coleção da revista: ");

                double anoRevista = ObterInputDouble("Digite o ano da revista: ");

                double numeroRevista = ObterInputDouble("Digite o número da revista: ");

                resultadoValidacao = controladorRevista.Registrar(
                    id, colecaoRevista, anoRevista, numeroRevista);

                if (resultadoValidacao != "REVISTA_VALIDO")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(resultadoValidacao);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Revista gravada com sucesso!");
                }

                Console.ReadLine();
                Console.Clear();
                Console.ResetColor();

            } while (resultadoValidacao != "REVISTA_VALIDO");
        }

        override public void VisualizarRegistros()
        {
            Console.Clear();

            string configuracaColunasTabela = "{0,-10} | {1,-55} | {2,-35} | {3, -15}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Revista[] revistas = controladorRevista.SelecionarTodasRevistas();

            for (int i = 0; i < revistas.Length; i++)
            {
                Console.Write(configuracaColunasTabela,
                   revistas[i].id, revistas[i].colecaoRevista, revistas[i].anoRevista,
                   revistas[i].numeroRevista);

                Console.WriteLine();
            }

            if (revistas.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Nenhuma revista cadastrada!");
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        override public void EditarRegistro()
        {
            //visualiza as revistas
            Console.Clear();

            VisualizarRegistros();

            Console.WriteLine();

            //solicita qual revista irá editar
            int idSelecionado = ObterInputInt("Digite o número da revista que deseja editar: ");

            //atualiza a revista
            Registrar(idSelecionado);
        }

        override public void ExcluirRegistro()
        {
            //visualização das revistas
            Console.Clear();

            VisualizarRegistros();

            Console.WriteLine();

            //solicita qual revista excluir
            int idSelecionado = ObterInputInt("Digite o número da revista que deseja excluir: ");

            bool conseguiuExcluir = controladorRevista.Excluir(idSelecionado);

            if (conseguiuExcluir)
            {
                Console.WriteLine("Revista excluída com sucesso");
                Console.ReadLine();
            }
        }

        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Revista", "Ano da Revista", "Número");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

    }
}
