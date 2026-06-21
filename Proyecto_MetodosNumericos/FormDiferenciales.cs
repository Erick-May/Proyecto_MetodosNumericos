using Proyecto_MetodosNumericos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Proyecto_MetodosNumericos
{
    public partial class FormDiferenciales : Form
    {
        private bool regresandoAlMenu = false;
        public FormDiferenciales()
        {
            InitializeComponent();
            cmbMetodosEDO.SelectedIndex = 0;

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            string funcion = txtFuncion.Text.Trim();
            string metodo = cmbMetodosEDO.SelectedItem?.ToString() ?? "";

            if (string.IsNullOrEmpty(funcion))
            {
                MessageBox.Show("No has ingresado la función f(x,y).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtX0.Text, out double x0) ||
                !double.TryParse(txtY0.Text, out double y0) ||
                !double.TryParse(txtXf.Text, out double xf))
            {
                MessageBox.Show("Por favor, introduce valores numéricos válidos en x0, y0 Y xf.", "Campos Inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // VALOR DE H

            string hTexto = txtH.Text.Trim();
            double h = 0;

            if (hTexto.Contains("/"))
            {
                // Si el maje escribe una fracción como "1/4"
                string[] partes = hTexto.Split('/');
                if (partes.Length == 2 && double.TryParse(partes[0], out double num) && double.TryParse(partes[1], out double den) && den != 0)
                {
                    h = num / den;
                }
                else
                {
                    MessageBox.Show("La fracción para 'h' no es válida.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (!double.TryParse(hTexto, out h) || h <= 0)
            {
                // Si escribe un decimal normal pero pone letras o negativos
                MessageBox.Show("Asegúrate de ingresar un número o fracción válida para 'h' (mayor a 0).", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Calculamos la N (pasos) automáticamente para nuestro motor
            // N = (Xf - X0) / h
            int pasos = (int)Math.Round((xf - x0) / h);

            if (pasos <= 0)
            {
                MessageBox.Show("El tamaño de paso 'h' es demasiado grande para el intervalo que pusiste.", "Error Lógico", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable dtResultados;

                if (metodo == "Metodo de Euler Simple")
                {
                    dtResultados = DiferencialesNumericas.CalcularEulerSimple(funcion, x0, y0, xf, pasos);
                }
                else
                {
                    dtResultados = DiferencialesNumericas.CalcularEulerModificado(funcion, x0, y0, xf, pasos);
                }

                // Cargamos la tabla en la interfaz
                dgvResultados.DataSource = dtResultados;
                dgvResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // El resultado final de la aproximación es el último "yi" registrado en la tabla
                double resultadoFinal = Convert.ToDouble(dtResultados.Rows[dtResultados.Rows.Count - 1]["yi"]);
                lblResultado.Text = $"Resultado Aproximado:\ny({xf}) ≈ {resultadoFinal}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la evaluación: " + ex.Message, "Error Matemático", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ActualizarEtiquetas(string metodo)
        {
            if (lblTipoDiferencial == null) return;

            lblTipoDiferencial.Text = "Tema: ";

            if (metodo == "Metodo de Euler Simple")
            {
                lblTipoDiferencial.Text = "Tema: Metodo de Euler Simple";
            }
            else if (metodo == "Metodo de Euler Modificado")
            {
                lblTipoDiferencial.Text = "Modelo: Metodo de Euler Modificado";
            }

        }

        private void cmbMetodosEDO_SelectedIndexChanged(object sender, EventArgs e)
        {
            string metodo = cmbMetodosEDO.SelectedItem?.ToString() ?? "";
            ActualizarEtiquetas(metodo);
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            regresandoAlMenu = true;
            Form frmPrincipal = Application.OpenForms["FormPrincipal"];
            if (frmPrincipal != null) frmPrincipal.Show();
            this.Close();
        }

        private void FormDiferenciales_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (regresandoAlMenu == false)
            {
                Environment.Exit(0);
            }
        }

    }
}
