using SistemaPizzaria.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPizzaria.Dominio.Servicos
{
    public interface IPizzaDominioServico
    {

        void Validar(Pizza pizza);
        void ValidarId(int id);
    }
}
