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
    public partial class FormIntegracion : Form
    {
        bool regresandoAlMenu = false;
        public FormIntegracion()
        {
            InitializeComponent();
            cmbMetodosIntegracion.SelectedIndex = 0;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            string metodo = cmbMetodosIntegracion.SelectedItem?.ToString() ?? "";
            string funcion = txtFuncion.Text.Trim();

            if (string.IsNullOrEmpty(funcion))
            {
                MessageBox.Show("No has escrito ninguna función.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtA.Text, out double a) ||
                !double.TryParse(txtB.Text, out double b))
            {
                MessageBox.Show("Asegúrate de ingresar números válidos en A, yB.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int n = (int)nudN.Value;

            try
            {
                // ============================================
                // INTEGRALES DOBLES
                // ============================================
                if (chkIntegralDoble.Checked)
                {
                    if (!double.TryParse(txtC.Text, out double c) || !double.TryParse(txtD.Text, out double d))
                    {
                        MessageBox.Show("Asegúrate de ingresar números válidos en C y D.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    int ny = (int)nudNy.Value;

                    if (metodo == "Simpson 1/3")
                    {
                        System.Data.DataTable tabla;
                        double res = IntegracionNumerica.CalcularSimpson13Doble(funcion, a, b, n, c, d, ny, out tabla);

                        dgvResultados.Columns.Clear();
                        dgvResultados.DataSource = tabla;
                        lblResultado.Text = $"Resultado Aproximado Para la Integral Doble con 1/3:\nI ≈ {Math.Round(res, 9)}";
                    }
                    else if (metodo == "Simpson 3/8")
                    {
                        System.Data.DataTable tabla;
                        double res = IntegracionNumerica.CalcularSimpson38Doble(funcion, a, b, n, c, d, ny, out tabla);

                        dgvResultados.Columns.Clear();
                        dgvResultados.DataSource = tabla;
                        lblResultado.Text = $"Resultado Aproximado Para la Integral Doble con 3/8:\nI ≈ {Math.Round(res, 8)}";
                    }
                    else if (metodo == "Integracion de Romberg")
                    {
                        // Aquí 'n' es la cantidad de niveles que queremos generar (ej: 3 o 4)
                        double[,] matrizRomberg = IntegracionNumerica.CalcularRombergDoble(funcion, a, b, c, d, n);

                        // Limpiamos y armamos las columnas para pintar el triángulo
                        dgvResultados.Columns.Clear();
                        dgvResultados.Rows.Clear();
                        dgvResultados.Columns.Add("J", "j");

                        for (int k = 1; k <= n; k++)
                        {
                            dgvResultados.Columns.Add($"K{k}", $"k={k}");
                        }
                        dgvResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        // Imprimimos la matriz con la forma triangular inferior derecha 0
                        for (int j = 1; j <= n; j++)
                        {
                            List<object> filaDgv = new List<object> { j };

                            for (int k = 1; k <= n; k++)
                            {
                                if (k <= n - j + 1)
                                {
                                    filaDgv.Add(Math.Round(matrizRomberg[j, k], 8));
                                }
                                else
                                {
                                    filaDgv.Add(""); // Celda vacía para el Triangulo 0
                                }
                            }
                            dgvResultados.Rows.Add(filaDgv.ToArray());
                        }

                        lblResultado.Text = $"Resultado Aproximado Para la Integral Doble con Romberg:\nI ≈ {Math.Round(matrizRomberg[1, n], 8)}";
                    }
                }
                // ============================================
                // INTEGRALES SIMPLES 
                // ============================================
                else
                {
                    if (metodo == "Simpson 1/3")
                    {
                        EjecutarSimpson13(funcion, a, b, n);
                    }
                    else if (metodo == "Simpson 3/8")
                    {
                        EjecutarSimpson38(funcion, a, b, n);
                    }
                    else if (metodo == "Integracion de Romberg")
                    {
                        // n es la cantidad de niveles o filas de la matriz
                        EjecutarRomberg(funcion, a, b, n);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Matemático", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // SIMPSON 1/3
        private void EjecutarSimpson13(string funcion, double a, double b, int n)
        {
            // Regla de oro: n debe ser par para Simpson 1/3
            if (n % 2 != 0)
            {
                MessageBox.Show("Para usar Simpson 1/3, el número de intervalos 'n' DEBE ser un número par (ej: 2, 4, 6...).", "Requisito Matemático", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double h = (b - a) / n;
            double[] x = new double[n + 1];
            double[] fx = new double[n + 1];

            // Configuramos la tabla
            dgvResultados.Columns.Clear();
            dgvResultados.Rows.Clear();
            dgvResultados.Columns.Add("i", "i");
            dgvResultados.Columns.Add("xi", "xi");
            dgvResultados.Columns.Add("fxi", "f(xi)");
            dgvResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 1. Evaluamos todos los puntos y llenamos la tabla
            for (int i = 0; i <= n; i++)
            {
                x[i] = a + (i * h);
                fx[i] = EvaluadorFunciones.Evaluar(funcion, x[i]);

                dgvResultados.Rows.Add(i, Math.Round(x[i], 8), Math.Round(fx[i], 8));
            }

            // 2. Aplicamos la fórmula (El código detecta solo si es simple o compuesta)
            double integral = fx[0] + fx[n]; // Extremos

            for (int i = 1; i < n; i++)
            {
                if (i % 2 == 0) // Si es posición par, multiplicamos por 2
                {
                    integral += 2 * fx[i];
                }
                else // Si es posición impar, multiplicamos por 4
                {
                    integral += 4 * fx[i];
                }
            }

            integral = integral * (h / 3.0);

            lblResultado.Text = $"Resultado Aproximado: \nI ≈ {Math.Round(integral, 8)}";
        }

        // SIMPSN 3/8
        private void EjecutarSimpson38(string funcion, double a, double b, int n)
        {
            // Regla de oro: n debe ser múltiplo de 3 para Simpson 3/8
            if (n % 3 != 0)
            {
                MessageBox.Show("Para usar Simpson 3/8, el número de intervalos 'n' DEBE ser un múltiplo de 3 (ej: 3, 6, 9...).", "Requisito Matemático", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double h = (b - a) / n;
            double[] x = new double[n + 1];
            double[] fx = new double[n + 1];

            // Configuramos la tabla
            dgvResultados.Columns.Clear();
            dgvResultados.Rows.Clear();
            dgvResultados.Columns.Add("i", "i");
            dgvResultados.Columns.Add("xi", "xi");
            dgvResultados.Columns.Add("fxi", "f(xi)");
            dgvResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 1. Evaluamos todos los puntos y llenamos la tabla
            for (int i = 0; i <= n; i++)
            {
                x[i] = a + (i * h);
                fx[i] = EvaluadorFunciones.Evaluar(funcion, x[i]);

                dgvResultados.Rows.Add(i, Math.Round(x[i], 8), Math.Round(fx[i], 8));
            }

            // 2. Aplicamos la fórmula (El código detecta simple/compuesta automáticamente)
            double integral = fx[0] + fx[n]; // Extremos se multiplican por 1

            for (int i = 1; i < n; i++)
            {
                if (i % 3 == 0) // Si la posición es múltiplo de 3 (ej: i=3, i=6), multiplicamos por 2
                {
                    integral += 2 * fx[i];
                }
                else // El resto de posiciones intermedias se multiplican por 3
                {
                    integral += 3 * fx[i];
                }
            }

            // La fórmula es (3 * h / 8) por todo lo sumado
            integral = integral * (3.0 * h / 8.0);

            lblResultado.Text = $"Resultado Aproximado: \nI ≈ {Math.Round(integral, 8)}";
        }

        // INTEGRACION DE ROMBERG
        private void EjecutarRomberg(string funcion, double a, double b, int niveles)
        {
            if (niveles < 1)
            {
                MessageBox.Show("Para Romberg, el nivel (N) debe ser mínimo 1.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double[,] matrizRomberg;

            try
            {
                // ¡Aquí llamamos a tu nueva clase maestra!
                matrizRomberg = IntegracionNumerica.CalcularRomberg(funcion, a, b, niveles);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Matemático", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Transformamos el DataGridView en la Matriz de Romberg
            dgvResultados.Columns.Clear();
            dgvResultados.Rows.Clear();
            dgvResultados.Columns.Add("J", "j");

            for (int k = 1; k <= niveles; k++)
            {
                dgvResultados.Columns.Add($"K{k}", $"k={k}");
            }
            dgvResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Imprimir la Matriz Triangular en Pantalla
            for (int j = 1; j <= niveles; j++)
            {
                List<object> filaDgv = new List<object>();
                filaDgv.Add(j);

                for (int k = 1; k <= niveles; k++)
                {
                    if (k <= niveles - j + 1)
                    {
                        filaDgv.Add(Math.Round(matrizRomberg[j, k], 8));
                    }
                    else
                    {
                        filaDgv.Add(""); // Celda vacía para el efecto triangular
                    }
                }
                dgvResultados.Rows.Add(filaDgv.ToArray());
            }

            lblResultado.Text = $"Resultado Aproximado (Romberg): \nI ≈ {Math.Round(matrizRomberg[1, niveles], 8)}";
        }

        private void ActualizarEtiquetas(string metodo)
        {
            if (lblTipoIntegracion == null) return;

            lblTipoIntegracion.Text = "Tema: ";

            if (metodo == "Simpson 1/3")
            {
                lblTipoIntegracion.Text = "Tema: Regla de Simpson 1/3";
            }
            else if (metodo == "Simpson 3/8")
            {
                lblTipoIntegracion.Text = "Tema: Regla de Simpson 3/8";
            }
            else if (metodo == "Integracion de Romberg")
            {
                lblTipoIntegracion.Text = "Tema: Integracion y Matriz de Romberg";
            }
        }
        private void cmbMetodosIntegracion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string metodo = cmbMetodosIntegracion.SelectedItem?.ToString() ?? "";
            ActualizarEtiquetas(metodo);
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

        private void FormIntegracion_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (regresandoAlMenu == false)
            {
                Environment.Exit(0);
            }
        }

        private void chkIntegralDoble_CheckedChanged(object sender, EventArgs e)
        {
            bool esDoble = chkIntegralDoble.Checked;
            txtC.Visible = esDoble;
            txtD.Visible = esDoble;
            nudNy.Visible = esDoble;
            lblLimiteY.Visible = esDoble;
            label7.Visible = esDoble;
            label8.Visible = esDoble;
            label9.Visible = esDoble;
        }

    }
}
