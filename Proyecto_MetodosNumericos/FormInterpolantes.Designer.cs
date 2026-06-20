namespace Proyecto_MetodosNumericos
{
    partial class FormInterpolantes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            rtbResultados = new RichTextBox();
            btnRegresar = new Button();
            lblResultado = new Label();
            btnCalcular = new Button();
            label4 = new Label();
            txtValorX = new TextBox();
            label3 = new Label();
            dgvInput = new DataGridView();
            X = new DataGridViewTextBoxColumn();
            fx = new DataGridViewTextBoxColumn();
            lblTipoInterpolacion = new Label();
            label2 = new Label();
            cmbMetodoInterpolacion = new ComboBox();
            label1 = new Label();
            dgvTablaDiferencias = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTablaDiferencias).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.Controls.Add(rtbResultados);
            panel1.Controls.Add(btnRegresar);
            panel1.Controls.Add(lblResultado);
            panel1.Controls.Add(btnCalcular);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtValorX);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(dgvInput);
            panel1.Controls.Add(lblTipoInterpolacion);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cmbMetodoInterpolacion);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1662, 499);
            panel1.TabIndex = 0;
            // 
            // rtbResultados
            // 
            rtbResultados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbResultados.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            rtbResultados.Location = new Point(1133, 24);
            rtbResultados.Name = "rtbResultados";
            rtbResultados.Size = new Size(508, 450);
            rtbResultados.TabIndex = 22;
            rtbResultados.Text = "";
            // 
            // btnRegresar
            // 
            btnRegresar.Font = new Font("Times New Roman", 10F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnRegresar.Location = new Point(488, 329);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(204, 34);
            btnRegresar.TabIndex = 21;
            btnRegresar.Text = "Regresar";
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            lblResultado.Location = new Point(815, 223);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(201, 22);
            lblResultado.TabIndex = 20;
            lblResultado.Text = "Resultado y Polinomio:";
            // 
            // btnCalcular
            // 
            btnCalcular.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            btnCalcular.Location = new Point(488, 265);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(204, 34);
            btnCalcular.TabIndex = 19;
            btnCalcular.Text = "Calcular ";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label4.Location = new Point(458, 150);
            label4.Name = "label4";
            label4.Size = new Size(299, 22);
            label4.TabIndex = 18;
            label4.Text = "Ingresa el valor de X para Estimar:";
            // 
            // txtValorX
            // 
            txtValorX.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            txtValorX.Location = new Point(479, 192);
            txtValorX.Name = "txtValorX";
            txtValorX.Size = new Size(234, 30);
            txtValorX.TabIndex = 17;
            txtValorX.KeyPress += txtValorX_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label3.Location = new Point(82, 120);
            label3.Name = "label3";
            label3.Size = new Size(144, 22);
            label3.TabIndex = 16;
            label3.Text = "Ingresa X y F(X)";
            // 
            // dgvInput
            // 
            dgvInput.BackgroundColor = SystemColors.Control;
            dgvInput.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInput.Columns.AddRange(new DataGridViewColumn[] { X, fx });
            dgvInput.Location = new Point(88, 159);
            dgvInput.Name = "dgvInput";
            dgvInput.RowHeadersWidth = 62;
            dgvInput.Size = new Size(270, 315);
            dgvInput.TabIndex = 15;
            dgvInput.DataError += dgvInput_DataError;
            dgvInput.EditingControlShowing += dgvInput_EditingControlShowing;
            // 
            // X
            // 
            X.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            X.HeaderText = "x";
            X.MinimumWidth = 8;
            X.Name = "X";
            X.Width = 150;
            // 
            // fx
            // 
            fx.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            fx.HeaderText = "f(x)";
            fx.MinimumWidth = 8;
            fx.Name = "fx";
            fx.Width = 150;
            // 
            // lblTipoInterpolacion
            // 
            lblTipoInterpolacion.AutoSize = true;
            lblTipoInterpolacion.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            lblTipoInterpolacion.Location = new Point(629, 24);
            lblTipoInterpolacion.Name = "lblTipoInterpolacion";
            lblTipoInterpolacion.Size = new Size(84, 22);
            lblTipoInterpolacion.TabIndex = 14;
            lblTipoInterpolacion.Text = "Modelo: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label2.Location = new Point(16, 18);
            label2.Name = "label2";
            label2.Size = new Size(125, 22);
            label2.TabIndex = 13;
            label2.Text = "Eligir Metodo";
            // 
            // cmbMetodoInterpolacion
            // 
            cmbMetodoInterpolacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodoInterpolacion.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            cmbMetodoInterpolacion.FormattingEnabled = true;
            cmbMetodoInterpolacion.Items.AddRange(new object[] { "Newton Diferencias Divididas", "Lagrange" });
            cmbMetodoInterpolacion.Location = new Point(12, 44);
            cmbMetodoInterpolacion.Name = "cmbMetodoInterpolacion";
            cmbMetodoInterpolacion.Size = new Size(298, 30);
            cmbMetodoInterpolacion.TabIndex = 12;
            cmbMetodoInterpolacion.SelectedIndexChanged += cmbMetodoInterpolacion_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label1.Location = new Point(685, 0);
            label1.Name = "label1";
            label1.Size = new Size(288, 22);
            label1.TabIndex = 11;
            label1.Text = "METODOS DE INTERPOLACION";
            // 
            // dgvTablaDiferencias
            // 
            dgvTablaDiferencias.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTablaDiferencias.BackgroundColor = SystemColors.Control;
            dgvTablaDiferencias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTablaDiferencias.Location = new Point(5, 505);
            dgvTablaDiferencias.Name = "dgvTablaDiferencias";
            dgvTablaDiferencias.ReadOnly = true;
            dgvTablaDiferencias.RowHeadersWidth = 62;
            dgvTablaDiferencias.Size = new Size(1645, 410);
            dgvTablaDiferencias.TabIndex = 1;
            // 
            // FormInterpolantes
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1662, 927);
            Controls.Add(dgvTablaDiferencias);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormInterpolantes";
            Text = "FormInterpolantes";
            WindowState = FormWindowState.Maximized;
            FormClosed += FormInterpolantes_FormClosed;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTablaDiferencias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblTipoInterpolacion;
        private Label label2;
        private ComboBox cmbMetodoInterpolacion;
        private Label label1;
        private DataGridView dgvInput;
        private Label label4;
        private TextBox txtValorX;
        private Label label3;
        private DataGridViewTextBoxColumn X;
        private DataGridViewTextBoxColumn fx;
        private DataGridView dgvTablaDiferencias;
        private Label lblResultado;
        private Button btnCalcular;
        private Button btnRegresar;
        private RichTextBox rtbResultados;
    }
}