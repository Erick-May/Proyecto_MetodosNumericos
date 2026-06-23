namespace Proyecto_MetodosNumericos
{
    partial class FormTaylor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTaylor));
            panel1 = new Panel();
            lblResultado = new Label();
            btnRegresar = new Button();
            btnCalcular = new Button();
            label5 = new Label();
            nudGrado = new NumericUpDown();
            label4 = new Label();
            label3 = new Label();
            txtC = new TextBox();
            txtA = new TextBox();
            txtX = new TextBox();
            label2 = new Label();
            label1 = new Label();
            dgvDerivadas = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudGrado).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDerivadas).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(lblResultado);
            panel1.Controls.Add(btnRegresar);
            panel1.Controls.Add(btnCalcular);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(nudGrado);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtC);
            panel1.Controls.Add(txtA);
            panel1.Controls.Add(txtX);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1489, 410);
            panel1.TabIndex = 0;
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblResultado.Location = new Point(76, 210);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(145, 32);
            lblResultado.TabIndex = 41;
            lblResultado.Text = "Resultados";
            // 
            // btnRegresar
            // 
            btnRegresar.Image = Properties.Resources.esquema_de_boton_circular_de_flecha_hacia_atras_izquierda;
            btnRegresar.ImageAlign = ContentAlignment.MiddleLeft;
            btnRegresar.Location = new Point(1248, 148);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(165, 34);
            btnRegresar.TabIndex = 40;
            btnRegresar.Text = "Regresar";
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // btnCalcular
            // 
            btnCalcular.Image = Properties.Resources.simbolo_igual;
            btnCalcular.ImageAlign = ContentAlignment.MiddleLeft;
            btnCalcular.Location = new Point(1027, 148);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(165, 34);
            btnCalcular.TabIndex = 39;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label5.Location = new Point(748, 115);
            label5.Name = "label5";
            label5.Size = new Size(181, 22);
            label5.TabIndex = 31;
            label5.Text = "Grado del Polinomio";
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // nudGrado
            // 
            nudGrado.Location = new Point(783, 148);
            nudGrado.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
            nudGrado.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudGrado.Name = "nudGrado";
            nudGrado.ReadOnly = true;
            nudGrado.Size = new Size(85, 31);
            nudGrado.TabIndex = 30;
            nudGrado.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudGrado.ValueChanged += nudGrado_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label4.Location = new Point(489, 101);
            label4.Name = "label4";
            label4.Size = new Size(210, 44);
            label4.TabIndex = 29;
            label4.Text = "Punto para Lagrange (ε)\r\n(A < ε < X)";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label3.Location = new Point(321, 114);
            label3.Name = "label3";
            label3.Size = new Size(93, 22);
            label3.TabIndex = 28;
            label3.Text = "Centro (a)";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtC
            // 
            txtC.Location = new Point(552, 148);
            txtC.Name = "txtC";
            txtC.Size = new Size(85, 31);
            txtC.TabIndex = 27;
            // 
            // txtA
            // 
            txtA.Location = new Point(321, 148);
            txtA.Name = "txtA";
            txtA.Size = new Size(85, 31);
            txtA.TabIndex = 26;
            // 
            // txtX
            // 
            txtX.Location = new Point(125, 148);
            txtX.Name = "txtX";
            txtX.Size = new Size(85, 31);
            txtX.TabIndex = 25;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 10F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(86, 114);
            label2.Name = "label2";
            label2.Size = new Size(163, 22);
            label2.TabIndex = 24;
            label2.Text = "Valor a evaluar (x)";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label1.Location = new Point(523, 0);
            label1.Name = "label1";
            label1.Size = new Size(477, 44);
            label1.TabIndex = 23;
            label1.Text = "APROXIMACIONES A PARTIR DE LA SERIE DE TAYLOR\r\nY RESTO DE LAGRANGE";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // dgvDerivadas
            // 
            dgvDerivadas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDerivadas.BackgroundColor = SystemColors.Control;
            dgvDerivadas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDerivadas.Location = new Point(24, 416);
            dgvDerivadas.Name = "dgvDerivadas";
            dgvDerivadas.RowHeadersWidth = 62;
            dgvDerivadas.Size = new Size(1465, 345);
            dgvDerivadas.TabIndex = 32;
            // 
            // FormTaylor
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Bisque;
            ClientSize = new Size(1489, 773);
            Controls.Add(panel1);
            Controls.Add(dgvDerivadas);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormTaylor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormTaylor";
            FormClosed += FormTaylor_FormClosed;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudGrado).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDerivadas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label3;
        private TextBox txtC;
        private TextBox txtA;
        private TextBox txtX;
        private Label label2;
        private Label label4;
        private Label label5;
        private NumericUpDown nudGrado;
        private DataGridView dgvDerivadas;
        private Button btnRegresar;
        private Button btnCalcular;
        private Label lblResultado;
    }
}