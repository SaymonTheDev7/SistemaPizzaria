using SistemaPizzaria.Dominio.Entidades;
using SistemaPizzaria.Infraestrutura.Repositorios;

namespace SistemaPizzaria.Dominio.Servicos
{
    public class PizzaDominioServico : IPizzaDominioServico
    {

        private readonly IPizzaRepositorio _pizzaRepositorio;

        public PizzaDominioServico(IPizzaRepositorio pizzaRepositorio)
        {
            _pizzaRepositorio = pizzaRepositorio;
        }

        public void Validar(Pizza pizza)
        {
            if (string.IsNullOrWhiteSpace(pizza.Nome))
            {
                throw new Exception("A pizza deve ter um nome inserido!");
            }

            var pizzasExistentes = _pizzaRepositorio.GetPizzas();

            if (pizzasExistentes.Any(p => p.Id != pizza.Id && p.Nome.Trim().Equals(pizza.Nome.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception("Já existe uma pizza cadastrada com esse nome!");
            }

            if (pizza.Preco <= 0)
            {
                throw new Exception("O preço deve ser maior do que zero!");
            }
        }


        public void ValidarId (int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id inválido");
            }
        }
    }
}
