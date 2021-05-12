using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeLeitura.ConsoleApp.Controlador;
using ClubeLeitura.ConsoleApp.Dominio;

namespace ClubeLeitura.ConsoleApp.Tela
{
    public class TelaCaixa : TelaBase
    {
        private ControladorCaixa controladorCaixa;

        public TelaCaixa(ControladorCaixa controlador)
        {
            controladorCaixa = controlador;
        }
        override public string ObterOpcao()
        {
            //apresenta as opções
            Console.Clear();
            Console.WriteLine("Digite 1 para inserir uma caixa de coleção");
            Console.WriteLine("Digite 2 para visualizar as caixas de coleção");
            Console.WriteLine("Digite 3 para editar uma caixa de coleção");
            Console.WriteLine("Digite 4 para excluir uma caixa de coleção");

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
                string corCaixa = ObterInputString("Digite a cor da caixa de coleções: ");

                string etiquetaCaixa = ObterInputString("Digite a etiqueta da caixa de coleções: ");

                double numeroCaixa = ObterInputDouble("Digite o número da caixa de coleções: ");

                resultadoValidacao = controladorCaixa.Registrar(
                    id, corCaixa, etiquetaCaixa, numeroCaixa);

                if (resultadoValidacao != "CAIXA_VALIDO")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(resultadoValidacao);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Caixa gravada com sucesso!");
                }

                Console.ReadLine();
                Console.Clear();
                Console.ResetColor();

            } while (resultadoValidacao != "CAIXA_VALIDO");
        }

        override public void Visualizar()
        {
            Console.Clear();

            string configuracaColunasTabela = "{0,-10} | {1,-55} | {2,-35} | {3, -15}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Caixa[] caixas = controladorCaixa.SelecionarTodasCaixas();

            for (int i = 0; i < caixas.Length; i++)
            {
                Console.Write(configuracaColunasTabela,
                   caixas[i].id, caixas[i].corCaixa, caixas[i].etiquetaCaixa,
                   caixas[i].numeroCaixa);

                Console.WriteLine();
            }

            if (caixas.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Nenhum solicitante cadastrado!");
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        override public void Editar()
        {
            //visualiza as caixas
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            //solicita qual caixa irá atualizar
            int idSelecionado = ObterInputInt("Digite o número da caixa que deseja editar: ");

            //atualiza o caixa
            Registrar(idSelecionado);
        }

        override public void Excluir()
        {
            //visualização dos caixa
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            //solicita qual caixa excluir
            int idSelecionado = ObterInputInt("Digite o número da caixa que deseja excluir: ");

            bool conseguiuExcluir = controladorCaixa.Excluir(idSelecionado);

            if (conseguiuExcluir)
            {
                Console.WriteLine("Caixa excluído com sucesso");
                Console.ReadLine();
            }
        }

        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Cor", "Etiqueta", "Número");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

    }
}
