namespace Proyecto_MetodosNumericos
{
    partial class FormIntegracion
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
            label10 = new Label();
            lblLimiteY = new Label();
            chkIntegralDoble = new CheckBox();
            nudNy = new NumericUpDown();
            label9 = new Label();
            txtD = new TextBox();
            txtC = new TextBox();
            label8 = new Label();
            label7 = new Label();
            nudN = new NumericUpDown();
            btnRegresar = new Button();
            btnCalcular = new Button();
            lblResultado = new Label();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            txtA = new TextBox();
            txtB = new TextBox();
            txtFuncion = new TextBox();
            label4 = new Label();
            lblTipoIntegracion = new Label();
            label2 = new Label();
            cmbMetodosIntegracion = new ComboBox();
            label1 = new Label();
            dgvResultados = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudNy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudN).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label10);
            panel1.Controls.Add(lblLimiteY);
            panel1.Controls.Add(chkIntegralDoble);
            panel1.Controls.Add(nudNy);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(txtD);
            panel1.Controls.Add(txtC);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(nudN);
            panel1.Controls.Add(btnRegresar);
            panel1.Controls.Add(btnCalcular);
            panel1.Controls.Add(lblResultado);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtA);
            panel1.Controls.Add(txtB);
            panel1.Controls.Add(txtFuncion);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(lblTipoIntegracion);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cmbMetodosIntegracion);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1464, 437);
            panel1.TabIndex = 0;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label10.Location = new Point(1027, 148);
            label10.Name = "label10";
            label10.Size = new Size(139, 22);
            label10.TabIndex = 48;
            label10.Text = "Toque Check si:";
            // 
            // lblLimiteY
            // 
            lblLimiteY.AutoSize = true;
            lblLimiteY.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            lblLimiteY.Location = new Point(490, 241);
            lblLimiteY.Name = "lblLimiteY";
            lblLimiteY.Size = new Size(150, 22);
            lblLimiteY.TabIndex = 47;
            lblLimiteY.Text = "Limites Y [C, D]:";
            lblLimiteY.Visible = false;
            // 
            // chkIntegralDoble
            // 
            chkIntegralDoble.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            chkIntegralDoble.AutoSize = true;
            chkIntegralDoble.Location = new Point(1027, 173);
            chkIntegralDoble.Name = "chkIntegralDoble";
            chkIntegralDoble.Size = new Size(225, 29);
            chkIntegralDoble.TabIndex = 46;
            chkIntegralDoble.Text = "¿Es Una Integral Doble?";
            chkIntegralDoble.UseVisualStyleBackColor = true;
            chkIntegralDoble.CheckedChanged += chkIntegralDoble_CheckedChanged;
            // 
            // nudNy
            // 
            nudNy.Location = new Point(678, 326);
            nudNy.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nudNy.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudNy.Name = "nudNy";
            nudNy.ReadOnly = true;
            nudNy.Size = new Size(79, 31);
            nudNy.TabIndex = 45;
            nudNy.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudNy.Visible = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label9.Location = new Point(666, 289);
            label9.Name = "label9";
            label9.Size = new Size(166, 22);
            label9.TabIndex = 44;
            label9.Text = "Ponga su N  para Y";
            label9.Visible = false;
            // 
            // txtD
            // 
            txtD.Location = new Point(535, 326);
            txtD.Name = "txtD";
            txtD.Size = new Size(65, 31);
            txtD.TabIndex = 43;
            txtD.Visible = false;
            // 
            // txtC
            // 
            txtC.Location = new Point(342, 326);
            txtC.Name = "txtC";
            txtC.Size = new Size(65, 31);
            txtC.TabIndex = 42;
            txtC.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label8.Location = new Point(491, 289);
            label8.Name = "label8";
            label8.Size = new Size(149, 22);
            label8.TabIndex = 41;
            label8.Text = "Limite Superio D";
            label8.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label7.Location = new Point(299, 289);
            label7.Name = "label7";
            label7.Size = new Size(149, 22);
            label7.TabIndex = 40;
            label7.Text = "Limite Inferior C";
            label7.Visible = false;
            // 
            // nudN
            // 
            nudN.Location = new Point(678, 172);
            nudN.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nudN.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudN.Name = "nudN";
            nudN.ReadOnly = true;
            nudN.Size = new Size(79, 31);
            nudN.TabIndex = 31;
            nudN.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnRegresar
            // 
            btnRegresar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRegresar.Location = new Point(1152, 349);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(165, 34);
            btnRegresar.TabIndex = 30;
            btnRegresar.Text = "Regresar";
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // btnCalcular
            // 
            btnCalcular.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCalcular.Location = new Point(933, 349);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(165, 34);
            btnCalcular.TabIndex = 29;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // lblResultado
            // 
            lblResultado.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            lblResultado.Location = new Point(910, 241);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(98, 22);
            lblResultado.TabIndex = 28;
            lblResultado.Text = "Resultado:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label6.Location = new Point(666, 138);
            label6.Name = "label6";
            label6.Size = new Size(108, 22);
            label6.TabIndex = 27;
            label6.Text = "Ponga su N ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label5.Location = new Point(491, 138);
            label5.Name = "label5";
            label5.Size = new Size(155, 22);
            label5.TabIndex = 26;
            label5.Text = "Limite Superior B";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label3.Location = new Point(299, 138);
            label3.Name = "label3";
            label3.Size = new Size(147, 22);
            label3.TabIndex = 25;
            label3.Text = "Limite Inferior A";
            // 
            // txtA
            // 
            txtA.Location = new Point(342, 172);
            txtA.Name = "txtA";
            txtA.Size = new Size(65, 31);
            txtA.TabIndex = 23;
            // 
            // txtB
            // 
            txtB.Location = new Point(535, 172);
            txtB.Name = "txtB";
            txtB.Size = new Size(65, 31);
            txtB.TabIndex = 22;
            // 
            // txtFuncion
            // 
            txtFuncion.Location = new Point(12, 172);
            txtFuncion.Name = "txtFuncion";
            txtFuncion.Size = new Size(261, 31);
            txtFuncion.TabIndex = 21;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label4.Location = new Point(16, 138);
            label4.Name = "label4";
            label4.Size = new Size(193, 22);
            label4.TabIndex = 20;
            label4.Text = "Escriba la funcion f(x)";
            // 
            // lblTipoIntegracion
            // 
            lblTipoIntegracion.AutoSize = true;
            lblTipoIntegracion.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            lblTipoIntegracion.Location = new Point(693, 37);
            lblTipoIntegracion.Name = "lblTipoIntegracion";
            lblTipoIntegracion.Size = new Size(64, 22);
            lblTipoIntegracion.TabIndex = 18;
            lblTipoIntegracion.Text = "Tema: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label2.Location = new Point(16, 37);
            label2.Name = "label2";
            label2.Size = new Size(125, 22);
            label2.TabIndex = 17;
            label2.Text = "Eligir Metodo";
            // 
            // cmbMetodosIntegracion
            // 
            cmbMetodosIntegracion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodosIntegracion.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            cmbMetodosIntegracion.FormattingEnabled = true;
            cmbMetodosIntegracion.Items.AddRange(new object[] { "Simpson 1/3", "Simpson 3/8", "Integracion de Romberg" });
            cmbMetodosIntegracion.Location = new Point(12, 63);
            cmbMetodosIntegracion.Name = "cmbMetodosIntegracion";
            cmbMetodosIntegracion.Size = new Size(320, 30);
            cmbMetodosIntegracion.TabIndex = 16;
            cmbMetodosIntegracion.SelectedIndexChanged += cmbMetodosIntegracion_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label1.Location = new Point(716, 9);
            label1.Name = "label1";
            label1.Size = new Size(341, 22);
            label1.TabIndex = 15;
            label1.Text = "Integración Numerica Por Aproximación";
            // 
            // dgvResultados
            // 
            dgvResultados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultados.Location = new Point(0, 443);
            dgvResultados.Name = "dgvResultados";
            dgvResultados.ReadOnly = true;
            dgvResultados.RowHeadersWidth = 62;
            dgvResultados.Size = new Size(1456, 301);
            dgvResultados.TabIndex = 1;
            // 
            // FormIntegracion
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1464, 756);
            Controls.Add(dgvResultados);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormIntegracion";
            Text = "FormIntegracion";
            WindowState = FormWindowState.Maximized;
            FormClosed += FormIntegracion_FormClosed;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudNy).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudN).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblTipoIntegracion;
        private Label label2;
        private ComboBox cmbMetodosIntegracion;
        private Label label1;
        private Label label4;
        private Label label5;
        private Label label3;
        private TextBox txtA;
        private TextBox txtB;
        private TextBox txtFuncion;
        private Label lblResultado;
        private Label label6;
        private DataGridView dgvResultados;
        private Button btnRegresar;
        private Button btnCalcular;
        private NumericUpDown nudN;
        private Label lblLimiteY;
        private CheckBox chkIntegralDoble;
        private NumericUpDown nudNy;
        private Label label9;
        private TextBox txtD;
        private TextBox txtC;
        private Label label8;
        private Label label7;
        private Label label10;
    }
}