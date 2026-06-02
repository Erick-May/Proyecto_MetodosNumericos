namespace Proyecto_MetodosNumericos
{
    partial class FormIterativos
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
            label2 = new Label();
            nudVariables = new NumericUpDown();
            txtValoresIniciales = new TextBox();
            label3 = new Label();
            label4 = new Label();
            dgvSistema = new DataGridView();
            label5 = new Label();
            txtTolerancia = new TextBox();
            cmbMetodos = new ComboBox();
            label6 = new Label();
            btnCalcular = new Button();
            dgvResultados = new DataGridView();
            btnLimpiar = new Button();
            label1 = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)nudVariables).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSistema).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(25, 108);
            label2.Name = "label2";
            label2.Size = new Size(171, 25);
            label2.TabIndex = 23;
            label2.Text = "Tamaño de la Matriz";
            // 
            // nudVariables
            // 
            nudVariables.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            nudVariables.Location = new Point(53, 147);
            nudVariables.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudVariables.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            nudVariables.Name = "nudVariables";
            nudVariables.ReadOnly = true;
            nudVariables.Size = new Size(96, 31);
            nudVariables.TabIndex = 24;
            nudVariables.TextAlign = HorizontalAlignment.Center;
            nudVariables.Value = new decimal(new int[] { 2, 0, 0, 0 });
            nudVariables.ValueChanged += NudVariables_ValueChanged;
            // 
            // txtValoresIniciales
            // 
            txtValoresIniciales.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtValoresIniciales.Location = new Point(762, 135);
            txtValoresIniciales.Multiline = true;
            txtValoresIniciales.Name = "txtValoresIniciales";
            txtValoresIniciales.Size = new Size(80, 196);
            txtValoresIniciales.TabIndex = 25;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(313, 102);
            label3.Name = "label3";
            label3.Size = new Size(319, 25);
            label3.TabIndex = 26;
            label3.Text = "Matriz del Sistema de Ecuaciones A y B";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(745, 102);
            label4.Name = "label4";
            label4.Size = new Size(140, 25);
            label4.TabIndex = 27;
            label4.Text = "Valores Iniciales ";
            // 
            // dgvSistema
            // 
            dgvSistema.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            dgvSistema.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSistema.Location = new Point(278, 135);
            dgvSistema.Name = "dgvSistema";
            dgvSistema.RowHeadersWidth = 62;
            dgvSistema.Size = new Size(417, 196);
            dgvSistema.TabIndex = 28;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(1028, 106);
            label5.Name = "label5";
            label5.Size = new Size(89, 25);
            label5.TabIndex = 29;
            label5.Text = "Tolerancia";
            // 
            // txtTolerancia
            // 
            txtTolerancia.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtTolerancia.Location = new Point(994, 135);
            txtTolerancia.Name = "txtTolerancia";
            txtTolerancia.Size = new Size(158, 31);
            txtTolerancia.TabIndex = 30;
            // 
            // cmbMetodos
            // 
            cmbMetodos.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cmbMetodos.FormattingEnabled = true;
            cmbMetodos.Items.AddRange(new object[] { "Gauss-Seidel", "Jacobi" });
            cmbMetodos.Location = new Point(11, 39);
            cmbMetodos.Name = "cmbMetodos";
            cmbMetodos.Size = new Size(222, 33);
            cmbMetodos.TabIndex = 31;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(11, 11);
            label6.Name = "label6";
            label6.Size = new Size(124, 25);
            label6.TabIndex = 32;
            label6.Text = "Elegir Metodo";
            // 
            // btnCalcular
            // 
            btnCalcular.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCalcular.Location = new Point(953, 210);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(241, 34);
            btnCalcular.TabIndex = 33;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += BtnCalcular_Click;
            // 
            // dgvResultados
            // 
            dgvResultados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultados.Location = new Point(12, 367);
            dgvResultados.Name = "dgvResultados";
            dgvResultados.RowHeadersWidth = 62;
            dgvResultados.Size = new Size(1294, 400);
            dgvResultados.TabIndex = 34;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLimpiar.Location = new Point(994, 268);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(158, 34);
            btnLimpiar.TabIndex = 35;
            btnLimpiar.Text = "Limpiar Tabla";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label1.Location = new Point(555, 11);
            label1.Name = "label1";
            label1.Size = new Size(212, 22);
            label1.TabIndex = 22;
            label1.Text = "METODOS ITERATIVOS";
            // 
            // panel1
            // 
            panel1.Controls.Add(label6);
            panel1.Controls.Add(btnLimpiar);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(cmbMetodos);
            panel1.Controls.Add(btnCalcular);
            panel1.Controls.Add(txtTolerancia);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(nudVariables);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtValoresIniciales);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(dgvSistema);
            panel1.Location = new Point(12, 9);
            panel1.Name = "panel1";
            panel1.Size = new Size(1294, 352);
            panel1.TabIndex = 36;
            // 
            // FormIterativos
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1318, 779);
            Controls.Add(panel1);
            Controls.Add(dgvResultados);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormIterativos";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)nudVariables).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSistema).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label2;
        private NumericUpDown nudVariables;
        private TextBox txtValoresIniciales;
        private Label label3;
        private Label label4;
        private DataGridView dgvSistema;
        private Label label5;
        private TextBox txtTolerancia;
        private ComboBox cmbMetodos;
        private Label label6;
        private Button btnCalcular;
        private DataGridView dgvResultados;
        private Button btnLimpiar;
        private Label label1;
        private Panel panel1;
    }
}