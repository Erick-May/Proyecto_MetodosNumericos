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
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1516, 47);
            panel1.TabIndex = 0;
            // 
            // cmbMetodos
            // 
            cmbMetodos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodos.FormattingEnabled = true;
            cmbMetodos.Items.AddRange(new object[] { "Biseccion", "Regla Falsa", "Newton-Raphson", "Secante" });
            cmbMetodos.Location = new Point(142, 9);
            cmbMetodos.Name = "cmbMetodos";
            cmbMetodos.Size = new Size(232, 33);
            cmbMetodos.TabIndex = 1;
            cmbMetodos.SelectedIndexChanged += cmbMetodos_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(124, 25);
            label1.TabIndex = 0;
            label1.Text = "Elegir Metodo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 61);
            label2.Name = "label2";
            label2.Size = new Size(135, 25);
            label2.TabIndex = 1;
            label2.Text = "Escribir Funcion";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 103);
            label3.Name = "label3";
            label3.Size = new Size(24, 25);
            label3.TabIndex = 2;
            label3.Text = "A";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 159);
            label4.Name = "label4";
            label4.Size = new Size(22, 25);
            label4.TabIndex = 3;
            label4.Text = "B";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 209);
            label5.Name = "label5";
            label5.Size = new Size(89, 25);
            label5.TabIndex = 4;
            label5.Text = "Tolerancia";
            // 
            // dgvIteraciones
            // 
            dgvIteraciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIteraciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIteraciones.Location = new Point(15, 251);
            dgvIteraciones.Name = "dgvIteraciones";
            dgvIteraciones.RowHeadersWidth = 62;
            dgvIteraciones.Size = new Size(1489, 378);
            dgvIteraciones.TabIndex = 5;
            // 
            // txtFuncion
            // 
            txtFuncion.Location = new Point(178, 58);
            txtFuncion.Name = "txtFuncion";
            txtFuncion.Size = new Size(328, 31);
            txtFuncion.TabIndex = 6;
            // 
            // txtA
            // 
            txtA.Location = new Point(178, 103);
            txtA.Name = "txtA";
            txtA.Size = new Size(150, 31);
            txtA.TabIndex = 7;
            // 
            // txtB
            // 
            txtB.Location = new Point(178, 153);
            txtB.Name = "txtB";
            txtB.Size = new Size(150, 31);
            txtB.TabIndex = 8;
            // 
            // txtTolerancia
            // 
            txtTolerancia.Location = new Point(178, 206);
            txtTolerancia.Name = "txtTolerancia";
            txtTolerancia.Size = new Size(150, 31);
            txtTolerancia.TabIndex = 9;
            // 
            // btnCalcular
            // 
            btnCalcular.Location = new Point(764, 153);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(112, 34);
            btnCalcular.TabIndex = 10;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Location = new Point(764, 209);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(94, 25);
            lblResultado.TabIndex = 11;
            lblResultado.Text = "Resultado:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(350, 107);
            label6.Name = "label6";
            label6.Size = new Size(59, 25);
            label6.TabIndex = 12;
            label6.Text = "label6";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(349, 157);
            label7.Name = "label7";
            label7.Size = new Size(59, 25);
            label7.TabIndex = 13;
            label7.Text = "label7";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1516, 641);
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