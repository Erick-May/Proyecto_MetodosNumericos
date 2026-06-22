using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Proyecto_MetodosNumericos
{
    public partial class FormDerivadas : Form
    {
        bool regresandoAlMenu = false;
        public FormDerivadas()
        {
            InitializeComponent();
            ConfigurarTabla();
            nudPuntos.ValueChanged += nudPuntos_ValueChanged;
        }

        private void ConfigurarTabla()
        {
            dgvDatos.Columns.Clear();
            dgvDatos.Columns.Add("X", "Xi (Ej: Tiempo)");
            dgvDatos.Columns.Add("Y", "f(Xi) (Ej: Distancia)");
            dgvDatos.AllowUserToAddRows = false;
            ActualizarFilas();
        }

        private void ActualizarFilas()
        {
            int filasDeseadas = (int)nudPuntos.Value;
            while (dgvDatos.Rows.Count < filasDeseadas) dgvDatos.Rows.Add();
            while (dgvDatos.Rows.Count > filasDeseadas) dgvDatos.Rows.RemoveAt(dgvDatos.Rows.Count - 1);
        }

        private void nudPuntos_ValueChanged(object sender, EventArgs e)
        {
            ActualizarFilas();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            // 1. Validar que el usuario haya puesto el X a evaluar
            if (!double.TryParse(txtXEval.Text.Trim(), out double xEval))
            {
                MessageBox.Show("Ingresa un valor numérico válido para evaluar (X).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Extraer datos de la tabla
            List<double> listX = new List<double>();
            List<double> listY = new List<double>();

            try
            {
                for (int i = 0; i < dgvDatos.Rows.Count; i++)
                {
                    if (dgvDatos.Rows[i].Cells[0].Value != null && dgvDatos.Rows[i].Cells[1].Value != null)
                    {
                        listX.Add(Convert.ToDouble(dgvDatos.Rows[i].Cells[0].Value));
                        listY.Add(Convert.ToDouble(dgvDatos.Rows[i].Cells[1].Value));
                    }
                }
            }
            catch
            {
                MessageBox.Show("Asegúrate de que todos los datos en la tabla sean números válidos.", "Error en Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Buscar el valor X en la tabla (Tu idea maestra)
            int index = -1;
            for (int i = 0; i < listX.Count; i++)
            {
                // Usamos una pequeña tolerancia por si hay decimales traviesos
                if (Math.Abs(listX[i] - xEval) < 0.000001)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                MessageBox.Show($"El valor X = {xEval} no existe en la tabla. Agregalo o busca uno que sí esté.", "Dato no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Calcular Derivadas según los CheckBoxes marcados
            string textoResultados = $"Resultados de f'({xEval}):\n\n";
            int n = listX.Count;

            // --- HACIA ADELANTE ---
            if (chkAdelante.Checked)
            {
                if (index < n - 1)
                {
                    double h = listX[index + 1] - listX[index];
                    double derivada = (listY[index + 1] - listY[index]) / h;
                    textoResultados += $"▶ Adelante: {Math.Round(derivada, 8)}\n";
                }
                else
                {
                    textoResultados += $"▶ Adelante: \n " +
                        $"[Error] No hay datos futuros.\n";
                }
            }

            // --- HACIA ATRÁS ---
            if (chkAtras.Checked)
            {
                if (index > 0)
                {
                    double h = listX[index] - listX[index - 1];
                    double derivada = (listY[index] - listY[index - 1]) / h;
                    textoResultados += $"◀ Atrás: {Math.Round(derivada, 8)}\n";
                }
                else
                {
                    textoResultados += $"◀ Atrás: \n " +
                        $"[Error] No hay datos pasados.\n";
                }
            }

            // --- CENTRADA ---
            if (chkCentrada.Checked)
            {
                if (index > 0 && index < n - 1)
                {
                    double h = listX[index + 1] - listX[index]; // Asumimos pasos iguales
                    double derivada = (listY[index + 1] - listY[index - 1]) / (2 * h);
                    textoResultados += $"❂ Centrada: {Math.Round(derivada, 8)}\n";
                }
                else
                {
                    textoResultados += $"❂ Centrada: [Error] Requiere un punto antes y uno después.\n";
                }
            }

            if (!chkAdelante.Checked && !chkAtras.Checked && !chkCentrada.Checked)
            {
                textoResultados = "Marcá por lo menos una casilla \n " +
                    "de chequeo para calcular.";
            }

            lblResultado.Text = textoResultados;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            regresandoAlMenu = true;
            Form frmPrincipal = Application.OpenForms["FormPrincipal"];
            if (frmPrincipal != null) frmPrincipal.Show();
            this.Close();
        }

        private void FormDerivadas_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (regresandoAlMenu == false)
            {
                Environment.Exit(0);
            }
        }

        private void txtXEval_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitimos números, borrar, el punto y el signo negativo
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            // Solo un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            // El signo negativo solo puede ir al principio y solo una vez
            if (e.KeyChar == '-')
            {
                // Si ya hay un signo negativo, o si el cursor no está en la primera posición, lo bloqueamos
                if (((sender as TextBox).Text.Contains("-")) || ((sender as TextBox).SelectionStart != 0))
                {
                    e.Handled = true;
                }
            }

        }

        private void dgvDatos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Primero desvinculamos el evento por si ya estaba conectado (para que no se duplique)
            e.Control.KeyPress -= new KeyPressEventHandler(ValidarNumeros_KeyPress);

            // Si la celda que están editando es de tipo texto (TextBox)
            if (e.Control is TextBox tb)
            {
                // Le conectamos nuestra regla de validación
                tb.KeyPress += new KeyPressEventHandler(ValidarNumeros_KeyPress);
            }
        }

        private void ValidarNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 1. Permitimos números, borrar, el punto decimal y el signo negativo
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true; // Bloqueamos cualquier otra cosa (letras, símbolos raros)
            }

            // 2. Solo permitimos un punto decimal
            TextBox txt = sender as TextBox;
            if ((e.KeyChar == '.') && (txt.Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            // 3. El signo negativo solo puede ir al principio
            if (e.KeyChar == '-')
            {
                // Si ya hay un menos, o si no están escribiendo en la primera posición
                if (txt.Text.Contains("-") || txt.SelectionStart != 0)
                {
                    e.Handled = true;
                }
            }
        }

        private void dgvDatos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Si meten basura pegándola, simplemente cancelamos el error y les avisamos
            MessageBox.Show("Solo se permiten números válidos en esta tabla.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            e.Cancel = true;
        }
    }
}
