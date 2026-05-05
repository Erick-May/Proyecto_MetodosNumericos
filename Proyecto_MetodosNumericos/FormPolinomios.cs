using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Proyecto_MetodosNumericos
{
    public partial class FormPolinomios : Form
    {
        public FormPolinomios()
        {
            InitializeComponent();
        }

        private void btnCalcularBairstow_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Extraemos los coeficientes. Ej: "1, 3, -1, -3"
                string[] partes = txtCoeficientes.Text.Split(',');
                int grado = partes.Length - 1; // Si hay 4 números, el grado es 3

                if (grado < 2)
                {
                    MessageBox.Show("El polinomio debe ser de al menos grado 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Llenamos el arreglo 'a' (OJO: a[3] es x^3, a[0] es la constante)
                double[] a = new double[grado + 1];
                for (int i = 0; i <= grado; i++)
                {
                    a[grado - i] = Convert.ToDouble(partes[i].Trim()); // Invertimos el orden para que coincida con la matemática
                }

                double r = Convert.ToDouble(txtR.Text);
                double s = Convert.ToDouble(txtS.Text);
                double tolerancia = Convert.ToDouble(txtToleranciaP.Text);

                // 2. Configuramos la tabla dinámica (¡Se adapta sola al grado N!)
                dgvBairstow.Columns.Clear();
                dgvBairstow.Columns.Add("Iteracion", "Iter");

                for (int i = grado; i >= 0; i--) dgvBairstow.Columns.Add($"b{i}", $"b{i}");
                for (int i = grado; i >= 1; i--) dgvBairstow.Columns.Add($"c{i}", $"c{i}");

                dgvBairstow.Columns.Add("Dr", "Δr");
                dgvBairstow.Columns.Add("Ds", "Δs");
                dgvBairstow.Columns.Add("r_nuevo", "r");
                dgvBairstow.Columns.Add("s_nuevo", "s");
                dgvBairstow.Columns.Add("Er_r", "Error_r%");
                dgvBairstow.Columns.Add("Er_s", "Error_s%");
                dgvBairstow.Columns.Add("X1", "X1");
                dgvBairstow.Columns.Add("X2", "X2");

                int iteracion = 0;
                double[] b = new double[grado + 1];
                double[] c = new double[grado + 1];

                // 3. BUCLE PRINCIPAL DE BAIRSTOW
                while (true)
                {
                    // División Sintética 1 (Calculamos 'b')
                    b[grado] = a[grado];
                    b[grado - 1] = a[grado - 1] + r * b[grado];
                    for (int i = grado - 2; i >= 0; i--)
                    {
                        b[i] = a[i] + r * b[i + 1] + s * b[i + 2];
                    }

                    // División Sintética 2 (Calculamos 'c')
                    c[grado] = b[grado];
                    c[grado - 1] = b[grado - 1] + r * c[grado];
                    for (int i = grado - 2; i >= 1; i--)
                    {
                        c[i] = b[i] + r * c[i + 1] + s * c[i + 2];
                    }

                    // Calculamos el Determinante del sistema
                    double D = (c[2] * c[2]) - (c[1] * c[3]);

                    // Calculamos los deltas usando Regla de Cramer
                    double delta_r = (b[0] * c[3] - b[1] * c[2]) / D;
                    double delta_s = (b[1] * c[1] - b[0] * c[2]) / D;

                    // Actualizamos r y s
                    double r_viejo = r;
                    double s_viejo = s;
                    r = r + delta_r;
                    s = s + delta_s;

                    // Calculamos Errores Relativos
                    double error_r = (r != 0) ? Math.Abs(delta_r / r) * 100.0 : 0;
                    double error_s = (s != 0) ? Math.Abs(delta_s / s) * 100.0 : 0;

                    // Calculamos las Raíces del factor cuadrático actual: x^2 - rx - s = 0
                    double discriminante = (r * r) + (4 * s);
                    string x1 = "", x2 = "";

                    if (discriminante >= 0)
                    {
                        // Raíces Reales
                        x1 = Math.Round((r + Math.Sqrt(discriminante)) / 2.0, 8).ToString();
                        x2 = Math.Round((r - Math.Sqrt(discriminante)) / 2.0, 8).ToString();
                    }
                    else
                    {
                        // Raíces Complejas (Imaginarias)
                        double parteReal = Math.Round(r / 2.0, 8);
                        double parteImag = Math.Round(Math.Sqrt(-discriminante) / 2.0, 8);
                        x1 = $"{parteReal} + {parteImag}i";
                        x2 = $"{parteReal} - {parteImag}i";
                    }

                    // --- CREAMOS LA FILA DINÁMICA PARA EL DATAGRIDVIEW ---
                    List<object> fila = new List<object> { iteracion };
                    for (int i = grado; i >= 0; i--) fila.Add(Math.Round(b[i], 8));
                    for (int i = grado; i >= 1; i--) fila.Add(Math.Round(c[i], 8));
                    fila.Add(Math.Round(delta_r, 8));
                    fila.Add(Math.Round(delta_s, 8));
                    fila.Add(Math.Round(r, 8));
                    fila.Add(Math.Round(s, 8));
                    fila.Add(iteracion == 0 ? "-" : Math.Round(error_r, 8).ToString());
                    fila.Add(iteracion == 0 ? "-" : Math.Round(error_s, 8).ToString());
                    fila.Add(x1);
                    fila.Add(x2);

                    dgvBairstow.Rows.Add(fila.ToArray());

                    // Freno: Si ambos errores caen por debajo de la tolerancia
                    if (iteracion > 0 && error_r < tolerancia && error_s < tolerancia) break;

                    iteracion++;
                    if (iteracion > 100)
                    {
                        MessageBox.Show("El método divagó y se detuvo por seguridad en la iteración 100.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Asegúrate de ingresar bien los coeficientes (ej: 1, 3, -1, -3). Error: " + ex.Message, "Error Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
