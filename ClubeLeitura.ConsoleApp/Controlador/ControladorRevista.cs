using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeLeitura.ConsoleApp.Dominio;

namespace ClubeLeitura.ConsoleApp.Controlador
{
    public class ControladorRevista : ControladorBase
    {
        public ControladorRevista(int capacidade_registros) : base(capacidade_registros) { }

        public string Registrar(int id, string colecaoRevista, double anoRevista, double numeroRevista)
        {
            Revista revista = null;

            int posicao = 0;

            if (id == 0)
            {
                revista = new Revista();
                posicao = ObterPosicaoVazia();
            }

            else
            {
                posicao = ObterPosicaoOcupadaPorId(id);
                revista = (Revista)registros[posicao];
            }

            revista.colecaoRevista = colecaoRevista;
            revista.anoRevista = anoRevista;
            revista.numeroRevista = numeroRevista;

            string resultadoValidacao = revista.Validar();

            if (resultadoValidacao == "REVISTA_VALIDO")
                registros[posicao] = revista;

            return resultadoValidacao;
        }

        public bool Excluir(int idSelecionado)
        {
            return ExcluirRegistro(new Revista(idSelecionado));
        }

        public Revista[] SelecionarTodasRevistas()
        {
            Revista[] aux = new Revista[QtdRegistrosCadastrados()];
            Array.Copy(SelecionarTodosRegistros(), aux, aux.Length);
            return aux;
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