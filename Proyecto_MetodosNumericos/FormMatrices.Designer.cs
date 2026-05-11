namespace Proyecto_MetodosNumericos
{
    partial class FormMatrices
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
            label10 = new Label();
            cmbMetodosMatrices = new ComboBox();
            label1 = new Label();
            txtSistemasNL = new TextBox();
            txtValoresInicialesNL = new TextBox();
            label3 = new Label();
            txtTolerancia = new TextBox();
            label4 = new Label();
            btnCalcular = new Button();
            btnRegresar = new Button();
            dgvMatrices = new DataGridView();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMatrices).BeginInit();
            SuspendLayout();
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(11, 54);
            label10.Name = "label10";
            label10.Size = new Size(124, 25);
            label10.TabIndex = 23;
            label10.Text = "Elegir Metodo";
            // 
            // cmbMetodosMatrices
            // 
            cmbMetodosMatrices.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodosMatrices.FormattingEnabled = true;
            cmbMetodosMatrices.Items.AddRange(new object[] { "Newton-Raphson no lineales" });
            cmbMetodosMatrices.Location = new Point(141, 54);
            cmbMetodosMatrices.Name = "cmbMetodosMatrices";
            cmbMetodosMatrices.Size = new Size(307, 33);
            cmbMetodosMatrices.TabIndex = 22;
            cmbMetodosMatrices.SelectedIndexChanged += cmbMetodosMatrices_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(508, 9);
            label1.Name = "label1";
            label1.Size = new Size(425, 36);
            label1.TabIndex = 21;
            label1.Text = "METODOS PARA MATRICES";
            // 
            // txtSistemasNL
            // 
            txtSistemasNL.Location = new Point(15, 161);
            txtSistemasNL.Multiline = true;
            txtSistemasNL.Name = "txtSistemasNL";
            txtSistemasNL.Size = new Size(359, 162);
            txtSistemasNL.TabIndex = 24;
            // 
            // txtValoresInicialesNL
            // 
            txtValoresInicialesNL.Location = new Point(435, 161);
            txtValoresInicialesNL.Multiline = true;
            txtValoresInicialesNL.Name = "txtValoresInicialesNL";
            txtValoresInicialesNL.Size = new Size(229, 162);
            txtValoresInicialesNL.TabIndex = 26;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(450, 122);
            label3.Name = "label3";
            label3.Size = new Size(140, 25);
            label3.TabIndex = 27;
            label3.Text = "Valores Iniciales ";
            // 
            // txtTolerancia
            // 
            txtTolerancia.Location = new Point(712, 161);
            txtTolerancia.Name = "txtTolerancia";
            txtTolerancia.Size = new Size(150, 31);
            txtTolerancia.TabIndex = 28;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(712, 122);
            label4.Name = "label4";
            label4.Size = new Size(89, 25);
            label4.TabIndex = 29;
            label4.Text = "Tolerancia";
            // 
            // btnCalcular
            // 
            btnCalcular.Location = new Point(712, 217);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(272, 34);
            btnCalcular.TabIndex = 30;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // btnRegresar
            // 
            btnRegresar.Location = new Point(712, 271);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(150, 34);
            btnRegresar.TabIndex = 31;
            btnRegresar.Text = "Regresar";
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // dgvMatrices
            // 
            dgvMatrices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMatrices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMatrices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMatrices.Location = new Point(15, 343);
            dgvMatrices.Name = "dgvMatrices";
            dgvMatrices.RowHeadersWidth = 62;
            dgvMatrices.Size = new Size(1241, 368);
            dgvMatrices.TabIndex = 32;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 109);
            label2.Name = "label2";
            label2.Size = new Size(361, 50);
            label2.TabIndex = 33;
            label2.Text = "Escriba sus ecuaciones (toque enter\r\ndespues de escribir 1 ecuacion y asi separar)";
            // 
            // FormMatrices
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1268, 723);
            Controls.Add(label2);
            Controls.Add(dgvMatrices);
            Controls.Add(btnRegresar);
            Controls.Add(btnCalcular);
            Controls.Add(label4);
            Controls.Add(txtTolerancia);
            Controls.Add(label3);
            Controls.Add(txtValoresInicialesNL);
            Controls.Add(txtSistemasNL);
            Controls.Add(label10);
            Controls.Add(cmbMetodosMatrices);
            Controls.Add(label1);
            Name = "FormMatrices";
            Text = "FormMatrices";
            ((System.ComponentModel.ISupportInitialize)dgvMatrices).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label10;
        private ComboBox cmbMetodosMatrices;
        private Label label1;
        private TextBox txtSistemasNL;
        private TextBox txtValoresInicialesNL;
        private Label label3;
        private TextBox txtTolerancia;
        private Label label4;
        private Button btnCalcular;
        private Button btnRegresar;
        private DataGridView dgvMatrices;
        private Label label2;
    }
}