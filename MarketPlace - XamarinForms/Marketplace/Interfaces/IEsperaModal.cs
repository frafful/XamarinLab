using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Interfaces
{
    public interface IEsperaModal
    {
        string Mensagem { get; set; }

        void Iniciar();
        void Finalizar();
    }
}
