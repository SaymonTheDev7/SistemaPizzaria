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
            _context = new AppDbContext(); // Inst�ncia do contexto do banco de dados
            var pizzaRepositorio = new PizzaRepositorio(_context); // Passando o contexto para o reposit�rio
            _pizzaDominioServico = new PizzaDominioServico(pizzaRepositorio);
            _pizzas = new List<Pizza>();
            CarregarPizzas();
        }

        // Evento para o bot�o salvar
        private void btnSalvarPizza_Click(object sender, EventArgs e)
        {
            try
            {
                // A pizza tem um ID gerado automaticamente (ou fornecido pelo usu�rio)
                int? idPizza = null;

                // Se o usu�rio forneceu um ID, tenta convert�-lo
                if (!string.IsNullOrWhiteSpace(txtIdPizza.Text))
                {
                    if (!int.TryParse(txtIdPizza.Text, out int id))
                    {
                        MessageBox.Show("O ID deve ser um n�mero v�lido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    idPizza = id; // Define o ID manual, se fornecido
                }

                // Nome e Pre�o da pizza
                string nomePizza = txtNomePizza.Text;
                decimal precoPizza;

                // Validar e converter o pre�o
                if (!decimal.TryParse(txtPrecoPizza.Text, out precoPizza) || precoPizza <= 0)
                {
                    MessageBox.Show("Por favor, insira um pre�o v�lido maior que zero.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Criar a pizza e tentar salvar
                var pizza = new Pizza(nomePizza, precoPizza);

                if (idPizza.HasValue)
                {
                    pizza.Id = idPizza.Value; // Atribui o ID manual, se fornecido
                }

                // Usar o m�todo correto para adicionar
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

        // M�todo para carregar as pizzas no DataGridView
        private void CarregarPizzas()
        {
            try
            {
                // Aqui voc� deve pegar as pizzas do reposit�rio ou banco de dados
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
            // L�gica de valida��o extra (se necess�rio)
        }

        private void txtNomePizza_TextChanged(object sender, EventArgs e)
        {
            // L�gica de valida��o extra (se necess�rio)
        }

        private void txtPrecoPizza_TextChanged(object sender, EventArgs e)
        {
            // L�gica de valida��o extra (se necess�rio)
        }

        // Event handler para o clique do DataGridView
        private void dataGridViewPizzas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // L�gica de manipula��o de clique na c�lula, como editar ou excluir pizza
            try
            {
                // Verifica se o clique foi em uma c�lula v�lida
                if (e.RowIndex >= 0)
                {
                    // Obt�m o ID da pizza da c�lula clicada (supondo que voc� tenha uma coluna "Id" no seu DataGridView)
                    int idPizza = Convert.ToInt32(dataGridViewPizzas.Rows[e.RowIndex].Cells["Id"].Value);

                    // Obt�m a pizza com o ID
                    var pizzaExistente = _pizzaDominioServico.GetPizzas().FirstOrDefault(p => p.Id == idPizza);

                    if (pizzaExistente != null)
                    {
                        // Preenche os campos com os dados da pizza para edi��o
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
                    MessageBox.Show("O ID deve ser um n�mero v�lido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tenta obter a pizza do reposit�rio
                var pizzaExistente = _pizzaDominioServico.GetPizzas().FirstOrDefault(p => p.Id == idPizza);

                if (pizzaExistente == null)
                {
                    MessageBox.Show("Pizza n�o encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Exclui a pizza
                _pizzaDominioServico.ExcluirPizza(pizzaExistente);
                MessageBox.Show("Pizza exclu�da com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
