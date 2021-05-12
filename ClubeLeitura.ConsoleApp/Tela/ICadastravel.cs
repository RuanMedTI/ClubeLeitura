using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.Tela
{
    interface ICadastravel
    {
        void Registrar(int id);

        void EditarRegistro();

        void ExcluirRegistro();

        void VisualizarRegistros();

        string ObterOpcao();
    }
}
