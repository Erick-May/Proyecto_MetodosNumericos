namespace Proyecto_MetodosNumericos
{
    partial class FormPrincipal
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
            cmbMetodos = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            dgvIteraciones = new DataGridView();
            txtFuncion = new TextBox();
            txtA = new TextBox();
            txtB = new TextBox();
            txtTolerancia = new TextBox();
            btnCalcular = new Button();
            lblResultado = new Label();
            label6 = new Label();
            label7 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIteraciones).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(cmbMetodos);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Font = new Font("Times New Roman", 9.75F);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2, 2, 2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(959, 28);
            panel1.TabIndex = 0;
            // 
            // cmbMetodos
            // 
            cmbMetodos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodos.FormattingEnabled = true;
            cmbMetodos.Items.AddRange(new object[] { "Biseccion", "Regla Falsa", "Newton-Raphson", "Secante" });
            cmbMetodos.Location = new Point(125, 3);
            cmbMetodos.Margin = new Padding(2, 2, 2, 2);
            cmbMetodos.Name = "cmbMetodos";
            cmbMetodos.Size = new Size(231, 23);
            cmbMetodos.TabIndex = 1;
            cmbMetodos.SelectedIndexChanged += cmbMetodos_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 6);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 0;
            label1.Text = "Elegir Metodo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 9.75F);
            label2.Location = new Point(8, 43);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(94, 15);
            label2.TabIndex = 1;
            label2.Text = "Escribir Funcion";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 9.75F);
            label3.Location = new Point(399, 48);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(17, 15);
            label3.TabIndex = 2;
            label3.Text = "A";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 9.75F);
            label4.Location = new Point(625, 48);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(15, 15);
            label4.TabIndex = 3;
            label4.Text = "B";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 9.75F);
            label5.Location = new Point(8, 90);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(62, 15);
            label5.TabIndex = 4;
            label5.Text = "Tolerancia";
            // 
            // dgvIteraciones
            // 
            dgvIteraciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIteraciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIteraciones.Location = new Point(0, 140);
            dgvIteraciones.Margin = new Padding(2, 2, 2, 2);
            dgvIteraciones.Name = "dgvIteraciones";
            dgvIteraciones.RowHeadersWidth = 62;
            dgvIteraciones.Size = new Size(1052, 238);
            dgvIteraciones.TabIndex = 5;
            // 
            // txtFuncion
            // 
            txtFuncion.Font = new Font("Times New Roman", 9.75F);
            txtFuncion.Location = new Point(125, 40);
            txtFuncion.Margin = new Padding(2, 2, 2, 2);
            txtFuncion.Name = "txtFuncion";
            txtFuncion.Size = new Size(231, 22);
            txtFuncion.TabIndex = 6;
            // 
            // txtA
            // 
            txtA.Font = new Font("Times New Roman", 9.75F);
            txtA.Location = new Point(418, 43);
            txtA.Margin = new Padding(2, 2, 2, 2);
            txtA.Name = "txtA";
            txtA.Size = new Size(106, 22);
            txtA.TabIndex = 7;
            // 
            // txtB
            // 
            txtB.Font = new Font("Times New Roman", 9.75F);
            txtB.Location = new Point(644, 43);
            txtB.Margin = new Padding(2, 2, 2, 2);
            txtB.Name = "txtB";
            txtB.Size = new Size(106, 22);
            txtB.TabIndex = 8;
            // 
            // txtTolerancia
            // 
            txtTolerancia.Font = new Font("Times New Roman", 9.75F);
            txtTolerancia.Location = new Point(125, 82);
            txtTolerancia.Margin = new Padding(2, 2, 2, 2);
            txtTolerancia.Name = "txtTolerancia";
            txtTolerancia.Size = new Size(106, 22);
            txtTolerancia.TabIndex = 9;
            // 
            // btnCalcular
            // 
            btnCalcular.Font = new Font("Times New Roman", 9.75F);
            btnCalcular.Location = new Point(847, 41);
            btnCalcular.Margin = new Padding(2, 2, 2, 2);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(86, 28);
            btnCalcular.TabIndex = 10;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Times New Roman", 9.75F);
            lblResultado.Location = new Point(474, 90);
            lblResultado.Margin = new Padding(2, 0, 2, 0);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(64, 15);
            lblResultado.TabIndex = 11;
            lblResultado.Text = "Resultado:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 9.75F);
            label6.Location = new Point(535, 48);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 12;
            label6.Text = "label6";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 9.75F);
            label7.Location = new Point(763, 48);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(38, 15);
            label7.TabIndex = 13;
            label7.Text = "label7";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(959, 385);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(lblResultado);
            Controls.Add(btnCalcular);
            Controls.Add(txtTolerancia);
            Controls.Add(txtB);
            Controls.Add(txtA);
            Controls.Add(txtFuncion);
            Controls.Add(dgvIteraciones);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "FormPrincipal";
            Text = "FormPrincipal";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIteraciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private ComboBox cmbMetodos;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private DataGridView dgvIteraciones;
        private TextBox txtFuncion;
        private TextBox txtA;
        private TextBox txtB;
        private TextBox txtTolerancia;
        private Button btnCalcular;
        private Label lblResultado;
        private Label label6;
        private Label label7;
    }
}