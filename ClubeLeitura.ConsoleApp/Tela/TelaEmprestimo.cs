using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeLeitura.ConsoleApp.Controlador;
using ClubeLeitura.ConsoleApp.Dominio;

namespace ClubeLeitura.ConsoleApp.Tela
{
    public class TelaEmprestimo : TelaBase, ICadastravel 
    {
        private TelaCaixa telaCaixa;
        private TelaRevista telaRevista;
        private TelaAmigo telaAmigo;
        private ControladorCaixa controladorCaixa;
        private ControladorRevista controladorRevista;
        private ControladorAmigo controladorAmigo;


        public TelaEmprestimo(TelaCaixa tela, ControladorCaixa controlador,
            TelaRevista tela1, ControladorRevista controlador1, TelaAmigo tela2, ControladorAmigo 
            controlador2)
        {
            telaCaixa = tela;
            telaRevista = tela1;
            telaAmigo = tela2;
            controladorCaixa = controlador;
            controladorRevista = controlador1;
            controladorAmigo = controlador2;
        }

        override public string ObterOpcao()
        {
            Console.Clear();
            Console.WriteLine("Digite 1 para locar uma revista");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Digite 2 para visualizar os registros abertos");
            Console.ResetColor();

            
            Console.WriteLine("Digite (Finalizados) para visualizar os registros fechados");
            

            Console.WriteLine("Digite (Devolver) para devolver uma revista");



            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        override public void Registrar(int idEmprestimoSelecionado)
        {
            Console.Clear();

            Console.WriteLine("Visualização dos amigos cadastrados...");
            Console.WriteLine("------------------------------------------------------------");
            Console.ReadLine();

            telaAmigo.VisualizarRegistros();

            Console.WriteLine("Visualização das caixas cadastradas...");
            Console.WriteLine("------------------------------------------------------------");
            Console.ReadLine();

            telaCaixa.VisualizarRegistros();

            Console.WriteLine("Visualização das revistas cadastradas...");
            Console.WriteLine("------------------------------------------------------------");
            Console.ReadLine();

            telaRevista.VisualizarRegistros();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Vamos locar o livro agora...");
            Console.ReadLine();
            Console.ResetColor();

            string amigoEmprestimo = ObterInputString("Digite o nome do amigo: ");
            string caixaEmprestimo = ObterInputString("Digite a etiqueta da caixa onde o livro está: ");
            string revistaEmprestimo = ObterInputString("Digite o nome da revista: ");

            controladorEmprestimo.Registrar(idEmprestimoSelecionado, amigoEmprestimo, caixaEmprestimo, revistaEmprestimo);
        }
        override public void VisualizarRegistros()
        {
            Console.Clear();

            MontarCabecalhoTabela();

            Emprestimo[] emprestimos = controladorEmprestimo.SelecionarTodosEmprestimos();

            foreach (Emprestimo emprestimo in emprestimos)
            {
                Console.WriteLine("{0,-10} | {1,-30} | {2,-55} | {3,-25}",
                    emprestimo.id, emprestimo.amigoEmprestimo, emprestimo.caixaEmprestimo, emprestimo.revistaEmprestimo);
            }

            if (emprestimos.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Nenhuma revista locada");
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        override public void Devolver()
        {
            Console.Clear();

            Console.WriteLine("Visualização dos amigos cadastrados...");
            Console.WriteLine("------------------------------------------------------------");
            Console.ReadLine();

            telaAmigo.VisualizarRegistros();

            Console.WriteLine("Visualização das caixas cadastradas...");
            Console.WriteLine("------------------------------------------------------------");
            Console.ReadLine();

            telaCaixa.VisualizarRegistros();

            Console.WriteLine("Visualização das revistas cadastradas...");
            Console.WriteLine("------------------------------------------------------------");
            Console.ReadLine();

            telaRevista.VisualizarRegistros();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Vamos devolver o livro agora!");
            Console.ReadLine();
            Console.ResetColor();

            string amigoEmprestimoDevol = ObterInputString("Digite o nome do amigo: ");
            string caixaEmprestimoDevol = ObterInputString("Digite a etiqueta da caixa para guardar o livro: ");
            string revistaEmprestimoDevol = ObterInputString("Digite o nome da revista: ");

            controladorEmprestimo.Devolver(amigoEmprestimoDevol, caixaEmprestimoDevol, revistaEmprestimoDevol);
        }

        override public void VisualizarRegistrosAbertos()
        {
            Console.Clear();

            MontarCabecalhoTabela();

            Emprestimo[] emprestimos = controladorEmprestimo.SelecionarTodosEmprestimos();

            foreach (Emprestimo emprestimo in emprestimos)
            {
                Console.WriteLine("{0,-10} | {1,-30} | {2,-55} | {3,-25}",
                    emprestimo.id, emprestimo.amigoEmprestimoDevol, emprestimo.caixaEmprestimoDevol, emprestimo.revistaEmprestimoDevol);
            }

            if (emprestimos.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Nenhuma revista locada");
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        private static void MontarCabecalhoTabela()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-10} | {1,-30} | {2,-55} | {3,-25}", "Id", "Amigo", "Caixa", "Revista");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }
    }
}
