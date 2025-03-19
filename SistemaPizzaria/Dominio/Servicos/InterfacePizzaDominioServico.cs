using SistemaPizzaria.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPizzaria.Dominio.Servicos
{
    internal interface InterfacePizzaDominioServico
    {
        void Validar(Pizza pizza);
        void ValidarId(int id);
    }
}
