using SistemaPizzaria.Aplicacao.Servicos;
using SistemaPizzaria.Dominio.Entidades;
using Microsoft.Extensions.DependencyInjection;
using SistemaPizzaria.Aplicacao.Servicos;
using System;

namespace SistemaPizzaria

{
    public partial class Form1 : Form
    {
        private readonly IPizzaAppServico _servico;

        public Form1(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _servico = serviceProvider.GetRequiredService<IPizzaAppServico>();

            CarregarPizzas();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                MessageBox.Show("Nome do produto é obrigatório.");
                return;
            }

            if (!decimal.TryParse(txtPreco.Text, out decimal preco) || preco <= 0)
            {
                MessageBox.Show("Preço inválido.");
                return;
            }

            try
            {
                if (string.IsNullOrEmpty(txtId.Text))
                {
                    _servico.CadastrarPizza(txtNome.Text, decimal.Parse(txtPreco.Text));
                    MessageBox.Show("Pizza salva com sucesso!");
                    CarregarPizzas();
                }
                else
                {
                    _servico.AlterarPizza(int.Parse(txtId.Text), txtNome.Text, decimal.Parse(txtPreco.Text));
                    MessageBox.Show("Pizza atualizada com sucesso!");
                    CarregarPizzas();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar a pizza: {ex.Message}");
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CarregarPizzas();
        }

        private void CarregarPizzas()
        {
            var pizzas = _servico.GetPizzas();

            dtgEstoque.DataSource = pizzas;

            dtgEstoque.Columns["Id"].HeaderText = "ID";
            dtgEstoque.Columns["Nome"].HeaderText = "Nome da Pizza";
            dtgEstoque.Columns["Preco"].HeaderText = "Preço";
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtId.Text) || !int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Por favor, insira um ID válido.");
                return;
            }

            if (string.IsNullOrEmpty(txtNome.Text))
            {
                MessageBox.Show("Nome da pizza é obrigatório.");
                return;
            }

            if (!decimal.TryParse(txtPreco.Text, out decimal preco) || preco <= 0)
            {
                MessageBox.Show("Preço inválido.");
                return;
            }
            try
            {
                var pizza = new Pizza(int.Parse(txtId.Text), txtNome.Text, decimal.Parse(txtPreco.Text));
                _servico.ExcluirPizza(pizza);
                MessageBox.Show("Pizza excluida com sucesso");
                CarregarPizzas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar a pizza: {ex.Message}");
            }
        }

        private void dtgEstoque_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var pizzaSelecionada = dtgEstoque.Rows[e.RowIndex].DataBoundItem as Pizza;

                if (pizzaSelecionada != null)
                {
                    txtId.Text = pizzaSelecionada.Id.ToString();
                    txtNome.Text = pizzaSelecionada.Nome;
                    txtPreco.Text = pizzaSelecionada.Preco.ToString("F2");
                }
            }
        }
    }
}