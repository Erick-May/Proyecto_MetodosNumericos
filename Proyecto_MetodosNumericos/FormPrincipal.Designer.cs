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
            label8 = new Label();
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
            panel1.Name = "panel1";
            panel1.Size = new Size(1370, 47);
            panel1.TabIndex = 0;
            // 
            // cmbMetodos
            // 
            cmbMetodos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodos.FormattingEnabled = true;
            cmbMetodos.Items.AddRange(new object[] { "Biseccion", "Regla Falsa", "Newton-Raphson", "Secante", "Punto Fijo" });
            cmbMetodos.Location = new Point(179, 5);
            cmbMetodos.Name = "cmbMetodos";
            cmbMetodos.Size = new Size(328, 30);
            cmbMetodos.TabIndex = 1;
            cmbMetodos.SelectedIndexChanged += cmbMetodos_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 10);
            label1.Name = "label1";
            label1.Size = new Size(125, 22);
            label1.TabIndex = 0;
            label1.Text = "Elegir Metodo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 9.75F);
            label2.Location = new Point(11, 72);
            label2.Name = "label2";
            label2.Size = new Size(177, 22);
            label2.TabIndex = 1;
            label2.Text = "Escribir Funcion f(x)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 9.75F);
            label3.Location = new Point(567, 75);
            label3.Name = "label3";
            label3.Size = new Size(24, 22);
            label3.TabIndex = 2;
            label3.Text = "A";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 9.75F);
            label4.Location = new Point(893, 72);
            label4.Name = "label4";
            label4.Size = new Size(23, 22);
            label4.TabIndex = 3;
            label4.Text = "B";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 9.75F);
            label5.Location = new Point(11, 177);
            label5.Name = "label5";
            label5.Size = new Size(95, 22);
            label5.TabIndex = 4;
            label5.Text = "Tolerancia";
            // 
            // dgvIteraciones
            // 
            dgvIteraciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIteraciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIteraciones.Location = new Point(0, 233);
            dgvIteraciones.Name = "dgvIteraciones";
            dgvIteraciones.RowHeadersWidth = 62;
            dgvIteraciones.Size = new Size(1503, 397);
            dgvIteraciones.TabIndex = 5;
            // 
            // txtFuncion
            // 
            txtFuncion.Font = new Font("Times New Roman", 9.75F);
            txtFuncion.Location = new Point(194, 67);
            txtFuncion.Name = "txtFuncion";
            txtFuncion.Size = new Size(328, 30);
            txtFuncion.TabIndex = 6;
            // 
            // txtA
            // 
            txtA.Font = new Font("Times New Roman", 9.75F);
            txtA.Location = new Point(597, 67);
            txtA.Name = "txtA";
            txtA.Size = new Size(150, 30);
            txtA.TabIndex = 7;
            // 
            // txtB
            // 
            txtB.Font = new Font("Times New Roman", 9.75F);
            txtB.Location = new Point(922, 69);
            txtB.Name = "txtB";
            txtB.Size = new Size(150, 30);
            txtB.TabIndex = 8;
            // 
            // txtTolerancia
            // 
            txtTolerancia.Font = new Font("Times New Roman", 9.75F);
            txtTolerancia.Location = new Point(179, 174);
            txtTolerancia.Name = "txtTolerancia";
            txtTolerancia.Size = new Size(150, 30);
            txtTolerancia.TabIndex = 9;
            // 
            // btnCalcular
            // 
            btnCalcular.Font = new Font("Times New Roman", 9.75F);
            btnCalcular.Location = new Point(1220, 63);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(123, 47);
            btnCalcular.TabIndex = 10;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Times New Roman", 9.75F);
            lblResultado.Location = new Point(677, 150);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(95, 22);
            lblResultado.TabIndex = 11;
            lblResultado.Text = "Resultado:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 9.75F);
            label6.Location = new Point(753, 75);
            label6.Name = "label6";
            label6.Size = new Size(60, 22);
            label6.TabIndex = 12;
            label6.Text = "label6";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 9.75F);
            label7.Location = new Point(1078, 72);
            label7.Name = "label7";
            label7.Size = new Size(60, 22);
            label7.TabIndex = 13;
            label7.Text = "label7";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(11, 118);
            label8.Name = "label8";
            label8.Size = new Size(51, 20);
            label8.TabIndex = 14;
            label8.Text = "label8";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1370, 642);
            Controls.Add(label8);
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
        private Label label8;
    }
}