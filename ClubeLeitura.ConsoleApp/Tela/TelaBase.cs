using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeLeitura.ConsoleApp.Tela;
using ClubeLeitura.ConsoleApp.Controlador;

namespace ClubeLeitura.ConsoleApp.Tela
{
    abstract public class TelaBase
    {
        const int CAPACIDADE_REGISTROS = 100;

        public static ControladorCaixa controladorCaixa = new ControladorCaixa(CAPACIDADE_REGISTROS);
        public static ControladorRevista controladorRevista = new ControladorRevista(CAPACIDADE_REGISTROS);
        public static ControladorAmigo controladorAmigo = new ControladorAmigo(CAPACIDADE_REGISTROS);
        public static TelaAmigo telaAmigo = new TelaAmigo(controladorAmigo);
        public static TelaCaixa telaCaixa = new TelaCaixa(controladorCaixa);
        public static TelaRevista telaRevista = new TelaRevista(controladorRevista);

        // emprestimo aqui
        public static ControladorEmprestimo controladorEmprestimo = new ControladorEmprestimo(CAPACIDADE_REGISTROS);
        public static TelaEmprestimo telaEmprestimo = new TelaEmprestimo(telaCaixa, controladorCaixa, telaRevista,
            controladorRevista, telaAmigo, controladorAmigo);



        public virtual object ObterTela()
        {
            string opcao = "";
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Clube de Leitura");
                Console.ResetColor();

                Console.WriteLine("Digite 1 para o menu Amiguinho");
                Console.WriteLine("Digite 2 para o menu Caixa de Coleções");
                Console.WriteLine("Digite 3 para o menu Revista");
                Console.WriteLine("Digite 4 para locar uma revista");

                Console.WriteLine("Digite S para Sair");

                opcao = Console.ReadLine();

                if (opcao == "1")
                {
                    TelaAmigo tela = telaAmigo;
                    return tela;
                }

                if (opcao == "2")
                {
                    TelaCaixa tela = telaCaixa;
                    return tela;
                }
                if (opcao == "3")
                {
                    TelaRevista tela = telaRevista;
                    return tela;
                }
                if (opcao == "4")
                {
                    TelaEmprestimo tela = telaEmprestimo;
                    return tela;
                }


            } while (OpcaoInvalida(opcao));

            return null;
        }

        private bool OpcaoInvalida(string opcao)
        {
            if (opcao == "s" || opcao == "S" || opcao == "1" || opcao == "2" || opcao == "3" || opcao == "4")
            {
                return false;
            }
            return true;
        }

        public virtual void Historico()
        {

        }

        public int ObterInputInt(string mensagem)
        {
            int n;
            Console.Write(mensagem);
            Int32.TryParse(Console.ReadLine(), out n);
            return n;
        }

        public string ObterInputString(string mensagem)
        {
            string s;
            Console.Write(mensagem);
            s = Console.ReadLine();
            return s;
        }

        public double ObterInputDouble(string mensagem)
        {
            double d;
            Console.Write(mensagem);
            double.TryParse(Console.ReadLine(), out d);
            return d;

        }

        public DateTime ObterInputDateTime(string mensagem)
        {
            DateTime d = new DateTime();
            Console.Write(mensagem);
            DateTime.TryParse(Console.ReadLine(), out d);
            return d;
        }

        abstract public string ObterOpcao();

        public virtual void Registrar(int id) { }
        public virtual void VisualizarRegistros() { }
        public virtual void EditarRegistro() { }
        public virtual void ExcluirRegistro() { }

    }

}
