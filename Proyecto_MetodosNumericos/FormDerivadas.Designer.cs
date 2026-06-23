namespace Proyecto_MetodosNumericos
{
    partial class FormDerivadas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDerivadas));
            label1 = new Label();
            panel1 = new Panel();
            lblResultado = new Label();
            btnRegresar = new Button();
            btnCalcular = new Button();
            label5 = new Label();
            nudPuntos = new NumericUpDown();
            chkCentrada = new CheckBox();
            chkAtras = new CheckBox();
            chkAdelante = new CheckBox();
            label4 = new Label();
            txtXEval = new TextBox();
            label3 = new Label();
            label2 = new Label();
            dgvDatos = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPuntos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label1.Location = new Point(618, 0);
            label1.Name = "label1";
            label1.Size = new Size(274, 22);
            label1.TabIndex = 23;
            label1.Text = "DIFERENCIACION NUMERICA";
            // 
            // panel1
            // 
            panel1.Controls.Add(lblResultado);
            panel1.Controls.Add(btnRegresar);
            panel1.Controls.Add(btnCalcular);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(nudPuntos);
            panel1.Controls.Add(chkCentrada);
            panel1.Controls.Add(chkAtras);
            panel1.Controls.Add(chkAdelante);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtXEval);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dgvDatos);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1454, 737);
            panel1.TabIndex = 24;
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblResultado.Location = new Point(836, 259);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(145, 32);
            lblResultado.TabIndex = 39;
            lblResultado.Text = "Resultados";
            // 
            // btnRegresar
            // 
            btnRegresar.Image = Properties.Resources.esquema_de_boton_circular_de_flecha_hacia_atras_izquierda;
            btnRegresar.ImageAlign = ContentAlignment.MiddleLeft;
            btnRegresar.Location = new Point(530, 383);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(165, 34);
            btnRegresar.TabIndex = 38;
            btnRegresar.Text = "Regresar";
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // btnCalcular
            // 
            btnCalcular.Image = Properties.Resources.simbolo_igual;
            btnCalcular.ImageAlign = ContentAlignment.MiddleLeft;
            btnCalcular.Location = new Point(305, 383);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(165, 34);
            btnCalcular.TabIndex = 37;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label5.Location = new Point(806, 82);
            label5.Name = "label5";
            label5.Size = new Size(212, 44);
            label5.TabIndex = 33;
            label5.Text = "Ponga el número de filas\r\nde la Tabla\r\n";
            // 
            // nudPuntos
            // 
            nudPuntos.Location = new Point(836, 129);
            nudPuntos.Name = "nudPuntos";
            nudPuntos.ReadOnly = true;
            nudPuntos.Size = new Size(150, 31);
            nudPuntos.TabIndex = 32;
            nudPuntos.ValueChanged += nudPuntos_ValueChanged;
            // 
            // chkCentrada
            // 
            chkCentrada.AutoSize = true;
            chkCentrada.Location = new Point(25, 219);
            chkCentrada.Name = "chkCentrada";
            chkCentrada.Size = new Size(109, 29);
            chkCentrada.TabIndex = 31;
            chkCentrada.Text = "Centrada";
            chkCentrada.UseVisualStyleBackColor = true;
            // 
            // chkAtras
            // 
            chkAtras.AutoSize = true;
            chkAtras.Location = new Point(25, 174);
            chkAtras.Name = "chkAtras";
            chkAtras.Size = new Size(127, 29);
            chkAtras.TabIndex = 30;
            chkAtras.Text = "Hacia Atras";
            chkAtras.UseVisualStyleBackColor = true;
            // 
            // chkAdelante
            // 
            chkAdelante.AutoSize = true;
            chkAdelante.Location = new Point(25, 129);
            chkAdelante.Name = "chkAdelante";
            chkAdelante.Size = new Size(156, 29);
            chkAdelante.TabIndex = 29;
            chkAdelante.Text = "Hacia Adelante";
            chkAdelante.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label4.Location = new Point(25, 85);
            label4.Name = "label4";
            label4.Size = new Size(219, 22);
            label4.TabIndex = 28;
            label4.Text = "¿Tipo De Diferenciacion?";
            // 
            // txtXEval
            // 
            txtXEval.Location = new Point(1128, 129);
            txtXEval.Name = "txtXEval";
            txtXEval.Size = new Size(150, 31);
            txtXEval.TabIndex = 27;
            txtXEval.KeyPress += txtXEval_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label3.Location = new Point(1151, 104);
            label3.Name = "label3";
            label3.Size = new Size(104, 22);
            label3.TabIndex = 26;
            label3.Text = "X a evaluar";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label2.Location = new Point(362, 82);
            label2.Name = "label2";
            label2.Size = new Size(271, 22);
            label2.TabIndex = 25;
            label2.Text = "Escribe los datos de tu tabla x/y";
            // 
            // dgvDatos
            // 
            dgvDatos.BackgroundColor = SystemColors.Control;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Location = new Point(316, 110);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.RowHeadersWidth = 62;
            dgvDatos.Size = new Size(368, 225);
            dgvDatos.TabIndex = 24;
            dgvDatos.DataError += dgvDatos_DataError;
            dgvDatos.EditingControlShowing += dgvDatos_EditingControlShowing;
            // 
            // FormDerivadas
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Plum;
            ClientSize = new Size(1454, 737);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormDerivadas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormDerivadas";
            FormClosed += FormDerivadas_FormClosed;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPuntos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private DataGridView dgvDatos;
        private Label label4;
        private TextBox txtXEval;
        private Label label3;
        private Label label2;
        private Label label5;
        private NumericUpDown nudPuntos;
        private CheckBox chkCentrada;
        private CheckBox chkAtras;
        private CheckBox chkAdelante;
        private Button btnRegresar;
        private Button btnCalcular;
        private Label lblResultado;
    }
}