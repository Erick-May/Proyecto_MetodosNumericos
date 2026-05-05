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
            ((System.ComponentModel.ISupportInitialize)dgvBairstow).BeginInit();
            SuspendLayout();
            // 
            // btnCalcularBairstow
            // 
            btnCalcularBairstow.Location = new Point(1074, 115);
            btnCalcularBairstow.Name = "btnCalcularBairstow";
            btnCalcularBairstow.Size = new Size(171, 34);
            btnCalcularBairstow.TabIndex = 0;
            btnCalcularBairstow.Text = "Calcular Bairstow";
            btnCalcularBairstow.UseVisualStyleBackColor = true;
            btnCalcularBairstow.Click += btnCalcularBairstow_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(549, 10);
            label1.Name = "label1";
            label1.Size = new Size(375, 36);
            label1.TabIndex = 1;
            label1.Text = "METODO DE BAIRSTOW";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 78);
            label2.Name = "label2";
            label2.Size = new Size(422, 25);
            label2.TabIndex = 2;
            label2.Text = "Escriba el Numero de los Coeficientes del Polinomio";
            // 
            // txtCoeficientes
            // 
            txtCoeficientes.Location = new Point(13, 115);
            txtCoeficientes.Name = "txtCoeficientes";
            txtCoeficientes.Size = new Size(421, 31);
            txtCoeficientes.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 161);
            label3.Name = "label3";
            label3.Size = new Size(115, 25);
            label3.TabIndex = 4;
            label3.Text = "ej: 1, 3, -1, -3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(528, 82);
            label4.Name = "label4";
            label4.Size = new Size(28, 25);
            label4.TabIndex = 5;
            label4.Text = "r0";
            // 
            // txtR
            // 
            txtR.Location = new Point(513, 117);
            txtR.Name = "txtR";
            txtR.Size = new Size(110, 31);
            txtR.TabIndex = 6;
            // 
            // txtS
            // 
            txtS.Location = new Point(646, 117);
            txtS.Name = "txtS";
            txtS.Size = new Size(110, 31);
            txtS.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(655, 82);
            label5.Name = "label5";
            label5.Size = new Size(30, 25);
            label5.TabIndex = 8;
            label5.Text = "s0";
            // 
            // txtToleranciaP
            // 
            txtToleranciaP.Location = new Point(791, 117);
            txtToleranciaP.Name = "txtToleranciaP";
            txtToleranciaP.Size = new Size(208, 31);
            txtToleranciaP.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(791, 82);
            label6.Name = "label6";
            label6.Size = new Size(89, 25);
            label6.TabIndex = 10;
            label6.Text = "Tolerancia";
            // 
            // dgvBairstow
            // 
            dgvBairstow.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBairstow.Location = new Point(12, 212);
            dgvBairstow.Name = "dgvBairstow";
            dgvBairstow.RowHeadersWidth = 62;
            dgvBairstow.Size = new Size(1446, 405);
            dgvBairstow.TabIndex = 11;
            // 
            // btnRegresar
            // 
            btnRegresar.Location = new Point(1311, 112);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(112, 34);
            btnRegresar.TabIndex = 12;
            btnRegresar.Text = "Regresar";
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // FormPolinomios
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1470, 629);
            Controls.Add(btnRegresar);
            Controls.Add(dgvBairstow);
            Controls.Add(label6);
            Controls.Add(txtToleranciaP);
            Controls.Add(label5);
            Controls.Add(txtS);
            Controls.Add(txtR);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtCoeficientes);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCalcularBairstow);
            Name = "FormPolinomios";
            Text = "FormPolinomios";
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
    }
}