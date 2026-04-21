namespace Proyecto_MetodosNumericos
{
    partial class FormInicioSesion
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtUsuario = new TextBox();
            txtContrasena = new TextBox();
            btnIniciarSesion = new Button();
            btnMostrarRegistro = new Button();
            pnlRegistro = new Panel();
            btnCerrarPanel = new Button();
            btnCrearCuenta = new Button();
            txtConfirmarContrasena = new TextBox();
            txtNuevaContrasena = new TextBox();
            txtNuevoUsuario = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            pnlRegistro.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 9.75F);
            label1.Location = new Point(202, 18);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(110, 15);
            label1.TabIndex = 0;
            label1.Text = "INICIO DE SESION";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 9.75F);
            label2.Location = new Point(47, 65);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 1;
            label2.Text = "Usuario";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 9.75F);
            label3.Location = new Point(47, 108);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(68, 15);
            label3.TabIndex = 2;
            label3.Text = "Contraseña";
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Times New Roman", 9.75F);
            txtUsuario.Location = new Point(136, 57);
            txtUsuario.Margin = new Padding(2, 2, 2, 2);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(220, 22);
            txtUsuario.TabIndex = 3;
            // 
            // txtContrasena
            // 
            txtContrasena.Font = new Font("Times New Roman", 9.75F);
            txtContrasena.Location = new Point(136, 100);
            txtContrasena.Margin = new Padding(2, 2, 2, 2);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PasswordChar = '*';
            txtContrasena.Size = new Size(218, 22);
            txtContrasena.TabIndex = 4;
            txtContrasena.UseSystemPasswordChar = true;
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.Font = new Font("Times New Roman", 9.75F);
            btnIniciarSesion.Location = new Point(70, 152);
            btnIniciarSesion.Margin = new Padding(2, 2, 2, 2);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(124, 30);
            btnIniciarSesion.TabIndex = 5;
            btnIniciarSesion.Text = "Iniciar Sesion ";
            btnIniciarSesion.UseVisualStyleBackColor = true;
            btnIniciarSesion.Click += btnIniciarSesion_Click;
            // 
            // btnMostrarRegistro
            // 
            btnMostrarRegistro.Font = new Font("Times New Roman", 9.75F);
            btnMostrarRegistro.Location = new Point(255, 152);
            btnMostrarRegistro.Margin = new Padding(2, 2, 2, 2);
            btnMostrarRegistro.Name = "btnMostrarRegistro";
            btnMostrarRegistro.Size = new Size(120, 30);
            btnMostrarRegistro.TabIndex = 6;
            btnMostrarRegistro.Text = "Registrarse";
            btnMostrarRegistro.UseVisualStyleBackColor = true;
            btnMostrarRegistro.Click += btnMostrarRegistro_Click;
            // 
            // pnlRegistro
            // 
            pnlRegistro.Controls.Add(btnCerrarPanel);
            pnlRegistro.Controls.Add(btnCrearCuenta);
            pnlRegistro.Controls.Add(txtConfirmarContrasena);
            pnlRegistro.Controls.Add(txtNuevaContrasena);
            pnlRegistro.Controls.Add(txtNuevoUsuario);
            pnlRegistro.Controls.Add(label7);
            pnlRegistro.Controls.Add(label6);
            pnlRegistro.Controls.Add(label5);
            pnlRegistro.Controls.Add(label4);
            pnlRegistro.Font = new Font("Times New Roman", 9.75F);
            pnlRegistro.Location = new Point(32, 196);
            pnlRegistro.Margin = new Padding(2, 2, 2, 2);
            pnlRegistro.Name = "pnlRegistro";
            pnlRegistro.Size = new Size(412, 283);
            pnlRegistro.TabIndex = 7;
            pnlRegistro.Visible = false;
            // 
            // btnCerrarPanel
            // 
            btnCerrarPanel.Location = new Point(223, 176);
            btnCerrarPanel.Margin = new Padding(2, 2, 2, 2);
            btnCerrarPanel.Name = "btnCerrarPanel";
            btnCerrarPanel.Size = new Size(116, 31);
            btnCerrarPanel.TabIndex = 8;
            btnCerrarPanel.Text = "Cancelar";
            btnCerrarPanel.UseVisualStyleBackColor = true;
            btnCerrarPanel.Click += btnCerrarPanel_Click;
            // 
            // btnCrearCuenta
            // 
            btnCrearCuenta.Location = new Point(41, 176);
            btnCrearCuenta.Margin = new Padding(2, 2, 2, 2);
            btnCrearCuenta.Name = "btnCrearCuenta";
            btnCrearCuenta.Size = new Size(121, 31);
            btnCrearCuenta.TabIndex = 7;
            btnCrearCuenta.Text = "Crear Cuenta";
            btnCrearCuenta.UseVisualStyleBackColor = true;
            btnCrearCuenta.Click += btnCrearCuenta_Click;
            // 
            // txtConfirmarContrasena
            // 
            txtConfirmarContrasena.Location = new Point(157, 122);
            txtConfirmarContrasena.Margin = new Padding(2, 2, 2, 2);
            txtConfirmarContrasena.Name = "txtConfirmarContrasena";
            txtConfirmarContrasena.PasswordChar = '*';
            txtConfirmarContrasena.Size = new Size(209, 22);
            txtConfirmarContrasena.TabIndex = 6;
            txtConfirmarContrasena.UseSystemPasswordChar = true;
            // 
            // txtNuevaContrasena
            // 
            txtNuevaContrasena.Location = new Point(157, 78);
            txtNuevaContrasena.Margin = new Padding(2, 2, 2, 2);
            txtNuevaContrasena.Name = "txtNuevaContrasena";
            txtNuevaContrasena.PasswordChar = '*';
            txtNuevaContrasena.Size = new Size(211, 22);
            txtNuevaContrasena.TabIndex = 5;
            txtNuevaContrasena.UseSystemPasswordChar = true;
            // 
            // txtNuevoUsuario
            // 
            txtNuevoUsuario.Location = new Point(157, 38);
            txtNuevoUsuario.Margin = new Padding(2, 2, 2, 2);
            txtNuevoUsuario.Name = "txtNuevoUsuario";
            txtNuevoUsuario.Size = new Size(209, 22);
            txtNuevoUsuario.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 130);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(123, 15);
            label7.TabIndex = 3;
            label7.Text = "Confirmar Contraseña";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 86);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(106, 15);
            label6.TabIndex = 2;
            label6.Text = "Nueva Contraseña";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 46);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(88, 15);
            label5.TabIndex = 1;
            label5.Text = "Nuevo Usuario";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(170, 10);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(76, 15);
            label4.TabIndex = 0;
            label4.Text = "Crear Cuenta";
            // 
            // FormInicioSesion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(489, 449);
            Controls.Add(pnlRegistro);
            Controls.Add(btnMostrarRegistro);
            Controls.Add(btnIniciarSesion);
            Controls.Add(txtContrasena);
            Controls.Add(txtUsuario);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "FormInicioSesion";
            Text = "FormInicioSesion";
            pnlRegistro.ResumeLayout(false);
            pnlRegistro.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtUsuario;
        private TextBox txtContrasena;
        private Button btnIniciarSesion;
        private Button btnMostrarRegistro;
        private Panel pnlRegistro;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Button btnCerrarPanel;
        private Button btnCrearCuenta;
        private TextBox txtConfirmarContrasena;
        private TextBox txtNuevaContrasena;
        private TextBox txtNuevoUsuario;
    }
}
