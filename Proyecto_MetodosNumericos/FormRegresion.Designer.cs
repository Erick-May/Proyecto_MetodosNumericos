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
            lblTipoRegresion = new Label();
            btnRegresar = new Button();
            lblR2 = new Label();
            lblEcuacion = new Label();
            btnCalcular = new Button();
            label4 = new Label();
            nudGrado = new NumericUpDown();
            label3 = new Label();
            dgvDatos = new DataGridView();
            X = new DataGridViewTextBoxColumn();
            Y = new DataGridViewTextBoxColumn();
            label2 = new Label();
            cmbTipoRegresion = new ComboBox();
            label1 = new Label();
            dgvResultados = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudGrado).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LemonChiffon;
            panel1.Controls.Add(lblTipoRegresion);
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
            panel1.Size = new Size(1311, 469);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // lblTipoRegresion
            // 
            lblTipoRegresion.Anchor = AnchorStyles.Top;
            lblTipoRegresion.AutoSize = true;
            lblTipoRegresion.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            lblTipoRegresion.Location = new Point(403, 112);
            lblTipoRegresion.Name = "lblTipoRegresion";
            lblTipoRegresion.Size = new Size(84, 22);
            lblTipoRegresion.TabIndex = 10;
            lblTipoRegresion.Text = "Modelo: ";
            // 
            // btnRegresar
            // 
            btnRegresar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRegresar.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            btnRegresar.Location = new Point(870, 292);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(195, 34);
            btnRegresar.TabIndex = 9;
            btnRegresar.Text = "Regresar";
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // lblR2
            // 
            lblR2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblR2.AutoSize = true;
            lblR2.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            lblR2.Location = new Point(695, 174);
            lblR2.Name = "lblR2";
            lblR2.Size = new Size(55, 22);
            lblR2.TabIndex = 8;
            lblR2.Text = "R2 = ";
            // 
            // lblEcuacion
            // 
            lblEcuacion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblEcuacion.AutoSize = true;
            lblEcuacion.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            lblEcuacion.Location = new Point(694, 112);
            lblEcuacion.Name = "lblEcuacion";
            lblEcuacion.Size = new Size(304, 22);
            lblEcuacion.TabIndex = 7;
            lblEcuacion.Text = "Y = B0 + B1X1 + B2X2 + ... + BnXn";
            // 
            // btnCalcular
            // 
            btnCalcular.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCalcular.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            btnCalcular.Location = new Point(570, 295);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(201, 35);
            btnCalcular.TabIndex = 6;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label4.Location = new Point(403, 219);
            label4.Name = "label4";
            label4.Size = new Size(181, 22);
            label4.TabIndex = 5;
            label4.Text = "Grado del Polinomio";
            // 
            // nudGrado
            // 
            nudGrado.Anchor = AnchorStyles.Top;
            nudGrado.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            nudGrado.Location = new Point(423, 247);
            nudGrado.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudGrado.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudGrado.Name = "nudGrado";
            nudGrado.ReadOnly = true;
            nudGrado.Size = new Size(123, 30);
            nudGrado.TabIndex = 4;
            nudGrado.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudGrado.ValueChanged += nudGrado_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 10F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(110, 112);
            label3.Name = "label3";
            label3.Size = new Size(210, 22);
            label3.TabIndex = 3;
            label3.Text = "Ingrese los Puntos (X, Y)";
            // 
            // dgvDatos
            // 
            dgvDatos.BackgroundColor = SystemColors.Control;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { X, Y });
            dgvDatos.Location = new Point(76, 150);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.RowHeadersWidth = 62;
            dgvDatos.Size = new Size(278, 284);
            dgvDatos.TabIndex = 1;
            dgvDatos.DataError += dgvDatos_DataError;
            dgvDatos.EditingControlShowing += dgvDatos_EditingControlShowing;
            // 
            // X
            // 
            X.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            X.HeaderText = "X";
            X.MinimumWidth = 8;
            X.Name = "X";
            X.Width = 150;
            // 
            // Y
            // 
            Y.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Y.HeaderText = "Y";
            Y.MinimumWidth = 8;
            Y.Name = "Y";
            Y.Width = 150;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label2.Location = new Point(76, 32);
            label2.Name = "label2";
            label2.Size = new Size(125, 22);
            label2.TabIndex = 2;
            label2.Text = "Eligir Metodo";
            // 
            // cmbTipoRegresion
            // 
            cmbTipoRegresion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbTipoRegresion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoRegresion.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            cmbTipoRegresion.FormattingEnabled = true;
            cmbTipoRegresion.Items.AddRange(new object[] { "Regresion Polinomial" });
            cmbTipoRegresion.Location = new Point(72, 58);
            cmbTipoRegresion.Name = "cmbTipoRegresion";
            cmbTipoRegresion.Size = new Size(233, 30);
            cmbTipoRegresion.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label1.Location = new Point(455, 0);
            label1.Name = "label1";
            label1.Size = new Size(244, 22);
            label1.TabIndex = 0;
            label1.Text = "METODOS DE REGRESION";
            // 
            // dgvResultados
            // 
            dgvResultados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvResultados.BackgroundColor = SystemColors.Control;
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultados.Location = new Point(12, 475);
            dgvResultados.Name = "dgvResultados";
            dgvResultados.RowHeadersWidth = 62;
            dgvResultados.Size = new Size(1287, 356);
            dgvResultados.TabIndex = 1;
            // 
            // FormRegresion
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1311, 843);
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
        private Label lblTipoRegresion;
    }
}