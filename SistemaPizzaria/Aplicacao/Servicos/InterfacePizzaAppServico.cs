using SistemaPizzaria.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaPizzaria.Aplicacao.Servicos
{
    public interface InterfacePizzaAppServico
    {
        void CadastrarPizza(string nome, decimal preco);
        void AlterarPizza(int id, string nome, decimal preco);
        void ExcluirPizza(Pizza pizza);
        List<Pizza> GetPizzas();
    }
}
