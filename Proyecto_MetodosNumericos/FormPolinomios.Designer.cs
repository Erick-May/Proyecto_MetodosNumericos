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
            label11 = new Label();
            btnManual = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvBairstow).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCalcularBairstow
            // 
            btnCalcularBairstow.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            btnCalcularBairstow.Location = new Point(1196, 157);
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
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(710, 9);
            label1.Name = "label1";
            label1.Size = new Size(123, 27);
            label1.TabIndex = 1;
            label1.Text = "METODOS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label2.Location = new Point(12, 94);
            label2.Name = "label2";
            label2.Size = new Size(439, 22);
            label2.TabIndex = 2;
            label2.Text = "Escriba el Numero de los Coeficientes del Polinomio";
            // 
            // txtCoeficientes
            // 
            txtCoeficientes.BackColor = SystemColors.Info;
            txtCoeficientes.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            txtCoeficientes.Location = new Point(14, 145);
            txtCoeficientes.Name = "txtCoeficientes";
            txtCoeficientes.Size = new Size(421, 30);
            txtCoeficientes.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label3.Location = new Point(14, 120);
            label3.Name = "label3";
            label3.Size = new Size(121, 22);
            label3.TabIndex = 4;
            label3.Text = "ej: 1, 3, -1, -3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label4.Location = new Point(480, 120);
            label4.Name = "label4";
            label4.Size = new Size(28, 22);
            label4.TabIndex = 5;
            label4.Text = "r0";
            // 
            // txtR
            // 
            txtR.BackColor = SystemColors.Info;
            txtR.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            txtR.Location = new Point(451, 145);
            txtR.Name = "txtR";
            txtR.Size = new Size(95, 30);
            txtR.TabIndex = 6;
            txtR.KeyPress += txtR_KeyPress;
            // 
            // txtS
            // 
            txtS.BackColor = SystemColors.Info;
            txtS.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            txtS.Location = new Point(563, 145);
            txtS.Name = "txtS";
            txtS.Size = new Size(95, 30);
            txtS.TabIndex = 7;
            txtS.KeyPress += txtS_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label5.Location = new Point(589, 120);
            label5.Name = "label5";
            label5.Size = new Size(28, 22);
            label5.TabIndex = 8;
            label5.Text = "s0";
            // 
            // txtToleranciaP
            // 
            txtToleranciaP.BackColor = SystemColors.Info;
            txtToleranciaP.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            txtToleranciaP.Location = new Point(810, 160);
            txtToleranciaP.Name = "txtToleranciaP";
            txtToleranciaP.Size = new Size(208, 30);
            txtToleranciaP.TabIndex = 9;
            txtToleranciaP.KeyPress += txtToleranciaP_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label6.Location = new Point(810, 120);
            label6.Name = "label6";
            label6.Size = new Size(97, 22);
            label6.TabIndex = 10;
            label6.Text = "Tolerancia";
            // 
            // dgvBairstow
            // 
            dgvBairstow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBairstow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBairstow.BackgroundColor = SystemColors.Control;
            dgvBairstow.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBairstow.Location = new Point(13, 362);
            dgvBairstow.Name = "dgvBairstow";
            dgvBairstow.RowHeadersWidth = 62;
            dgvBairstow.Size = new Size(1486, 274);
            dgvBairstow.TabIndex = 11;
            // 
            // btnRegresar
            // 
            btnRegresar.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            btnRegresar.Location = new Point(1387, 156);
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
            txtX0.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            txtX0.Location = new Point(451, 181);
            txtX0.Name = "txtX0";
            txtX0.Size = new Size(95, 30);
            txtX0.TabIndex = 13;
            txtX0.KeyPress += txtX0_KeyPress;
            // 
            // txtX1
            // 
            txtX1.BackColor = Color.LightGray;
            txtX1.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            txtX1.Location = new Point(563, 181);
            txtX1.Name = "txtX1";
            txtX1.Size = new Size(95, 30);
            txtX1.TabIndex = 14;
            txtX1.KeyPress += txtX1_KeyPress;
            // 
            // txtX2
            // 
            txtX2.BackColor = Color.LightGray;
            txtX2.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            txtX2.Location = new Point(674, 181);
            txtX2.Name = "txtX2";
            txtX2.Size = new Size(95, 30);
            txtX2.TabIndex = 15;
            txtX2.KeyPress += txtX2_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label7.Location = new Point(480, 156);
            label7.Name = "label7";
            label7.Size = new Size(32, 22);
            label7.TabIndex = 16;
            label7.Text = "X0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label8.Location = new Point(589, 156);
            label8.Name = "label8";
            label8.Size = new Size(32, 22);
            label8.TabIndex = 17;
            label8.Text = "X1";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label9.Location = new Point(696, 153);
            label9.Name = "label9";
            label9.Size = new Size(32, 22);
            label9.TabIndex = 18;
            label9.Text = "X2";
            // 
            // cmbMetodosPolinomio
            // 
            cmbMetodosPolinomio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodosPolinomio.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            cmbMetodosPolinomio.FormattingEnabled = true;
            cmbMetodosPolinomio.Location = new Point(137, 31);
            cmbMetodosPolinomio.Name = "cmbMetodosPolinomio";
            cmbMetodosPolinomio.Size = new Size(229, 30);
            cmbMetodosPolinomio.TabIndex = 19;
            cmbMetodosPolinomio.SelectedIndexChanged += cmbMetodosPolinomio_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label10.Location = new Point(7, 31);
            label10.Name = "label10";
            label10.Size = new Size(128, 22);
            label10.TabIndex = 20;
            label10.Text = "Elegir Metodo";
            // 
            // lblGradoHN
            // 
            lblGradoHN.AutoSize = true;
            lblGradoHN.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            lblGradoHN.Location = new Point(14, 189);
            lblGradoHN.Name = "lblGradoHN";
            lblGradoHN.Size = new Size(188, 22);
            lblGradoHN.TabIndex = 21;
            lblGradoHN.Text = "Grado del Polinomio:";
            // 
            // flpCoeficientes
            // 
            flpCoeficientes.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            flpCoeficientes.Location = new Point(13, 273);
            flpCoeficientes.Name = "flpCoeficientes";
            flpCoeficientes.Size = new Size(1486, 83);
            flpCoeficientes.TabIndex = 22;
            // 
            // btnGenerarCajas
            // 
            btnGenerarCajas.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            btnGenerarCajas.Location = new Point(208, 233);
            btnGenerarCajas.Name = "btnGenerarCajas";
            btnGenerarCajas.Size = new Size(227, 34);
            btnGenerarCajas.TabIndex = 23;
            btnGenerarCajas.Text = "Generar Cajas de Grados";
            btnGenerarCajas.UseVisualStyleBackColor = true;
            btnGenerarCajas.Click += btnGenerarCajas_Click;
            // 
            // txtGradoHN
            // 
            txtGradoHN.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            txtGradoHN.Location = new Point(245, 189);
            txtGradoHN.Name = "txtGradoHN";
            txtGradoHN.Size = new Size(150, 30);
            txtGradoHN.TabIndex = 24;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label11.Location = new Point(1250, 37);
            label11.Name = "label11";
            label11.Size = new Size(137, 22);
            label11.TabIndex = 26;
            label11.Text = "Manual de uso:";
            // 
            // btnManual
            // 
            btnManual.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnManual.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            btnManual.Location = new Point(1387, 31);
            btnManual.Name = "btnManual";
            btnManual.Size = new Size(112, 34);
            btnManual.TabIndex = 25;
            btnManual.Text = "Manual";
            btnManual.UseVisualStyleBackColor = true;
            btnManual.Click += btnManual_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(cmbMetodosPolinomio);
            panel1.Controls.Add(btnManual);
            panel1.Controls.Add(label10);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1510, 73);
            panel1.TabIndex = 27;
            // 
            // FormPolinomios
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Pink;
            ClientSize = new Size(1510, 648);
            Controls.Add(label7);
            Controls.Add(panel1);
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
            Controls.Add(label4);
            Controls.Add(txtCoeficientes);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label9);
            Controls.Add(txtX2);
            Controls.Add(btnRegresar);
            Controls.Add(dgvBairstow);
            Controls.Add(label6);
            Controls.Add(txtToleranciaP);
            Controls.Add(btnCalcularBairstow);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormPolinomios";
            Text = "FormPolinomios";
            WindowState = FormWindowState.Maximized;
            FormClosed += FormPolinomios_FormClosed;
            Load += FormPolinomios_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBairstow).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private Label label11;
        private Button btnManual;
        private Panel panel1;
    }
}