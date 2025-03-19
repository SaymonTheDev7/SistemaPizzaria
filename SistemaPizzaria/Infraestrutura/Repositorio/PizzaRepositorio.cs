using SistemaPizzaria.Dominio.Entidades;
using SistemaPizzaria.Infraestrutura.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaPizzaria.Infraestrutura.Repositorios
{
    public class PizzaRepositorio : InterfacePizzaRepositorio
    {
        private readonly AppDbContext _context;

        public PizzaRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public void Salvar(Pizza pizza)
        {
            var pizzaExistente = _context.Pizzas.Find(pizza.Id);
            if (pizzaExistente != null)
            {
                pizzaExistente.Nome = pizza.Nome;
                pizzaExistente.Preco = pizza.Preco;
            }
            else
            {
                _context.Pizzas.Add(pizza);
            }

            _context.SaveChanges();
        }

        public void Excluir(Pizza pizza)
        {
            var pizzaExistente = _context.Pizzas.Find(pizza.Id);
            if (pizzaExistente != null)
            {
                _context.Pizzas.Remove(pizzaExistente);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Pizza não encontrada para exclusão.");
            }
        }

        public void Alterar(Pizza pizza)
        {
            var pizzaExistente = _context.Pizzas.Find(pizza.Id);
            if (pizzaExistente != null)
            {
                pizzaExistente.Nome = pizza.Nome;
                pizzaExistente.Preco = pizza.Preco;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Pizza não encontrada para alteração.");
            }
        }

        public bool ExisteNome(string nome)
        {
            return _context.Pizzas.Any(p => p.Nome == nome);
        }

        public List<Pizza> GetPizzas()
        {
            return _context.Pizzas.ToList();
        }

        public Pizza? GetPizzaById(int id)
        {
            return _context.Pizzas.Find(id);
        }

        public List<Pizza> ObterTodos()
        {
            return _context.Pizzas.ToList();
        }
    }
}
