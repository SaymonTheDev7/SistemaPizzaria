namespace SistemaPizzaria
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtIdPizza = new TextBox();
            txtNomePizza = new TextBox();
            txtPrecoPizza = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnSalvarPizza = new Button();
            dataGridViewPizzas = new DataGridView();
            btnExcluirPizza = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPizzas).BeginInit();
            SuspendLayout();
            // 
            // txtIdPizza
            // 
            txtIdPizza.Enabled = false;
            txtIdPizza.Location = new Point(91, 102);
            txtIdPizza.Name = "txtIdPizza";
            txtIdPizza.Size = new Size(100, 23);
            txtIdPizza.TabIndex = 0;
            txtIdPizza.TextChanged += txtIdPizza_TextChanged;
            // 
            // txtNomePizza
            // 
            txtNomePizza.Location = new Point(220, 102);
            txtNomePizza.Name = "txtNomePizza";
            txtNomePizza.Size = new Size(100, 23);
            txtNomePizza.TabIndex = 1;
            txtNomePizza.TextChanged += txtNomePizza_TextChanged;
            // 
            // txtPrecoPizza
            // 
            txtPrecoPizza.Location = new Point(345, 102);
            txtPrecoPizza.Name = "txtPrecoPizza";
            txtPrecoPizza.Size = new Size(100, 23);
            txtPrecoPizza.TabIndex = 2;
            txtPrecoPizza.TextChanged += txtPrecoPizza_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(91, 80);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 3;
            label1.Text = "ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(220, 80);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 4;
            label2.Text = "Sabor da pizza";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(345, 80);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 5;
            label3.Text = "Preço";
            // 
            // btnSalvarPizza
            // 
            btnSalvarPizza.Location = new Point(471, 80);
            btnSalvarPizza.Name = "btnSalvarPizza";
            btnSalvarPizza.Size = new Size(75, 23);
            btnSalvarPizza.TabIndex = 7;
            btnSalvarPizza.Text = "Salvar";
            btnSalvarPizza.UseVisualStyleBackColor = true;
            btnSalvarPizza.Click += btnSalvarPizza_Click;
            // 
            // dataGridViewPizzas
            // 
            dataGridViewPizzas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPizzas.Location = new Point(91, 155);
            dataGridViewPizzas.Name = "dataGridViewPizzas";
            dataGridViewPizzas.Size = new Size(455, 246);
            dataGridViewPizzas.TabIndex = 8;
            dataGridViewPizzas.CellContentClick += dataGridViewPizzas_CellContentClick;
            // 
            // btnExcluirPizza
            // 
            btnExcluirPizza.Location = new Point(471, 109);
            btnExcluirPizza.Name = "btnExcluirPizza";
            btnExcluirPizza.Size = new Size(75, 23);
            btnExcluirPizza.TabIndex = 9;
            btnExcluirPizza.Text = "Excluir";
            btnExcluirPizza.UseVisualStyleBackColor = true;
            btnExcluirPizza.Click += btnExcluirPizza_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(855, 450);
            Controls.Add(btnExcluirPizza);
            Controls.Add(dataGridViewPizzas);
            Controls.Add(btnSalvarPizza);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPrecoPizza);
            Controls.Add(txtNomePizza);
            Controls.Add(txtIdPizza);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridViewPizzas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtIdPizza;
        private TextBox txtNomePizza;
        private TextBox txtPrecoPizza;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnSalvarPizza;
        private DataGridView dataGridViewPizzas;
        private Button btnExcluirPizza;
    }
}
