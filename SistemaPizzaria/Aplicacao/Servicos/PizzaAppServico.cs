using SistemaPizzaria.Dominio.Entidades;
using SistemaPizzaria.Dominio.Servicos;
using SistemaPizzaria.Infraestrutura.Repositorios;
using System;
using System.Collections.Generic;

namespace SistemaPizzaria.Aplicacao.Servicos
{
    public class PizzaAppServico : InterfacePizzaAppServico
    {
        private readonly PizzaDominioServico _dominioServico;
        private readonly InterfacePizzaRepositorio _pizzaRepositorio;

        public PizzaAppServico(PizzaDominioServico dominioServico, InterfacePizzaRepositorio pizzaRepositorio)
        {
            _dominioServico = dominioServico;
            _pizzaRepositorio = pizzaRepositorio;
        }

        public void CadastrarPizza(string nome, decimal preco)
        {
            var pizza = new Pizza(nome, preco);
            _dominioServico.Validar(pizza);
            _pizzaRepositorio.Salvar(pizza);
        }

        public void AlterarPizza(int id, string nome, decimal preco)
        {
            var pizzaExistente = _pizzaRepositorio.GetPizzaById(id);
            if (pizzaExistente == null)
            {
                throw new Exception("Pizza não encontrada para alteração");
            }

            pizzaExistente.Nome = nome;
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
