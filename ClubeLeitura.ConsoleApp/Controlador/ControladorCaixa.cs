using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeLeitura.ConsoleApp.Dominio;

namespace ClubeLeitura.ConsoleApp.Controlador
{
    public class ControladorCaixa : ControladorBase
    {
        public ControladorCaixa(int capacidade_registros) : base(capacidade_registros) { }

        public string Registrar(int id, string corCaixa, string etiquetaCaixa, double numeroCaixa)
        {
            Caixa caixa = null;

            int posicao = 0;

            if (id == 0)
            {
                caixa = new Caixa();
                posicao = ObterPosicaoVazia();
            }

            else
            {
                posicao = ObterPosicaoOcupadaPorId(id);
                caixa = (Caixa)registros[posicao];
            }

            caixa.corCaixa = corCaixa;
            caixa.etiquetaCaixa = etiquetaCaixa;
            caixa.numeroCaixa = numeroCaixa;

            string resultadoValidacao = caixa.Validar();

            if (resultadoValidacao == "CAIXA_VALIDO")
                registros[posicao] = caixa;

            return resultadoValidacao;
        }

        public bool Excluir(int idSelecionado)
        {
            return ExcluirRegistro(new Caixa(idSelecionado));
        }

        public Caixa[] SelecionarTodasCaixas()
        {
            Caixa[] aux = new Caixa[QtdRegistrosCadastrados()];
            Array.Copy(SelecionarTodosRegistros(), aux, aux.Length);
            return aux;
        }

        protected int ObterPosicaoOcupadaPorId(int id)
        {
            int i = 0;

            foreach (object obj in registros)
            {
                if (obj is Caixa)
                {
                    Caixa e = (Caixa)obj;
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