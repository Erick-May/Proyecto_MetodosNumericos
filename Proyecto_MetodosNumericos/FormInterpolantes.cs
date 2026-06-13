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
    public partial class FormInterpolantes : Form
    {
        bool regresandoAlMenu = false;
        public FormInterpolantes()
        {
            InitializeComponent();

            if (cmbMetodoInterpolacion.Items.Count == 0)
            {
                cmbMetodoInterpolacion.Items.Add("Newton Diferencias Divididas");
                cmbMetodoInterpolacion.Items.Add("Lagrange");
            }
            // Seleccionar Newton por defecto
            if (cmbMetodoInterpolacion.Items.Count > 0 && cmbMetodoInterpolacion.SelectedIndex == -1)
            {
                cmbMetodoInterpolacion.SelectedIndex = 0;
            }

            dgvInput.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dgvInput.Columns[0].Width = 100;
            dgvInput.Columns[1].Width = 100;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                // ==========================================================
                // 1. VALIDACIÓN Y LECTURA DE DATOS (COMÚN PARA AMBOS MÉTODOS)
                // ==========================================================
                List<double> listaX = new List<double>();
                List<double> listaY = new List<double>();

                foreach (DataGridViewRow row in dgvInput.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells[0].Value == null || row.Cells[1].Value == null ||
                            string.IsNullOrWhiteSpace(row.Cells[0].Value.ToString()) ||
                            string.IsNullOrWhiteSpace(row.Cells[1].Value.ToString()))
                        {
                            throw new Exception("No pueden haber campos vacíos en la tabla de entrada.");
                        }

                        // Blindaje de cultura para el punto decimal
                        string xStr = row.Cells[0].Value.ToString().Replace(",", ".");
                        string yStr = row.Cells[1].Value.ToString().Replace(",", ".");

                        listaX.Add(Convert.ToDouble(xStr, System.Globalization.CultureInfo.InvariantCulture));
                        listaY.Add(Convert.ToDouble(yStr, System.Globalization.CultureInfo.InvariantCulture));
                    }
                }

                if (listaX.Count < 2)
                {
                    throw new Exception("Se necesitan al menos 2 puntos para interpolar.");
                }

                if (string.IsNullOrWhiteSpace(txtValorX.Text))
                {
                    throw new Exception("Debes ingresar un valor de X para interpolar.");
                }

                double valorX = Convert.ToDouble(txtValorX.Text.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture);

                double[] X = listaX.ToArray();
                double[] Y = listaY.ToArray();
                int n = X.Length;

                string metodoSeleccionado = cmbMetodoInterpolacion.SelectedItem.ToString();

                // ==========================================================
                // RUTA 1: NEWTON POR DIFERENCIAS DIVIDIDAS (INTACTO)
                // ==========================================================
                if (metodoSeleccionado == "Newton Diferencias Divididas")
                {
                    NewtonDiferenciasDivididas newton = new NewtonDiferenciasDivididas();

                    double[,] matrizDiferencias = newton.CalcularTablaDiferencias(X, Y);

                    double[] coeficientes = new double[n];
                    for (int j = 0; j < n; j++)
                    {
                        coeficientes[j] = matrizDiferencias[0, j];
                    }

                    dgvTablaDiferencias.Columns.Clear();
                    dgvTablaDiferencias.Rows.Clear();

                    dgvTablaDiferencias.Columns.Add("ColX", "X");
                    dgvTablaDiferencias.Columns.Add("ColY", "f(X) [Orden 0]");
                    for (int j = 1; j < n; j++)
                    {
                        dgvTablaDiferencias.Columns.Add($"Orden{j}", $"Orden {j}");
                    }

                    for (int i = 0; i < n; i++)
                    {
                        List<object> fila = new List<object>();
                        fila.Add(Math.Round(X[i], 6));

                        for (int j = 0; j < n; j++)
                        {
                            if (i < n - j)
                            {
                                fila.Add(Math.Round(matrizDiferencias[i, j], 6));
                            }
                            else
                            {
                                fila.Add("");
                            }
                        }
                        dgvTablaDiferencias.Rows.Add(fila.ToArray());
                    }

                    double resultadoInterpolacion = newton.Evaluar(coeficientes, X, valorX);
                    string polinomioSimbolico = newton.ObtenerPolinomioExpandido(coeficientes, X);

                    // Imprime en el txtResultado original de Newton
                    lblResultado.Text = $"=== POLINOMIO DE NEWTON ===\n" +
                                        $"P(x) = {polinomioSimbolico}\n\n" +
                                        $"=== RESULTADO DE LA INTERPOLACIÓN ===\n" +
                                        $"Para X = {valorX}, \n" +
                                        $"la aproximación es f({valorX}) = {Math.Round(resultadoInterpolacion, 6)}";
                }
                // ==========================================================
                // RUTA 2: INTERPOLACIÓN DE LAGRANGE (NUEVO)
                // ==========================================================
                else if (metodoSeleccionado == "Lagrange")
                {
                    // Limpiamos la tabla de Newton por si había datos viejos
                    dgvTablaDiferencias.Columns.Clear();
                    dgvTablaDiferencias.Rows.Clear();

                    // Instanciamos la clase de Lagrange
                    LagrangeInterpolacion lagrange = new LagrangeInterpolacion();

                    // Obtenemos los datos calculados
                    List<string> polinomiosLi = lagrange.ObtenerPolinomiosLiExpandidos(X);
                    string polinomioFinal = lagrange.ObtenerPolinomioFinal(X, Y);
                    double resultadoInterpolacion = lagrange.Evaluar(X, Y, valorX);

                    // Formateamos y mostramos en el nuevo RichTextBox
                    rtbResultados.Clear();
                    rtbResultados.AppendText("=== POLINOMIOS BASE DE LAGRANGE (L_i) ===\n");

                    foreach (string li in polinomiosLi)
                    {
                        rtbResultados.AppendText(li + "\n\n");
                    }

                    rtbResultados.AppendText("\n=== POLINOMIO FINAL ===\n");
                    rtbResultados.AppendText($"P(x) = {polinomioFinal}\n");

                    rtbResultados.AppendText("\n=== RESULTADO DE LA INTERPOLACIÓN ===\n");
                    rtbResultados.AppendText($"Aproximación para x = {valorX}:\nf({valorX}) = {Math.Round(resultadoInterpolacion, 6)}\n");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Asegúrate de ingresar solo números válidos. Revisa que no haya letras o símbolos erróneos.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            regresandoAlMenu = true;
            Form frmPrincipal = Application.OpenForms["FormPrincipal"];
            if (frmPrincipal != null)
            {
                frmPrincipal.Show();
            }
            this.Close();
        }

        private void FormInterpolantes_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (regresandoAlMenu == false)
            {
                Environment.Exit(0);
            }
        }
        private void ActualizarEtiquetas(string metodo)
        {
            if (lblTipoInterpolacion == null) return;

            lblTipoInterpolacion.Text = "Modelo: ";

            if (metodo == "Newton Diferencias Divididas")
            {
                lblTipoInterpolacion.Text = "Modelo: Newton por Diferencias Divididas";
            }
        }

        private void cmbMetodoInterpolacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string metodo = cmbMetodoInterpolacion.SelectedItem?.ToString() ?? "";

            ActualizarEtiquetas(metodo);
        }

        private void txtValorX_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dgvInput_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
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

        private void dgvInput_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Si meten basura pegándola, simplemente cancelamos el error y les avisamos
            MessageBox.Show("Solo se permiten números válidos en esta tabla.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            e.Cancel = true;
        }
    }
}
