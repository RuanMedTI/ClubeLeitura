using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeLeitura.ConsoleApp.Dominio;

namespace ClubeLeitura.ConsoleApp.Controlador
{
    public class ControladorEmprestimo : ControladorBase
    {
        public ControladorEmprestimo(int capacidade_registros) : base(capacidade_registros) { }

        public string Registrar(int id, string amigoEmprestimo, string caixaEmprestimo, string revistaEmprestimo)
        {
            Emprestimo emprestimo = null;

            int posicao = 0;

            if (id == 0)
            {
                emprestimo = new Emprestimo();
                posicao = ObterPosicaoVazia();
            }

            else
            {
                posicao = ObterPosicaoOcupadaPorId(id);
                emprestimo = (Emprestimo)registros[posicao];
            }

            emprestimo.amigoEmprestimo = amigoEmprestimo;
            emprestimo.caixaEmprestimo = caixaEmprestimo;
            emprestimo.revistaEmprestimo = revistaEmprestimo;

            string resultadoValidacao = emprestimo.Validar();

            if (resultadoValidacao == "EMPRESTIMO_VALIDO")
                registros[posicao] = emprestimo;

            return resultadoValidacao;
        }

        public bool Excluir(int idSelecionado)
        {
            return ExcluirRegistro(new Emprestimo(idSelecionado));
        }

        public Emprestimo[] SelecionarTodosEmprestimos()
        {
            Emprestimo[] aux = new Emprestimo[QtdRegistrosCadastrados()];
            Array.Copy(SelecionarTodosRegistros(), aux, aux.Length);
            return aux;
        }

        public string Devolver(int id, string amigoEmprestimoDevol, string caixaEmprestimoDevol, string revistaEmprestimoDevol)
        {
            Emprestimo emprestimo = null;

            int posicao = 0;

            if (id == 0)
            {
                emprestimo = new Emprestimo();
                posicao = ObterPosicaoVazia();
            }

            else
            {
                posicao = ObterPosicaoOcupadaPorId(id);
                emprestimo = (Emprestimo)registros[posicao];
            }

            emprestimo.amigoEmprestimoDevol = amigoEmprestimoDevol;
            emprestimo.caixaEmprestimoDevol = caixaEmprestimoDevol;
            emprestimo.revistaEmprestimoDevol = revistaEmprestimoDevol;

            string resultadoValidacao = emprestimo.Validar();

            if (resultadoValidacao == "EMPRESTIMO_VALIDO")
                registros[posicao] = emprestimo;

            return resultadoValidacao;
        }

        protected int ObterPosicaoOcupadaPorId(int id)
        {
            int i = 0;

            foreach (object obj in registros)
            {
                if (obj is Revista)
                {
                    Revista e = (Revista)obj;
                    if (e.id == id)
                    {
                        return i;
                    }
                }
                i++;
            }
            return i;
        }
    }
}