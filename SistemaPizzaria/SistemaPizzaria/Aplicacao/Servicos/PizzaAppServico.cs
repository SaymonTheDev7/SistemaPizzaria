using System;
using System.Collections.Generic;
using SistemaPizzaria.Dominio.Entidades;
using SistemaPizzaria.Dominio.Servicos;
using SistemaPizzaria.Infraestrutura.Repositorios;

namespace SistemaPizzaria.Aplicacao.Servicos
{
    public class PizzaAppServico : IPizzaAppServico
    {
        private readonly IPizzaDominioServico _dominioServico;
        private readonly IPizzaRepositorio _pizzaRepositorio;

        public PizzaAppServico(IPizzaDominioServico dominioServico, IPizzaRepositorio pizzaRepositorio)
        {
            _dominioServico = dominioServico;
            _pizzaRepositorio = pizzaRepositorio;
        }

        public void CadastrarPizza(string nomePizza, decimal preco)
        {
            var pizza = new Pizza(nomePizza, preco);
            _dominioServico.Validar(pizza);
            _pizzaRepositorio.Salvar(pizza);
        }

        public void AlterarPizza(int id, string nomePizza, decimal preco)
        {
            _dominioServico.ValidarId(id);

            var pizzaExistente = _pizzaRepositorio.GetPizzaById(id);
            if (pizzaExistente == null)
            {
                throw new Exception("Pizza não encontrada para alteração");
            }

            pizzaExistente.Nome = nomePizza;
            pizzaExistente.Preco = preco;

            _dominioServico.Validar(pizzaExistente);
            _pizzaRepositorio.Alterar(pizzaExistente);
        }

        public void ExcluirPizza(Pizza pizza)
        {
            var pizzaExistente = _pizzaRepositorio.GetPizzaById(pizza.Id);
            if (pizzaExistente == null)
            {
                throw new Exception("Pizza não encontrada para exclusão");
            }

            _pizzaRepositorio.Excluir(pizzaExistente);
        }

        public List<Pizza> GetPizzas()
        {
            return _pizzaRepositorio.GetPizzas();
        }
    }
}
