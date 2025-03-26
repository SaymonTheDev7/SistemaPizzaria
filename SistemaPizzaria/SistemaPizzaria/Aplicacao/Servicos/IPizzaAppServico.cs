using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaPizzaria.Dominio.Entidades;

namespace SistemaPizzaria.Aplicacao.Servicos
{
    public interface IPizzaAppServico
    {
        void CadastrarPizza(string Nome, decimal preco);
        void AlterarPizza(int id, string Nome, decimal preco);
        void ExcluirPizza(Pizza pizza);
        List<Pizza> GetPizzas();
    }
}
