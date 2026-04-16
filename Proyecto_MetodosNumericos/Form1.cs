using Proyecto_MetodosNumericos.Data;
using Proyecto_MetodosNumericos.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Proyecto_MetodosNumericos
{
    public partial class FormInicioSesion : Form
    {
        public FormInicioSesion()
        {
            InitializeComponent();
        }

        private void btnMostrarRegistro_Click(object sender, EventArgs e)
        {
            pnlRegistro.Visible = true;
            pnlRegistro.BringToFront();
        }

        private void btnCerrarPanel_Click(object sender, EventArgs e)
        {
            LimpiarCamposRegistro();
            pnlRegistro.Visible = false;
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            string usuario = txtNuevoUsuario.Text.Trim();
            string contrasena = txtNuevaContrasena.Text;
            string confirmar = txtConfirmarContrasena.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, llena todos los campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (contrasena != confirmar)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var db = new AppMetodosContext())
                {
                    // Expresión LINQ para verificar si existe
                    bool existeUsuario = db.Usuarios.Any(u => u.NombreUsuario == usuario);

                    if (existeUsuario)
                    {
                        MessageBox.Show("Este nombre de usuario ya está en uso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Instanciar el objeto y guardarlo
                    var nuevoUsuario = new Usuario
                    {
                        NombreUsuario = usuario,
                        Contrasena = BCrypt.Net.BCrypt.HashPassword(contrasena)
                    };

                    db.Usuarios.Add(nuevoUsuario);
                    db.SaveChanges(); // EF hace el INSERT automáticamente aquí
                }

                MessageBox.Show("Cuenta creada con éxito. Ahora puedes iniciar sesión.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCamposRegistro();
                pnlRegistro.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Ingresa tu usuario y contraseña.", "¡¡Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new AppMetodosContext())
                {
                    // 1. Buscamos al usuario solo por su nombre
                    var usuarioDb = db.Usuarios.FirstOrDefault(u => u.NombreUsuario == usuario);

                    // 2. Si el usuario existe, verificamos la contraseña
                    if (usuarioDb != null && BCrypt.Net.BCrypt.Verify(contrasena, usuarioDb.Contrasena))
                    {
                        MessageBox.Show("¡Acceso concedido y seguro!", $"Bienvenido: {usuario}", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        FormPrincipal form = new FormPrincipal(usuarioDb.IdUsuario);
                        form.Show();
                        this.Hide();
                    }
                    else
                    {
                        // El mensaje de error debe ser ambiguo por seguridad
                        MessageBox.Show("Usuario o contraseña incorrectos.", "Error de acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCamposRegistro()
        {
            txtNuevoUsuario.Clear();
            txtNuevaContrasena.Clear();
            txtConfirmarContrasena.Clear();
        }
    }
}
