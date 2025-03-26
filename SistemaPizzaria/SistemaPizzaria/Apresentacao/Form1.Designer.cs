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
            lblNome = new Label();
            btnSalvar = new Button();
            txtNome = new TextBox();
            txtPreco = new TextBox();
            lblPreco = new Label();
            btnExcluir = new Button();
            dtgEstoque = new DataGridView();
            txtId = new TextBox();
            lblId = new Label();
            ((System.ComponentModel.ISupportInitialize)dtgEstoque).BeginInit();
            SuspendLayout();
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(203, 50);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(40, 15);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome";
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(570, 81);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 23);
            btnSalvar.TabIndex = 1;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(203, 82);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(143, 23);
            txtNome.TabIndex = 2;
            // 
            // txtPreco
            // 
            txtPreco.Location = new Point(383, 81);
            txtPreco.Name = "txtPreco";
            txtPreco.Size = new Size(136, 23);
            txtPreco.TabIndex = 3;
            // 
            // lblPreco
            // 
            lblPreco.AutoSize = true;
            lblPreco.Location = new Point(383, 49);
            lblPreco.Name = "lblPreco";
            lblPreco.Size = new Size(37, 15);
            lblPreco.TabIndex = 4;
            lblPreco.Text = "Preço";
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(684, 81);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(75, 23);
            btnExcluir.TabIndex = 5;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // dtgEstoque
            // 
            dtgEstoque.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgEstoque.Location = new Point(39, 135);
            dtgEstoque.Name = "dtgEstoque";
            dtgEstoque.Size = new Size(717, 282);
            dtgEstoque.TabIndex = 6;
            dtgEstoque.CellDoubleClick += dtgEstoque_CellDoubleClick;
            // 
            // txtId
            // 
            txtId.Location = new Point(39, 82);
            txtId.Name = "txtId";
            txtId.Size = new Size(128, 23);
            txtId.TabIndex = 7;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(39, 50);
            lblId.Name = "lblId";
            lblId.Size = new Size(17, 15);
            lblId.TabIndex = 8;
            lblId.Text = "Id";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblId);
            Controls.Add(txtId);
            Controls.Add(dtgEstoque);
            Controls.Add(btnExcluir);
            Controls.Add(lblPreco);
            Controls.Add(txtPreco);
            Controls.Add(txtNome);
            Controls.Add(btnSalvar);
            Controls.Add(lblNome);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dtgEstoque).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNome;
        private Button btnSalvar;
        private TextBox txtNome;
        private TextBox txtPreco;
        private Label lblPreco;
        private Button btnExcluir;
        private DataGridView dtgEstoque;
        private TextBox txtId;
        private Label lblId;
    }
}
