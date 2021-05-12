using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeLeitura.ConsoleApp.Controlador;
using ClubeLeitura.ConsoleApp.Dominio;

namespace ClubeLeitura.ConsoleApp.Tela
{
    public class TelaAmigo : TelaBase
    {
        private ControladorAmigo controladorAmigo;

        public TelaAmigo(ControladorAmigo controlador)
        {
            controladorAmigo = controlador;
        }
        override public string ObterOpcao()
        {
            //apresenta as opções
            Console.Clear();
            Console.WriteLine("Digite 1 para cadastrar um amigo");
            Console.WriteLine("Digite 2 para visualizar os amigos");
            Console.WriteLine("Digite 3 para editar um amigo já cadastrado");
            Console.WriteLine("Digite 4 para excluir um amigo");

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
                string nomeAmigo = ObterInputString("Digite o nome do amigo que irá entrar no clube: ");

                string enderecoAmigo = ObterInputString("Digite o endereço do amiguinho: ");

                string nomeResponsavel = ObterInputString("Nome do responsável: ");

                double telefoneResponsavel = ObterInputDouble("Telefone do responsável: ");

                resultadoValidacao = controladorAmigo.Registrar(
                    id, nomeAmigo, enderecoAmigo, nomeResponsavel, telefoneResponsavel);

                if (resultadoValidacao != "AMIGO_VALIDO")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(resultadoValidacao);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Amigo gravado com sucesso!");
                }

                Console.ReadLine();
                Console.Clear();
                Console.ResetColor();

            } while (resultadoValidacao != "AMIGO_VALIDO");
        }

        override public void Visualizar()
        {
            Console.Clear();

            string configuracaColunasTabela = "{0,-10} | {1,-20} | {2,-35} | {3, -15} | {4, -5}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Amigo[] amigos = controladorAmigo.SelecionarTodosAmigos();

            for (int i = 0; i < amigos.Length; i++)
            {
                Console.Write(configuracaColunasTabela,
                   amigos[i].id, amigos[i].nomeAmigo, amigos[i].enderecoAmigo,
                   amigos[i].nomeResponsavel, amigos[i].telefoneResponsavel);

                Console.WriteLine();
            }

            if (amigos.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Nenhum amigo cadastrado!");
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        override public void Editar()
        {
            //visualiza os amigos
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            //solicita qual amigo irá atualizar
            int idSelecionado = ObterInputInt("Digite o número do amigo que deseja editar: ");

            //atualiza o amigo
            Registrar(idSelecionado);
        }

        override public void Excluir()
        {
            //visualização dos amigos
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            //solicita qual amigo excluir
            int idSelecionado = ObterInputInt("Digite o número do amigo que deseja excluir: ");

            bool conseguiuExcluir = controladorAmigo.Excluir(idSelecionado);

            if (conseguiuExcluir)
            {
                Console.WriteLine("Amigo excluído com sucesso");
                Console.ReadLine();
            }
        }

        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            //Console.WriteLine(configuracaoColunasTabela, "Id", "Amigo", "Responsável", "Endereço", "Telefone");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

    }
}

