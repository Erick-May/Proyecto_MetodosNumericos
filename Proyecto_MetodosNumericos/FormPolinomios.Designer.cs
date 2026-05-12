namespace Proyecto_MetodosNumericos
{
    partial class FormPolinomios
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
            btnCalcularBairstow = new Button();
            label1 = new Label();
            label2 = new Label();
            txtCoeficientes = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtR = new TextBox();
            txtS = new TextBox();
            label5 = new Label();
            txtToleranciaP = new TextBox();
            label6 = new Label();
            dgvBairstow = new DataGridView();
            btnRegresar = new Button();
            txtX0 = new TextBox();
            txtX1 = new TextBox();
            txtX2 = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            cmbMetodosPolinomio = new ComboBox();
            label10 = new Label();
            lblGradoHN = new Label();
            flpCoeficientes = new FlowLayoutPanel();
            btnGenerarCajas = new Button();
            txtGradoHN = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvBairstow).BeginInit();
            SuspendLayout();
            // 
            // btnCalcularBairstow
            // 
            btnCalcularBairstow.Location = new Point(1074, 157);
            btnCalcularBairstow.Name = "btnCalcularBairstow";
            btnCalcularBairstow.Size = new Size(171, 34);
            btnCalcularBairstow.TabIndex = 0;
            btnCalcularBairstow.Text = "Calcular";
            btnCalcularBairstow.UseVisualStyleBackColor = true;
            btnCalcularBairstow.Click += btnCalcularBairstow_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(549, 10);
            label1.Name = "label1";
            label1.Size = new Size(170, 36);
            label1.TabIndex = 1;
            label1.Text = "METODOS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 120);
            label2.Name = "label2";
            label2.Size = new Size(422, 25);
            label2.TabIndex = 2;
            label2.Text = "Escriba el Numero de los Coeficientes del Polinomio";
            // 
            // txtCoeficientes
            // 
            txtCoeficientes.BackColor = SystemColors.Info;
            txtCoeficientes.Location = new Point(13, 157);
            txtCoeficientes.Name = "txtCoeficientes";
            txtCoeficientes.Size = new Size(421, 31);
            txtCoeficientes.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 203);
            label3.Name = "label3";
            label3.Size = new Size(115, 25);
            label3.TabIndex = 4;
            label3.Text = "ej: 1, 3, -1, -3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(480, 120);
            label4.Name = "label4";
            label4.Size = new Size(28, 25);
            label4.TabIndex = 5;
            label4.Text = "r0";
            // 
            // txtR
            // 
            txtR.BackColor = SystemColors.Info;
            txtR.Location = new Point(449, 160);
            txtR.Name = "txtR";
            txtR.Size = new Size(95, 31);
            txtR.TabIndex = 6;
            // 
            // txtS
            // 
            txtS.BackColor = SystemColors.Info;
            txtS.Location = new Point(563, 159);
            txtS.Name = "txtS";
            txtS.Size = new Size(95, 31);
            txtS.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(589, 120);
            label5.Name = "label5";
            label5.Size = new Size(30, 25);
            label5.TabIndex = 8;
            label5.Text = "s0";
            // 
            // txtToleranciaP
            // 
            txtToleranciaP.BackColor = SystemColors.Info;
            txtToleranciaP.Location = new Point(810, 160);
            txtToleranciaP.Name = "txtToleranciaP";
            txtToleranciaP.Size = new Size(208, 31);
            txtToleranciaP.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(810, 120);
            label6.Name = "label6";
            label6.Size = new Size(89, 25);
            label6.TabIndex = 10;
            label6.Text = "Tolerancia";
            // 
            // dgvBairstow
            // 
            dgvBairstow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBairstow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBairstow.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBairstow.Location = new Point(13, 362);
            dgvBairstow.Name = "dgvBairstow";
            dgvBairstow.RowHeadersWidth = 62;
            dgvBairstow.Size = new Size(1486, 274);
            dgvBairstow.TabIndex = 11;
            // 
            // btnRegresar
            // 
            btnRegresar.Location = new Point(1311, 154);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(112, 34);
            btnRegresar.TabIndex = 12;
            btnRegresar.Text = "Regresar";
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // txtX0
            // 
            txtX0.BackColor = Color.LightGray;
            txtX0.Location = new Point(462, 160);
            txtX0.Name = "txtX0";
            txtX0.Size = new Size(95, 31);
            txtX0.TabIndex = 13;
            // 
            // txtX1
            // 
            txtX1.BackColor = Color.LightGray;
            txtX1.Location = new Point(577, 159);
            txtX1.Name = "txtX1";
            txtX1.Size = new Size(95, 31);
            txtX1.TabIndex = 14;
            // 
            // txtX2
            // 
            txtX2.BackColor = Color.LightGray;
            txtX2.Location = new Point(690, 160);
            txtX2.Name = "txtX2";
            txtX2.Size = new Size(95, 31);
            txtX2.TabIndex = 15;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(501, 120);
            label7.Name = "label7";
            label7.Size = new Size(33, 25);
            label7.TabIndex = 16;
            label7.Text = "X0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(613, 120);
            label8.Name = "label8";
            label8.Size = new Size(33, 25);
            label8.TabIndex = 17;
            label8.Text = "X1";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(710, 120);
            label9.Name = "label9";
            label9.Size = new Size(33, 25);
            label9.TabIndex = 18;
            label9.Text = "X2";
            // 
            // cmbMetodosPolinomio
            // 
            cmbMetodosPolinomio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodosPolinomio.FormattingEnabled = true;
            cmbMetodosPolinomio.Location = new Point(137, 32);
            cmbMetodosPolinomio.Name = "cmbMetodosPolinomio";
            cmbMetodosPolinomio.Size = new Size(229, 33);
            cmbMetodosPolinomio.TabIndex = 19;
            cmbMetodosPolinomio.SelectedIndexChanged += cmbMetodosPolinomio_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(7, 32);
            label10.Name = "label10";
            label10.Size = new Size(124, 25);
            label10.TabIndex = 20;
            label10.Text = "Elegir Metodo";
            // 
            // lblGradoHN
            // 
            lblGradoHN.AutoSize = true;
            lblGradoHN.Location = new Point(13, 242);
            lblGradoHN.Name = "lblGradoHN";
            lblGradoHN.Size = new Size(179, 25);
            lblGradoHN.TabIndex = 21;
            lblGradoHN.Text = "Grado del Polinomio:";
            // 
            // flpCoeficientes
            // 
            flpCoeficientes.Location = new Point(13, 273);
            flpCoeficientes.Name = "flpCoeficientes";
            flpCoeficientes.Size = new Size(1486, 83);
            flpCoeficientes.TabIndex = 22;
            // 
            // btnGenerarCajas
            // 
            btnGenerarCajas.Location = new Point(419, 237);
            btnGenerarCajas.Name = "btnGenerarCajas";
            btnGenerarCajas.Size = new Size(227, 34);
            btnGenerarCajas.TabIndex = 23;
            btnGenerarCajas.Text = "Generar Cajas de Grados";
            btnGenerarCajas.UseVisualStyleBackColor = true;
            btnGenerarCajas.Click += btnGenerarCajas_Click;
            // 
            // txtGradoHN
            // 
            txtGradoHN.Location = new Point(248, 239);
            txtGradoHN.Name = "txtGradoHN";
            txtGradoHN.Size = new Size(150, 31);
            txtGradoHN.TabIndex = 24;
            // 
            // FormPolinomios
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1510, 648);
            Controls.Add(txtGradoHN);
            Controls.Add(btnGenerarCajas);
            Controls.Add(lblGradoHN);
            Controls.Add(flpCoeficientes);
            Controls.Add(label8);
            Controls.Add(txtX1);
            Controls.Add(txtS);
            Controls.Add(label5);
            Controls.Add(txtX0);
            Controls.Add(txtR);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(txtCoeficientes);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label10);
            Controls.Add(cmbMetodosPolinomio);
            Controls.Add(label9);
            Controls.Add(txtX2);
            Controls.Add(btnRegresar);
            Controls.Add(dgvBairstow);
            Controls.Add(label6);
            Controls.Add(txtToleranciaP);
            Controls.Add(label1);
            Controls.Add(btnCalcularBairstow);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormPolinomios";
            Text = "FormPolinomios";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dgvBairstow).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCalcularBairstow;
        private Label label1;
        private Label label2;
        private TextBox txtCoeficientes;
        private Label label3;
        private Label label4;
        private TextBox txtR;
        private TextBox txtS;
        private Label label5;
        private TextBox txtToleranciaP;
        private Label label6;
        private DataGridView dgvBairstow;
        private Button btnRegresar;
        private TextBox txtX0;
        private TextBox txtX1;
        private TextBox txtX2;
        private Label label7;
        private Label label8;
        private Label label9;
        private ComboBox cmbMetodosPolinomio;
        private Label label10;
        private Label lblGradoHN;
        private FlowLayoutPanel flpCoeficientes;
        private Button btnGenerarCajas;
        private TextBox txtGradoHN;
    }
}