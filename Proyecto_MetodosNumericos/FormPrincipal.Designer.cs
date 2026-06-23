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
            label9 = new Label();
            btnManual = new Button();
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
            txtFxOriginal = new TextBox();
            label10 = new Label();
            lblFxOriginal = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIteraciones).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label9);
            panel1.Controls.Add(btnManual);
            panel1.Controls.Add(cmbMetodos);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Font = new Font("Times New Roman", 9.75F);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1669, 47);
            panel1.TabIndex = 0;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label9.Location = new Point(1408, 11);
            label9.Name = "label9";
            label9.Size = new Size(137, 22);
            label9.TabIndex = 3;
            label9.Text = "Manual de uso:";
            // 
            // btnManual
            // 
            btnManual.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnManual.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            btnManual.Location = new Point(1545, 5);
            btnManual.Name = "btnManual";
            btnManual.Size = new Size(112, 34);
            btnManual.TabIndex = 2;
            btnManual.Text = "Manual";
            btnManual.UseVisualStyleBackColor = true;
            btnManual.Click += btnManual_Click;
            // 
            // cmbMetodos
            // 
            cmbMetodos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodos.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            cmbMetodos.FormattingEnabled = true;
            cmbMetodos.Items.AddRange(new object[] { "Biseccion", "Regla Falsa", "Newton-Raphson", "Secante", "Punto Fijo", "Serie de Taylor y Lagrange", "Otros Metodos (Polinomios)", "Otros Metodos (Matrices)", "Otros Metodos (Iterativos)", "Metodos de Regresion", "Metodos Interpolantes", "Integracion Numerica x Aproximacion", "Aproximacion de Soluciones de EDO", "Diferenciacion Numerica" });
            cmbMetodos.Location = new Point(194, 9);
            cmbMetodos.Name = "cmbMetodos";
            cmbMetodos.Size = new Size(328, 30);
            cmbMetodos.TabIndex = 1;
            cmbMetodos.SelectedIndexChanged += cmbMetodos_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label1.Location = new Point(11, 10);
            label1.Name = "label1";
            label1.Size = new Size(128, 22);
            label1.TabIndex = 0;
            label1.Text = "Elegir Metodo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label2.Location = new Point(11, 111);
            label2.Name = "label2";
            label2.Size = new Size(182, 22);
            label2.TabIndex = 1;
            label2.Text = "Escribir Funcion f(x)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label3.Location = new Point(575, 114);
            label3.Name = "label3";
            label3.Size = new Size(21, 22);
            label3.TabIndex = 2;
            label3.Text = "A";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label4.Location = new Point(958, 109);
            label4.Name = "label4";
            label4.Size = new Size(22, 22);
            label4.TabIndex = 3;
            label4.Text = "B";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label5.Location = new Point(11, 200);
            label5.Name = "label5";
            label5.Size = new Size(97, 22);
            label5.TabIndex = 4;
            label5.Text = "Tolerancia";
            // 
            // dgvIteraciones
            // 
            dgvIteraciones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvIteraciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIteraciones.BackgroundColor = SystemColors.Control;
            dgvIteraciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIteraciones.Location = new Point(11, 248);
            dgvIteraciones.Name = "dgvIteraciones";
            dgvIteraciones.RowHeadersWidth = 62;
            dgvIteraciones.Size = new Size(1646, 382);
            dgvIteraciones.TabIndex = 5;
            // 
            // txtFuncion
            // 
            txtFuncion.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            txtFuncion.Location = new Point(194, 106);
            txtFuncion.Name = "txtFuncion";
            txtFuncion.Size = new Size(328, 30);
            txtFuncion.TabIndex = 6;
            // 
            // txtA
            // 
            txtA.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            txtA.Location = new Point(605, 106);
            txtA.Name = "txtA";
            txtA.Size = new Size(150, 30);
            txtA.TabIndex = 7;
            txtA.KeyPress += txtA_KeyPress;
            // 
            // txtB
            // 
            txtB.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            txtB.Location = new Point(987, 106);
            txtB.Name = "txtB";
            txtB.Size = new Size(150, 30);
            txtB.TabIndex = 8;
            txtB.KeyPress += txtB_KeyPress;
            // 
            // txtTolerancia
            // 
            txtTolerancia.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            txtTolerancia.Location = new Point(179, 197);
            txtTolerancia.Name = "txtTolerancia";
            txtTolerancia.Size = new Size(150, 30);
            txtTolerancia.TabIndex = 9;
            txtTolerancia.KeyPress += txtTolerancia_KeyPress;
            // 
            // btnCalcular
            // 
            btnCalcular.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            btnCalcular.Location = new Point(1078, 180);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(280, 47);
            btnCalcular.TabIndex = 10;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            lblResultado.Location = new Point(531, 182);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(98, 22);
            lblResultado.TabIndex = 11;
            lblResultado.Text = "Resultado:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label6.Location = new Point(761, 114);
            label6.Name = "label6";
            label6.Size = new Size(61, 22);
            label6.TabIndex = 12;
            label6.Text = "label6";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label7.Location = new Point(1143, 109);
            label7.Name = "label7";
            label7.Size = new Size(61, 22);
            label7.TabIndex = 13;
            label7.Text = "label7";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label8.Location = new Point(12, 151);
            label8.Name = "label8";
            label8.Size = new Size(61, 22);
            label8.TabIndex = 14;
            label8.Text = "label8";
            // 
            // txtFxOriginal
            // 
            txtFxOriginal.Location = new Point(194, 53);
            txtFxOriginal.Name = "txtFxOriginal";
            txtFxOriginal.Size = new Size(328, 31);
            txtFxOriginal.TabIndex = 15;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label10.Location = new Point(11, 59);
            label10.Name = "label10";
            label10.Size = new Size(105, 22);
            label10.TabIndex = 16;
            label10.Text = "Escribe f(x)";
            // 
            // lblFxOriginal
            // 
            lblFxOriginal.AutoSize = true;
            lblFxOriginal.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            lblFxOriginal.Location = new Point(559, 62);
            lblFxOriginal.Name = "lblFxOriginal";
            lblFxOriginal.Size = new Size(116, 22);
            lblFxOriginal.TabIndex = 17;
            lblFxOriginal.Text = "f(x) original:";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            ClientSize = new Size(1669, 642);
            Controls.Add(lblFxOriginal);
            Controls.Add(label10);
            Controls.Add(txtFxOriginal);
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
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormPrincipal";
            Text = "FormPrincipal";
            WindowState = FormWindowState.Maximized;
            FormClosed += FormPrincipal_FormClosed;
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
        private Label label9;
        private Button btnManual;
        private TextBox txtFxOriginal;
        private Label label10;
        private Label lblFxOriginal;
    }
}