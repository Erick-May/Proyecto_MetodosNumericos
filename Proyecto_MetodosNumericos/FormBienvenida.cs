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

            // Para centrar
            panel2.Anchor = AnchorStyles.None;
            this.Resize += new EventHandler(FormBienvenida_Resize);
        }



        private void btnEntrar_Click(object sender, EventArgs e)
        {
            FormInicioSesion loginForm = new FormInicioSesion();
            this.Hide();
            loginForm.ShowDialog();
        }

        private void FormBienvenida_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        // TODO ESTO ES PARA CENTRAR, ANTONELLA
        private void FormBienvenida_Resize(object sender, EventArgs e)
        {
            CentrarPanelContenedor();
        }

        private void FormBienvenida_Load(object sender, EventArgs e)
        {
            CentrarPanelContenedor();
        }

        private void CentrarPanelContenedor()
        {
            // Suponiendo que panel2 está directamente sobre el Formulario:
            // Usamos ClientSize para tomar el área visible real de la ventana
            int x = (panel1.Width - panel2.Width) / 2;
            int y = (panel1.ClientSize.Height - panel2.Height) / 2;

            panel2.Location = new Point(x, y);

            /* * NOTA IMPORTANTE: 
             * Si metiste el 'panel2' adentro del 'panel1' (en lugar del formulario), 
             * cambia "this.ClientSize.Width" por "panel1.Width" y lo mismo para el Height.
             */
        }
    }
}
