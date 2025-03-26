using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaPizzaria.Dominio.Entidades;

namespace SistemaPizzaria.Infraestrutura.Repositorios
{
    public interface IPizzaRepositorio
    {
        void Salvar(Pizza pizza);
        void Excluir(Pizza pizza);
        void Alterar(Pizza pizza);

        Pizza? GetPizzaById(int id);

        List<Pizza> GetPizzas();
    }
}
