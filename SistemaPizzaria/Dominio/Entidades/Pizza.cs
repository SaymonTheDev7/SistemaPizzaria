using System;

namespace SistemaPizzaria.Dominio.Entidades
{
    public class Pizza
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        // Construtor ajustado
        public Pizza(string nome, decimal preco)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));  // Garante que o nome não seja nulo
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("Nome da pizza não pode ser nulo ou vazio.", nameof(nome));
            }

            if (preco <= 0)
            {
                throw new ArgumentException("O preço deve ser maior que zero.", nameof(preco));
            }

            Preco = preco;
        }
    }
}
