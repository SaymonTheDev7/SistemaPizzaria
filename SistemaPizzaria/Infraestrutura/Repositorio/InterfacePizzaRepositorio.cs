using SistemaPizzaria.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaPizzaria.Infraestrutura.Repositorios
{
    public interface InterfacePizzaRepositorio
    {
        void Salvar(Pizza pizza);
        void Excluir(Pizza pizza);
        void Alterar(Pizza pizza);
        bool ExisteNome(string nome);
        List<Pizza> GetPizzas();
        Pizza? GetPizzaById(int id);
        List<Pizza> ObterTodos();
    }
}
