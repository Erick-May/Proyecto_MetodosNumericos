using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Proyecto_MetodosNumericos
{
    public partial class FormBienvenida : Form
    {
        public FormBienvenida()
        {
            InitializeComponent();
            btnEntrar.FlatAppearance.BorderSize = 0;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            FormInicioSesion loginForm = new FormInicioSesion();
            this.Hide();
            loginForm.ShowDialog();
        }
        
    }
}
