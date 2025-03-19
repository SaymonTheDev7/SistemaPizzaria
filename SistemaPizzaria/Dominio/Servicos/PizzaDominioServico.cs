using SistemaPizzaria.Dominio.Entidades;
using SistemaPizzaria.Infraestrutura.Repositorios;
using System;
using System.Collections.Generic;

namespace SistemaPizzaria.Dominio.Servicos
{
    public class PizzaDominioServico
    {
        private readonly InterfacePizzaRepositorio _pizzaRepositorio;

        public PizzaDominioServico(InterfacePizzaRepositorio pizzaRepositorio)
        {
            _pizzaRepositorio = pizzaRepositorio;
        }

        public void Validar(Pizza pizza)
        {
            if (string.IsNullOrWhiteSpace(pizza.Nome))
            {
                throw new ArgumentException("O nome da pizza não pode ser vazio.");
            }

            if (_pizzaRepositorio.ExisteNome(pizza.Nome))
            {
                throw new ArgumentException("Já existe uma pizza com este nome.");
            }

            if (pizza.Preco <= 0)
            {
                throw new ArgumentException("O preço da pizza deve ser maior que zero.");
            }
        }

        public void CadastrarPizza(Pizza pizza, bool isAdministrador)
        {
            if (!isAdministrador)
            {
                throw new UnauthorizedAccessException("Apenas administradores ou usuários autorizados podem cadastrar pizzas.");
            }

            Validar(pizza);
            _pizzaRepositorio.Salvar(pizza);
        }

        public List<Pizza> GetPizzas()
        {
            return _pizzaRepositorio.ObterTodos();
        }

        public void ExcluirPizza(Pizza pizza)
        {
            if (pizza == null)
            {
                throw new ArgumentNullException(nameof(pizza), "Pizza não pode ser nula.");
            }

            _pizzaRepositorio.Excluir(pizza);  // Chama o método do repositório
        }
    }
}
