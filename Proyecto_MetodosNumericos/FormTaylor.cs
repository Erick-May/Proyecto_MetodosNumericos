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
    public partial class FormTaylor : Form
    {
        bool regresandoAlMenu = false;
        public FormTaylor()
        {
            InitializeComponent();
            ConfigurarTabla();
            nudGrado.ValueChanged += nudGrado_ValueChanged;

            // Validaciones
            txtA.KeyPress += ValidarNumero_KeyPress;
            txtX.KeyPress += ValidarNumero_KeyPress;
            txtC.KeyPress += ValidarNumero_KeyPress;    
        }

        private void ConfigurarTabla()
        {
            dgvDerivadas.Columns.Clear();
            dgvDerivadas.Columns.Add("Orden", "n");
            dgvDerivadas.Columns.Add("Formula", "Fórmula f^(n)(x)");
            dgvDerivadas.Columns.Add("EvalA", "Evaluado en 'a'");
            dgvDerivadas.Columns.Add("Termino", "Término del Polinomio");

            // Solo la columna de la fórmula se puede editar
            dgvDerivadas.Columns[0].ReadOnly = true;
            dgvDerivadas.Columns[2].ReadOnly = true;
            dgvDerivadas.Columns[3].ReadOnly = true;
            dgvDerivadas.AllowUserToAddRows = false;

            ActualizarFilas();
        }

        private void ActualizarFilas()
        {
            int gradoN = (int)nudGrado.Value;
            int filasDeseadas = gradoN + 2; // Ocupamos N filas para Taylor, y 1 extra para Lagrange (n+1)

            dgvDerivadas.Rows.Clear();

            for (int i = 0; i < filasDeseadas; i++)
            {
                if (i <= gradoN)
                {
                    dgvDerivadas.Rows.Add(i, "", "-", "-");
                }
                else
                {
                    // La última fila es el Resto de Lagrange
                    dgvDerivadas.Rows.Add("n+1 (" + i + ")", "FÓRMULA LAGRANGE", "-", "-");
                    dgvDerivadas.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                }
            }
        }

        private void nudGrado_ValueChanged(object sender, EventArgs e)
        {
            ActualizarFilas();
        }

        private double Factorial(int numero)
        {
            if (numero <= 1) return 1;
            double res = 1;
            for (int i = 2; i <= numero; i++) res *= i;
            return res;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtX.Text, out double x) ||
                !double.TryParse(txtA.Text, out double a) ||
                !double.TryParse(txtC.Text, out double c))
            {
                MessageBox.Show("Asegurate de meter números válidos en X, A y C.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int gradoN = (int)nudGrado.Value;
            double sumatoriaTaylor = 0;
            double restoLagrange = 0;

            try
            {
                // 1. Armar el Polinomio de Taylor (Filas 0 hasta N)
                for (int k = 0; k <= gradoN; k++)
                {
                    string formula = dgvDerivadas.Rows[k].Cells[1].Value?.ToString() ?? "";
                    if (string.IsNullOrWhiteSpace(formula)) throw new Exception($"Falta la fórmula en la derivada de orden {k}.");

                    // Evaluamos la fórmula en el punto base 'a' (usando tu Evaluador crack)
                    double evalA = EvaluadorFunciones.Evaluar(formula, a);

                    // Aplicamos la matemática de Taylor: ( f^(k)(a) / k! ) * (x - a)^k
                    double termino = (evalA / Factorial(k)) * Math.Pow(x - a, k);
                    sumatoriaTaylor += termino;

                    // Actualizamos la tabla visualmente
                    dgvDerivadas.Rows[k].Cells[2].Value = Math.Round(evalA, 6);
                    dgvDerivadas.Rows[k].Cells[3].Value = Math.Round(termino, 6);
                }

                // 2. Calcular el Resto de Lagrange (Fila N+1)
                int nLagrange = gradoN + 1;
                string formulaLagrange = dgvDerivadas.Rows[nLagrange].Cells[1].Value?.ToString() ?? "";
                if (formulaLagrange != "FÓRMULA LAGRANGE" && !string.IsNullOrWhiteSpace(formulaLagrange))
                {
                    // Lagrange se evalúa en 'c', no en 'a'
                    double evalC = EvaluadorFunciones.Evaluar(formulaLagrange, c);
                    restoLagrange = (evalC / Factorial(nLagrange)) * Math.Pow(x - a, nLagrange);

                    dgvDerivadas.Rows[nLagrange].Cells[2].Value = Math.Round(evalC, 6);
                    dgvDerivadas.Rows[nLagrange].Cells[3].Value = Math.Round(restoLagrange, 8);
                }

                // 3. Mostrar Resultados Finales
                lblResultado.Text = $"Polinomio P{gradoN}({x}) ≈ {Math.Round(sumatoriaTaylor, 8)}\n" +
                                    $"Resto de Lagrange R{gradoN} ≈ {Math.Round(restoLagrange, 8)}\n" +
                                    $"Valor Proyectado Total ≈ {Math.Round(sumatoriaTaylor + restoLagrange, 8)}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al evaluar las fórmulas: " + ex.Message, "Error Matemático", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            regresandoAlMenu = true;
            Form frmPrincipal = Application.OpenForms["FormPrincipal"];
            if (frmPrincipal != null) frmPrincipal.Show();
            this.Close();
        }

        private void FormTaylor_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (regresandoAlMenu == false)
            {
                Environment.Exit(0);
            }
        }

        private void ValidarNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitimos números, borrar, el punto y el signo negativo
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            // Solo un punto decimal
            TextBox txt = sender as TextBox; // Lo guardamos en una variable para que se vea más limpio
            if ((e.KeyChar == '.') && (txt.Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            // El signo negativo solo puede ir al principio y solo una vez
            if (e.KeyChar == '-')
            {
                // Si ya hay un signo negativo, o si el cursor no está en la primera posición, lo bloqueamos
                if ((txt.Text.Contains("-")) || (txt.SelectionStart != 0))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
