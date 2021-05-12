using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeLeitura.ConsoleApp.Dominio;

namespace ClubeLeitura.ConsoleApp.Controlador
{
    public class ControladorAmigo : ControladorBase
    {
        public ControladorAmigo(int capacidade_registros) : base(capacidade_registros) { }

        public string Registrar(int id, string nomeAmigo, string nomeResponsavel, string enderecoAmigo,
            double telefoneResponsavel)
        {
            Amigo amigo = null;

            int posicao = 0;

            if (id == 0)
            {
                amigo = new Amigo();
                posicao = ObterPosicaoVazia();
            }

            else
            {
                posicao = ObterPosicaoOcupadaPorId(id);
                amigo = (Amigo)registros[posicao];
            }

            amigo.nomeAmigo = nomeAmigo;
            amigo.nomeResponsavel = nomeResponsavel;
            amigo.enderecoAmigo = enderecoAmigo;
            amigo.telefoneResponsavel = telefoneResponsavel;

            string resultadoValidacao = amigo.Validar();

            if (resultadoValidacao == "AMIGO_VALIDO")
                registros[posicao] = amigo;

            return resultadoValidacao;
        }

        public bool Excluir(int idSelecionado)
        {
            return ExcluirRegistro(new Amigo(idSelecionado));
        }

        public Amigo SelecionarAmigoPorId(int id)
        {
            return (Amigo)SelecionarRegistro(new Amigo(id));
        }

        public Amigo[] SelecionarTodosAmigos()
        {
            Amigo[] aux = new Amigo[QtdRegistrosCadastrados()];
            Array.Copy(SelecionarTodosRegistros(), aux, aux.Length);
            return aux;
        }

        protected int ObterPosicaoOcupadaPorId(int id)
        {
            int i = 0;

            foreach (object obj in registros)
            {
                if (obj is Amigo)
                {
                    Amigo e = (Amigo)obj;
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