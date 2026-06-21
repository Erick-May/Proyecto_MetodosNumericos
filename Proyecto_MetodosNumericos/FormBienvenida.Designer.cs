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
            btnEntrar = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnEntrar
            // 
            btnEntrar.BackColor = Color.RoyalBlue;
            btnEntrar.Cursor = Cursors.Hand;
            btnEntrar.FlatStyle = FlatStyle.Flat;
            btnEntrar.Font = new Font("Comic Sans MS", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEntrar.ForeColor = Color.White;
            btnEntrar.Location = new Point(467, 494);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(217, 64);
            btnEntrar.TabIndex = 0;
            btnEntrar.Text = "ENTRAR";
            btnEntrar.UseVisualStyleBackColor = false;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.IteraCore_Logo;
            pictureBox1.Location = new Point(374, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(416, 369);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(300, 413);
            label1.Name = "label1";
            label1.Size = new Size(561, 45);
            label1.TabIndex = 2;
            label1.Text = "¡Resuelve tus ejercicios en un 2x3!";
            // 
            // FormBienvenida
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(1117, 599);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(btnEntrar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormBienvenida";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormBienvenida";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEntrar;
        private PictureBox pictureBox1;
        private Label label1;
    }
}