using SistemaPizzaria.Infraestrutura.Database;
using SistemaPizzaria.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaPizzaria.Infraestrutura.Repositorios
{
    public class PizzaRepositorio : IPizzaRepositorio
    {
        private readonly AppDbContext _context;

        public PizzaRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public void Salvar(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
            _context.SaveChanges();
        }

        public void Excluir(Pizza pizza)
        {
            _context.Pizzas.Remove(pizza);
            _context.SaveChanges();
        }

        public void Alterar(Pizza pizza)
        {
            var pizzaExistente = _context.Pizzas.Find(pizza.Id);
            if (pizzaExistente == null)
            {
                throw new Exception("Pizza não encontrada para alteração");
            }
            pizzaExistente.Nome = pizza.Nome;
            pizzaExistente.Preco = pizza.Preco;
            _context.SaveChanges();
        }

        public Pizza? GetPizzaById(int id)
        {
            return _context.Pizzas.Find(id);
        }

        public List<Pizza> GetPizzas()
        {
            return _context.Pizzas.ToList();
        }
    }
}
