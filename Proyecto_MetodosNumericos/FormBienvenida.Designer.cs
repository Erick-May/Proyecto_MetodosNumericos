namespace Proyecto_MetodosNumericos
{
    partial class FormBienvenida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBienvenida));
            btnEntrar = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            panel1 = new Panel();
            label2 = new Label();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // btnEntrar
            // 
            btnEntrar.BackColor = Color.LightSkyBlue;
            btnEntrar.Cursor = Cursors.Hand;
            btnEntrar.FlatStyle = FlatStyle.Flat;
            btnEntrar.Font = new Font("Comic Sans MS", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEntrar.ForeColor = Color.Black;
            btnEntrar.Image = Properties.Resources.usuario__1_;
            btnEntrar.ImageAlign = ContentAlignment.MiddleRight;
            btnEntrar.Location = new Point(207, 516);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(300, 86);
            btnEntrar.TabIndex = 0;
            btnEntrar.Text = "ENTRAR";
            btnEntrar.UseVisualStyleBackColor = false;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.Logo_Circular_IteraCore_1;
            pictureBox1.Location = new Point(131, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(456, 393);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(24, 438);
            label1.Name = "label1";
            label1.Size = new Size(631, 50);
            label1.TabIndex = 2;
            label1.Text = "¡Resuelve tus ejercicios en un 2x3!";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1689, 788);
            panel1.TabIndex = 3;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Comic Sans MS", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(3, 644);
            label2.Name = "label2";
            label2.Size = new Size(620, 135);
            label2.TabIndex = 4;
            label2.Text = "Desarrollado por:\r\nIng. Antonella Franchesca Davila Cano\r\nIng. Erick Lenin Mayorquin Martinez\r\n";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnEntrar);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new Point(512, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(695, 626);
            panel2.TabIndex = 3;
            // 
            // FormBienvenida
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            BackColor = SystemColors.Control;
            BackgroundImage = Properties.Resources.Matematica_Fondo_11;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1689, 788);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormBienvenida";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormBienvenida";
            WindowState = FormWindowState.Maximized;
            FormClosed += FormBienvenida_FormClosed;
            Load += FormBienvenida_Load;
            Resize += FormBienvenida_Resize;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnEntrar;
        private PictureBox pictureBox1;
        private Label label1;
        private Panel panel1;
        private Panel panel2;
        private Label label2;
    }
}