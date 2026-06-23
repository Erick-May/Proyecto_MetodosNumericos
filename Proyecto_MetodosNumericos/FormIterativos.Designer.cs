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
            btnRegresar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudVariables).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSistema).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label2.Location = new Point(21, 108);
            label2.Name = "label2";
            label2.Size = new Size(178, 22);
            label2.TabIndex = 23;
            label2.Text = "Tamaño de la Matriz";
            // 
            // nudVariables
            // 
            nudVariables.Location = new Point(23, 142);
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
            txtValoresIniciales.Location = new Point(1077, 141);
            txtValoresIniciales.Multiline = true;
            txtValoresIniciales.Name = "txtValoresIniciales";
            txtValoresIniciales.Size = new Size(80, 250);
            txtValoresIniciales.TabIndex = 25;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label3.Location = new Point(419, 108);
            label3.Name = "label3";
            label3.Size = new Size(332, 22);
            label3.TabIndex = 26;
            label3.Text = "Matriz del Sistema de Ecuaciones A y B";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label4.Location = new Point(1049, 108);
            label4.Name = "label4";
            label4.Size = new Size(151, 22);
            label4.TabIndex = 27;
            label4.Text = "Valores Iniciales ";
            // 
            // dgvSistema
            // 
            dgvSistema.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSistema.BackgroundColor = SystemColors.Control;
            dgvSistema.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSistema.Location = new Point(323, 141);
            dgvSistema.Name = "dgvSistema";
            dgvSistema.RowHeadersWidth = 62;
            dgvSistema.Size = new Size(650, 250);
            dgvSistema.TabIndex = 28;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label5.Location = new Point(1339, 108);
            label5.Name = "label5";
            label5.Size = new Size(97, 22);
            label5.TabIndex = 29;
            label5.Text = "Tolerancia";
            // 
            // txtTolerancia
            // 
            txtTolerancia.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            txtTolerancia.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            txtTolerancia.Location = new Point(1311, 140);
            txtTolerancia.Name = "txtTolerancia";
            txtTolerancia.Size = new Size(158, 30);
            txtTolerancia.TabIndex = 30;
            // 
            // cmbMetodos
            // 
            cmbMetodos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodos.FormattingEnabled = true;
            cmbMetodos.Items.AddRange(new object[] { "Gauss-Seidel", "Jacobi" });
            cmbMetodos.Location = new Point(23, 38);
            cmbMetodos.Name = "cmbMetodos";
            cmbMetodos.Size = new Size(222, 33);
            cmbMetodos.TabIndex = 31;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 10F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.Location = new Point(21, 13);
            label6.Name = "label6";
            label6.Size = new Size(128, 22);
            label6.TabIndex = 32;
            label6.Text = "Elegir Metodo";
            // 
            // btnCalcular
            // 
            btnCalcular.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnCalcular.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            btnCalcular.Image = Properties.Resources.simbolo_igual;
            btnCalcular.ImageAlign = ContentAlignment.MiddleLeft;
            btnCalcular.Location = new Point(1298, 219);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(171, 34);
            btnCalcular.TabIndex = 33;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += BtnCalcular_Click;
            // 
            // dgvResultados
            // 
            dgvResultados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResultados.BackgroundColor = SystemColors.Control;
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultados.Location = new Point(12, 413);
            dgvResultados.Name = "dgvResultados";
            dgvResultados.RowHeadersWidth = 62;
            dgvResultados.Size = new Size(1762, 336);
            dgvResultados.TabIndex = 34;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            btnLimpiar.Location = new Point(1566, 137);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(158, 34);
            btnLimpiar.TabIndex = 35;
            btnLimpiar.Text = "Limpiar Tabla";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label1.Location = new Point(869, 0);
            label1.Name = "label1";
            label1.Size = new Size(212, 22);
            label1.TabIndex = 22;
            label1.Text = "METODOS ITERATIVOS";
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightCoral;
            panel1.Controls.Add(btnRegresar);
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
            panel1.Size = new Size(1762, 398);
            panel1.TabIndex = 36;
            // 
            // btnRegresar
            // 
            btnRegresar.Image = Properties.Resources.esquema_de_boton_circular_de_flecha_hacia_atras_izquierda;
            btnRegresar.ImageAlign = ContentAlignment.MiddleLeft;
            btnRegresar.Location = new Point(1566, 217);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(158, 34);
            btnRegresar.TabIndex = 36;
            btnRegresar.Text = "Regresar";
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // FormIterativos
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCoral;
            ClientSize = new Size(1786, 779);
            Controls.Add(panel1);
            Controls.Add(dgvResultados);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormIterativos";
            WindowState = FormWindowState.Maximized;
            FormClosed += FormIterativos_FormClosed;
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
        private Button btnRegresar;
    }
}