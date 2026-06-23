namespace Proyecto_MetodosNumericos
{
    partial class FormDiferenciales
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
            lblTipoDiferencial = new Label();
            label2 = new Label();
            cmbMetodosEDO = new ComboBox();
            label1 = new Label();
            txtFuncion = new TextBox();
            label3 = new Label();
            panel1 = new Panel();
            txtH = new TextBox();
            btnRegresar = new Button();
            btnCalcular = new Button();
            lblResultado = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            txtY0 = new TextBox();
            txtX0 = new TextBox();
            txtXf = new TextBox();
            dgvResultados = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            SuspendLayout();
            // 
            // lblTipoDiferencial
            // 
            lblTipoDiferencial.AutoSize = true;
            lblTipoDiferencial.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            lblTipoDiferencial.Location = new Point(716, 37);
            lblTipoDiferencial.Name = "lblTipoDiferencial";
            lblTipoDiferencial.Size = new Size(64, 22);
            lblTipoDiferencial.TabIndex = 22;
            lblTipoDiferencial.Text = "Tema: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label2.Location = new Point(19, 37);
            label2.Name = "label2";
            label2.Size = new Size(125, 22);
            label2.TabIndex = 21;
            label2.Text = "Eligir Metodo";
            // 
            // cmbMetodosEDO
            // 
            cmbMetodosEDO.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodosEDO.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            cmbMetodosEDO.FormattingEnabled = true;
            cmbMetodosEDO.Items.AddRange(new object[] { "Metodo de Euler Simple", "Metodo de Euler Modificado" });
            cmbMetodosEDO.Location = new Point(15, 63);
            cmbMetodosEDO.Name = "cmbMetodosEDO";
            cmbMetodosEDO.Size = new Size(320, 30);
            cmbMetodosEDO.TabIndex = 20;
            cmbMetodosEDO.SelectedIndexChanged += cmbMetodosEDO_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label1.Location = new Point(606, 9);
            label1.Name = "label1";
            label1.Size = new Size(627, 22);
            label1.TabIndex = 19;
            label1.Text = "Aproximacion de Soluciones de Ecuaciones Diferenciales Ordinarias (EDO)\r\n";
            // 
            // txtFuncion
            // 
            txtFuncion.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            txtFuncion.Location = new Point(15, 154);
            txtFuncion.Name = "txtFuncion";
            txtFuncion.Size = new Size(320, 30);
            txtFuncion.TabIndex = 24;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label3.Location = new Point(15, 119);
            label3.Name = "label3";
            label3.Size = new Size(198, 22);
            label3.TabIndex = 23;
            label3.Text = "Escribir Funcion dy/dx";
            // 
            // panel1
            // 
            panel1.Controls.Add(txtH);
            panel1.Controls.Add(btnRegresar);
            panel1.Controls.Add(btnCalcular);
            panel1.Controls.Add(lblResultado);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtY0);
            panel1.Controls.Add(txtX0);
            panel1.Controls.Add(txtXf);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtFuncion);
            panel1.Controls.Add(cmbMetodosEDO);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(lblTipoDiferencial);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1512, 360);
            panel1.TabIndex = 25;
            // 
            // txtH
            // 
            txtH.Location = new Point(1121, 154);
            txtH.Name = "txtH";
            txtH.Size = new Size(65, 31);
            txtH.TabIndex = 37;
            // 
            // btnRegresar
            // 
            btnRegresar.Image = Properties.Resources.esquema_de_boton_circular_de_flecha_hacia_atras_izquierda;
            btnRegresar.ImageAlign = ContentAlignment.MiddleLeft;
            btnRegresar.Location = new Point(796, 292);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(170, 34);
            btnRegresar.TabIndex = 36;
            btnRegresar.Text = "Regresar";
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // btnCalcular
            // 
            btnCalcular.Image = Properties.Resources.simbolo_igual;
            btnCalcular.ImageAlign = ContentAlignment.MiddleLeft;
            btnCalcular.Location = new Point(576, 292);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(179, 34);
            btnCalcular.TabIndex = 35;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            lblResultado.Location = new Point(387, 211);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(98, 22);
            lblResultado.TabIndex = 34;
            lblResultado.Text = "Resultado:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label7.Location = new Point(1064, 119);
            label7.Name = "label7";
            label7.Size = new Size(177, 22);
            label7.TabIndex = 32;
            label7.Text = "Ponga su Valor de H";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label6.Location = new Point(769, 119);
            label6.Name = "label6";
            label6.Size = new Size(263, 22);
            label6.TabIndex = 31;
            label6.Text = "Problemade valor Inicial (PVI)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label5.Location = new Point(576, 119);
            label5.Name = "label5";
            label5.Size = new Size(152, 22);
            label5.TabIndex = 30;
            label5.Text = "Valor Inicial de Y";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label4.Location = new Point(381, 119);
            label4.Name = "label4";
            label4.Size = new Size(154, 22);
            label4.TabIndex = 29;
            label4.Text = "Valor Inicial de X";
            // 
            // txtY0
            // 
            txtY0.Location = new Point(625, 154);
            txtY0.Name = "txtY0";
            txtY0.Size = new Size(65, 31);
            txtY0.TabIndex = 28;
            // 
            // txtX0
            // 
            txtX0.Location = new Point(432, 154);
            txtX0.Name = "txtX0";
            txtX0.Size = new Size(65, 31);
            txtX0.TabIndex = 26;
            // 
            // txtXf
            // 
            txtXf.Location = new Point(863, 154);
            txtXf.Name = "txtXf";
            txtXf.Size = new Size(65, 31);
            txtXf.TabIndex = 25;
            // 
            // dgvResultados
            // 
            dgvResultados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvResultados.BackgroundColor = SystemColors.Control;
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultados.Location = new Point(12, 366);
            dgvResultados.Name = "dgvResultados";
            dgvResultados.RowHeadersWidth = 62;
            dgvResultados.Size = new Size(1488, 303);
            dgvResultados.TabIndex = 26;
            // 
            // FormDiferenciales
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.RosyBrown;
            ClientSize = new Size(1512, 681);
            Controls.Add(dgvResultados);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormDiferenciales";
            Text = "FormDiferenciales";
            WindowState = FormWindowState.Maximized;
            FormClosed += FormDiferenciales_FormClosed;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTipoDiferencial;
        private Label label2;
        private ComboBox cmbMetodosEDO;
        private Label label1;
        private TextBox txtFuncion;
        private Label label3;
        private Panel panel1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox txtY0;
        private TextBox txtX0;
        private TextBox txtXf;
        private Button btnRegresar;
        private Button btnCalcular;
        private Label lblResultado;
        private DataGridView dgvResultados;
        private TextBox txtH;
    }
}