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
            panel1.Size = new Size(1561, 499);
            panel1.TabIndex = 0;
            // 
            // btnRegresar
            // 
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
            lblResultado.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblResultado.Location = new Point(887, 188);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(273, 34);
            lblResultado.TabIndex = 20;
            lblResultado.Text = "Resultado y Polinomio:";
            // 
            // btnCalcular
            // 
            btnCalcular.Location = new Point(458, 265);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(275, 34);
            btnCalcular.TabIndex = 19;
            btnCalcular.Text = "Calcular ";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(458, 150);
            label4.Name = "label4";
            label4.Size = new Size(280, 25);
            label4.TabIndex = 18;
            label4.Text = "Ingresa el valor de X para Estimar:";
            // 
            // txtValorX
            // 
            txtValorX.Location = new Point(479, 192);
            txtValorX.Name = "txtValorX";
            txtValorX.Size = new Size(234, 31);
            txtValorX.TabIndex = 17;
            txtValorX.KeyPress += txtValorX_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(82, 120);
            label3.Name = "label3";
            label3.Size = new Size(135, 25);
            label3.TabIndex = 16;
            label3.Text = "Ingresa X y F(X)";
            // 
            // dgvInput
            // 
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
            lblTipoInterpolacion.Location = new Point(762, 28);
            lblTipoInterpolacion.Name = "lblTipoInterpolacion";
            lblTipoInterpolacion.Size = new Size(83, 25);
            lblTipoInterpolacion.TabIndex = 14;
            lblTipoInterpolacion.Text = "Modelo: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 18);
            label2.Name = "label2";
            label2.Size = new Size(119, 25);
            label2.TabIndex = 13;
            label2.Text = "Eligir Metodo";
            // 
            // cmbMetodoInterpolacion
            // 
            cmbMetodoInterpolacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodoInterpolacion.FormattingEnabled = true;
            cmbMetodoInterpolacion.Items.AddRange(new object[] { "Newton Diferencias Divididas" });
            cmbMetodoInterpolacion.Location = new Point(12, 44);
            cmbMetodoInterpolacion.Name = "cmbMetodoInterpolacion";
            cmbMetodoInterpolacion.Size = new Size(298, 33);
            cmbMetodoInterpolacion.TabIndex = 12;
            cmbMetodoInterpolacion.SelectedIndexChanged += cmbMetodoInterpolacion_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(791, 3);
            label1.Name = "label1";
            label1.Size = new Size(263, 25);
            label1.TabIndex = 11;
            label1.Text = "METODOS DE INTERPOLACION";
            // 
            // dgvTablaDiferencias
            // 
            dgvTablaDiferencias.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTablaDiferencias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTablaDiferencias.Location = new Point(5, 505);
            dgvTablaDiferencias.Name = "dgvTablaDiferencias";
            dgvTablaDiferencias.RowHeadersWidth = 62;
            dgvTablaDiferencias.Size = new Size(1544, 410);
            dgvTablaDiferencias.TabIndex = 1;
            // 
            // FormInterpolantes
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1561, 927);
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
    }
}