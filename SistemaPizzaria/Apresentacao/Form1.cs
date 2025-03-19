using SistemaPizzaria.Dominio.Entidades;
using SistemaPizzaria.Dominio.Servicos;
using SistemaPizzaria.Infraestrutura.Repositorios;
using SistemaPizzaria.Infraestrutura.Database;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SistemaPizzaria
{
    public partial class Form1 : Form
    {
        private readonly PizzaDominioServico _pizzaDominioServico;
        private readonly List<Pizza> _pizzas;
        private readonly AppDbContext _context;

        public Form1()
        {
            InitializeComponent();
            _context = new AppDbContext(); // Instância do contexto do banco de dados
            var pizzaRepositorio = new PizzaRepositorio(_context); // Passando o contexto para o repositório
            _pizzaDominioServico = new PizzaDominioServico(pizzaRepositorio);
            _pizzas = new List<Pizza>();
            CarregarPizzas();
        }

        // Evento para o botão salvar
        private void btnSalvarPizza_Click(object sender, EventArgs e)
        {
            try
            {
                // A pizza tem um ID gerado automaticamente (ou fornecido pelo usuário)
                int? idPizza = null;

                // Se o usuário forneceu um ID, tenta convertê-lo
                if (!string.IsNullOrWhiteSpace(txtIdPizza.Text))
                {
                    if (!int.TryParse(txtIdPizza.Text, out int id))
                    {
                        MessageBox.Show("O ID deve ser um número válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    idPizza = id; // Define o ID manual, se fornecido
                }

                // Nome e Preço da pizza
                string nomePizza = txtNomePizza.Text;
                decimal precoPizza;

                // Validar e converter o preço
                if (!decimal.TryParse(txtPrecoPizza.Text, out precoPizza) || precoPizza <= 0)
                {
                    MessageBox.Show("Por favor, insira um preço válido maior que zero.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Criar a pizza e tentar salvar
                var pizza = new Pizza(nomePizza, precoPizza);

                if (idPizza.HasValue)
                {
                    pizza.Id = idPizza.Value; // Atribui o ID manual, se fornecido
                }

                // Usar o método correto para adicionar
                _pizzaDominioServico.CadastrarPizza(pizza, isAdministrador: true);

                MessageBox.Show("Pizza cadastrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpar os campos
                txtIdPizza.Clear();
                txtNomePizza.Clear();
                txtPrecoPizza.Clear();

                // Recarregar as pizzas no grid
                CarregarPizzas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para carregar as pizzas no DataGridView
        private void CarregarPizzas()
        {
            try
            {
                // Aqui você deve pegar as pizzas do repositório ou banco de dados
                _pizzas.Clear();
                _pizzas.AddRange(_pizzaDominioServico.GetPizzas());

                // Atualiza o DataGridView
                dataGridViewPizzas.DataSource = null;
                dataGridViewPizzas.DataSource = _pizzas;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar as pizzas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handlers para os TextBox
        private void txtIdPizza_TextChanged(object sender, EventArgs e)
        {
            // Lógica de validação extra (se necessário)
        }

        private void txtNomePizza_TextChanged(object sender, EventArgs e)
        {
            // Lógica de validação extra (se necessário)
        }

        private void txtPrecoPizza_TextChanged(object sender, EventArgs e)
        {
            // Lógica de validação extra (se necessário)
        }

        // Event handler para o clique do DataGridView
        private void dataGridViewPizzas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lógica de manipulação de clique na célula, como editar ou excluir pizza
            try
            {
                // Verifica se o clique foi em uma célula válida
                if (e.RowIndex >= 0)
                {
                    // Obtém o ID da pizza da célula clicada (supondo que você tenha uma coluna "Id" no seu DataGridView)
                    int idPizza = Convert.ToInt32(dataGridViewPizzas.Rows[e.RowIndex].Cells["Id"].Value);

                    // Obtém a pizza com o ID
                    var pizzaExistente = _pizzaDominioServico.GetPizzas().FirstOrDefault(p => p.Id == idPizza);

                    if (pizzaExistente != null)
                    {
                        // Preenche os campos com os dados da pizza para edição
                        txtIdPizza.Text = pizzaExistente.Id.ToString();
                        txtNomePizza.Text = pizzaExistente.Nome;
                        txtPrecoPizza.Text = pizzaExistente.Preco.ToString("F2");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnExcluirPizza_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se o ID da pizza foi preenchido
                if (string.IsNullOrWhiteSpace(txtIdPizza.Text))
                {
                    MessageBox.Show("Por favor, insira o ID da pizza que deseja excluir.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tenta converter o ID da pizza
                if (!int.TryParse(txtIdPizza.Text, out int idPizza))
                {
                    MessageBox.Show("O ID deve ser um número válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tenta obter a pizza do repositório
                var pizzaExistente = _pizzaDominioServico.GetPizzas().FirstOrDefault(p => p.Id == idPizza);

                if (pizzaExistente == null)
                {
                    MessageBox.Show("Pizza não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Exclui a pizza
                _pizzaDominioServico.ExcluirPizza(pizzaExistente);
                MessageBox.Show("Pizza excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpa os campos
                txtIdPizza.Clear();
                txtNomePizza.Clear();
                txtPrecoPizza.Clear();

                // Recarrega as pizzas no grid
                CarregarPizzas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
