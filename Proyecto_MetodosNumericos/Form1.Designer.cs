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
            label1.Location = new Point(260, 32);
            label1.Name = "label1";
            label1.Size = new Size(158, 25);
            label1.TabIndex = 0;
            label1.Text = "INICIO DE SESION";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(54, 108);
            label2.Name = "label2";
            label2.Size = new Size(72, 25);
            label2.TabIndex = 1;
            label2.Text = "Usuario";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(52, 180);
            label3.Name = "label3";
            label3.Size = new Size(101, 25);
            label3.TabIndex = 2;
            label3.Text = "Contraseña";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(192, 113);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(312, 31);
            txtUsuario.TabIndex = 3;
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(194, 186);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PasswordChar = '*';
            txtContrasena.Size = new Size(310, 31);
            txtContrasena.TabIndex = 4;
            txtContrasena.UseSystemPasswordChar = true;
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.Location = new Point(66, 270);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(172, 34);
            btnIniciarSesion.TabIndex = 5;
            btnIniciarSesion.Text = "Iniciar Sesion ";
            btnIniciarSesion.UseVisualStyleBackColor = true;
            btnIniciarSesion.Click += btnIniciarSesion_Click;
            // 
            // btnMostrarRegistro
            // 
            btnMostrarRegistro.Location = new Point(364, 270);
            btnMostrarRegistro.Name = "btnMostrarRegistro";
            btnMostrarRegistro.Size = new Size(172, 34);
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
            pnlRegistro.Location = new Point(52, 329);
            pnlRegistro.Name = "pnlRegistro";
            pnlRegistro.Size = new Size(589, 472);
            pnlRegistro.TabIndex = 7;
            pnlRegistro.Visible = false;
            // 
            // btnCerrarPanel
            // 
            btnCerrarPanel.Location = new Point(317, 312);
            btnCerrarPanel.Name = "btnCerrarPanel";
            btnCerrarPanel.Size = new Size(167, 34);
            btnCerrarPanel.TabIndex = 8;
            btnCerrarPanel.Text = "Cancelar";
            btnCerrarPanel.UseVisualStyleBackColor = true;
            btnCerrarPanel.Click += btnCerrarPanel_Click;
            // 
            // btnCrearCuenta
            // 
            btnCrearCuenta.Location = new Point(59, 312);
            btnCrearCuenta.Name = "btnCrearCuenta";
            btnCrearCuenta.Size = new Size(167, 34);
            btnCrearCuenta.TabIndex = 7;
            btnCrearCuenta.Text = "Crear Cuenta";
            btnCrearCuenta.UseVisualStyleBackColor = true;
            btnCrearCuenta.Click += btnCrearCuenta_Click;
            // 
            // txtConfirmarContrasena
            // 
            txtConfirmarContrasena.Location = new Point(224, 212);
            txtConfirmarContrasena.Name = "txtConfirmarContrasena";
            txtConfirmarContrasena.PasswordChar = '*';
            txtConfirmarContrasena.Size = new Size(297, 31);
            txtConfirmarContrasena.TabIndex = 6;
            txtConfirmarContrasena.UseSystemPasswordChar = true;
            // 
            // txtNuevaContrasena
            // 
            txtNuevaContrasena.Location = new Point(224, 138);
            txtNuevaContrasena.Name = "txtNuevaContrasena";
            txtNuevaContrasena.PasswordChar = '*';
            txtNuevaContrasena.Size = new Size(300, 31);
            txtNuevaContrasena.TabIndex = 5;
            txtNuevaContrasena.UseSystemPasswordChar = true;
            // 
            // txtNuevoUsuario
            // 
            txtNuevoUsuario.Location = new Point(224, 64);
            txtNuevoUsuario.Name = "txtNuevoUsuario";
            txtNuevoUsuario.Size = new Size(297, 31);
            txtNuevoUsuario.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 212);
            label7.Name = "label7";
            label7.Size = new Size(185, 25);
            label7.TabIndex = 3;
            label7.Text = "Confirmar Contraseña";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 138);
            label6.Name = "label6";
            label6.Size = new Size(156, 25);
            label6.TabIndex = 2;
            label6.Text = "Nueva Contraseña";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 61);
            label5.Name = "label5";
            label5.Size = new Size(129, 25);
            label5.TabIndex = 1;
            label5.Text = "Nuevo Usuario";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(224, 17);
            label4.Name = "label4";
            label4.Size = new Size(113, 25);
            label4.TabIndex = 0;
            label4.Text = "Crear Cuenta";
            // 
            // FormInicioSesion
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(728, 813);
            Controls.Add(pnlRegistro);
            Controls.Add(btnMostrarRegistro);
            Controls.Add(btnIniciarSesion);
            Controls.Add(txtContrasena);
            Controls.Add(txtUsuario);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
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
