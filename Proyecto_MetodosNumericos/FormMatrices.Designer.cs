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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMatrices));
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
            label9 = new Label();
            btnManual = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMatrices).BeginInit();
            SuspendLayout();
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label10.Location = new Point(11, 54);
            label10.Name = "label10";
            label10.Size = new Size(128, 22);
            label10.TabIndex = 23;
            label10.Text = "Elegir Metodo";
            // 
            // cmbMetodosMatrices
            // 
            cmbMetodosMatrices.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodosMatrices.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            cmbMetodosMatrices.FormattingEnabled = true;
            cmbMetodosMatrices.Items.AddRange(new object[] { "Newton-Raphson no lineales" });
            cmbMetodosMatrices.Location = new Point(141, 54);
            cmbMetodosMatrices.Name = "cmbMetodosMatrices";
            cmbMetodosMatrices.Size = new Size(307, 30);
            cmbMetodosMatrices.TabIndex = 22;
            cmbMetodosMatrices.SelectedIndexChanged += cmbMetodosMatrices_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label1.Location = new Point(508, 9);
            label1.Name = "label1";
            label1.Size = new Size(247, 22);
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
            label3.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label3.Location = new Point(450, 122);
            label3.Name = "label3";
            label3.Size = new Size(151, 22);
            label3.TabIndex = 27;
            label3.Text = "Valores Iniciales ";
            // 
            // txtTolerancia
            // 
            txtTolerancia.Location = new Point(712, 161);
            txtTolerancia.Name = "txtTolerancia";
            txtTolerancia.Size = new Size(150, 31);
            txtTolerancia.TabIndex = 28;
            txtTolerancia.KeyPress += txtTolerancia_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 10F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.Location = new Point(712, 122);
            label4.Name = "label4";
            label4.Size = new Size(97, 22);
            label4.TabIndex = 29;
            label4.Text = "Tolerancia";
            // 
            // btnCalcular
            // 
            btnCalcular.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            btnCalcular.Image = Properties.Resources.simbolo_igual;
            btnCalcular.ImageAlign = ContentAlignment.MiddleLeft;
            btnCalcular.Location = new Point(890, 161);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(272, 34);
            btnCalcular.TabIndex = 30;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // btnRegresar
            // 
            btnRegresar.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            btnRegresar.Image = Properties.Resources.esquema_de_boton_circular_de_flecha_hacia_atras_izquierda;
            btnRegresar.ImageAlign = ContentAlignment.MiddleLeft;
            btnRegresar.Location = new Point(912, 239);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(217, 34);
            btnRegresar.TabIndex = 31;
            btnRegresar.Text = "Regresar";
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // dgvMatrices
            // 
            dgvMatrices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMatrices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMatrices.BackgroundColor = SystemColors.Control;
            dgvMatrices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMatrices.Location = new Point(15, 343);
            dgvMatrices.Name = "dgvMatrices";
            dgvMatrices.RowHeadersWidth = 62;
            dgvMatrices.Size = new Size(1319, 368);
            dgvMatrices.TabIndex = 32;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label2.Location = new Point(23, 109);
            label2.Name = "label2";
            label2.Size = new Size(378, 44);
            label2.TabIndex = 33;
            label2.Text = "Escriba sus ecuaciones (toque enter\r\ndespues de escribir 1 ecuacion y asi separar)";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            label9.Location = new Point(1085, 60);
            label9.Name = "label9";
            label9.Size = new Size(137, 22);
            label9.TabIndex = 35;
            label9.Text = "Manual de uso:";
            // 
            // btnManual
            // 
            btnManual.Font = new Font("Times New Roman", 10F, FontStyle.Italic);
            btnManual.Location = new Point(1222, 54);
            btnManual.Name = "btnManual";
            btnManual.Size = new Size(112, 34);
            btnManual.TabIndex = 34;
            btnManual.Text = "Manual";
            btnManual.UseVisualStyleBackColor = true;
            btnManual.Click += btnManual_Click;
            // 
            // FormMatrices
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(1346, 723);
            Controls.Add(label9);
            Controls.Add(btnManual);
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormMatrices";
            Text = "FormMatrices";
            WindowState = FormWindowState.Maximized;
            FormClosed += FormMatrices_FormClosed;
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
        private Label label9;
        private Button btnManual;
    }
}