namespace Proyecto_MetodosNumericos
{
    partial class FormRegresion
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
            lblR2 = new Label();
            lblEcuacion = new Label();
            btnCalcular = new Button();
            label4 = new Label();
            nudGrado = new NumericUpDown();
            label3 = new Label();
            dgvDatos = new DataGridView();
            label2 = new Label();
            cmbTipoRegresion = new ComboBox();
            label1 = new Label();
            dgvResultados = new DataGridView();
            X = new DataGridViewTextBoxColumn();
            Y = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudGrado).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnRegresar);
            panel1.Controls.Add(lblR2);
            panel1.Controls.Add(lblEcuacion);
            panel1.Controls.Add(btnCalcular);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(nudGrado);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(dgvDatos);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cmbTipoRegresion);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1472, 469);
            panel1.TabIndex = 0;
            // 
            // btnRegresar
            // 
            btnRegresar.Location = new Point(579, 378);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(195, 34);
            btnRegresar.TabIndex = 9;
            btnRegresar.Text = "Regresar";
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // lblR2
            // 
            lblR2.AutoSize = true;
            lblR2.Location = new Point(580, 204);
            lblR2.Name = "lblR2";
            lblR2.Size = new Size(55, 25);
            lblR2.TabIndex = 8;
            lblR2.Text = "R2 = ";
            // 
            // lblEcuacion
            // 
            lblEcuacion.AutoSize = true;
            lblEcuacion.Location = new Point(579, 142);
            lblEcuacion.Name = "lblEcuacion";
            lblEcuacion.Size = new Size(287, 25);
            lblEcuacion.TabIndex = 7;
            lblEcuacion.Text = "Y = B0 + B1X1 + B2X2 + ... + BnXn";
            // 
            // btnCalcular
            // 
            btnCalcular.Location = new Point(579, 312);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(195, 34);
            btnCalcular.TabIndex = 6;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 128);
            label4.Name = "label4";
            label4.Size = new Size(175, 25);
            label4.TabIndex = 5;
            label4.Text = "Grado del Polinomio";
            // 
            // nudGrado
            // 
            nudGrado.Location = new Point(16, 165);
            nudGrado.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudGrado.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudGrado.Name = "nudGrado";
            nudGrado.ReadOnly = true;
            nudGrado.Size = new Size(119, 31);
            nudGrado.TabIndex = 4;
            nudGrado.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(218, 98);
            label3.Name = "label3";
            label3.Size = new Size(203, 25);
            label3.TabIndex = 3;
            label3.Text = "Ingrese los Puntos (X, Y)";
            // 
            // dgvDatos
            // 
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { X, Y });
            dgvDatos.Location = new Point(227, 131);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.RowHeadersWidth = 62;
            dgvDatos.Size = new Size(277, 315);
            dgvDatos.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 15);
            label2.Name = "label2";
            label2.Size = new Size(119, 25);
            label2.TabIndex = 2;
            label2.Text = "Eligir Metodo";
            // 
            // cmbTipoRegresion
            // 
            cmbTipoRegresion.FormattingEnabled = true;
            cmbTipoRegresion.Items.AddRange(new object[] { "Regresion Simple", "Regresion Polinomial" });
            cmbTipoRegresion.Location = new Point(12, 41);
            cmbTipoRegresion.Name = "cmbTipoRegresion";
            cmbTipoRegresion.Size = new Size(233, 33);
            cmbTipoRegresion.TabIndex = 1;
            cmbTipoRegresion.SelectedIndexChanged += cmbTipoRegresion_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(791, 0);
            label1.Name = "label1";
            label1.Size = new Size(222, 25);
            label1.TabIndex = 0;
            label1.Text = "METODOS DE REGRESION";
            // 
            // dgvResultados
            // 
            dgvResultados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultados.Location = new Point(12, 475);
            dgvResultados.Name = "dgvResultados";
            dgvResultados.RowHeadersWidth = 62;
            dgvResultados.Size = new Size(1448, 356);
            dgvResultados.TabIndex = 1;
            // 
            // X
            // 
            X.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            X.HeaderText = "X";
            X.MinimumWidth = 8;
            X.Name = "X";
            // 
            // Y
            // 
            Y.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Y.HeaderText = "Y";
            Y.MinimumWidth = 8;
            Y.Name = "Y";
            // 
            // FormRegresion
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1472, 843);
            Controls.Add(dgvResultados);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormRegresion";
            Text = "FormRegresion";
            WindowState = FormWindowState.Maximized;
            FormClosed += FormRegresion_FormClosed;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudGrado).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private ComboBox cmbTipoRegresion;
        private Label label1;
        private DataGridView dgvDatos;
        private NumericUpDown nudGrado;
        private Label label3;
        private Label lblR2;
        private Label lblEcuacion;
        private Button btnCalcular;
        private Label label4;
        private Button btnRegresar;
        private DataGridView dgvResultados;
        private DataGridViewTextBoxColumn X;
        private DataGridViewTextBoxColumn Y;
    }
}