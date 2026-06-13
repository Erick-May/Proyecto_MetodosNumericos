using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Proyecto_MetodosNumericos
{
    public partial class FormRegresion : Form
    {
        bool regresandoAlMenu = false;

        public FormRegresion()
        {
            InitializeComponent();
            cmbTipoRegresion.SelectedIndex = 0;

            // Desactivamos el auto-relleno por si lo tenías activado
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // Le damos un ancho específico en píxeles (cambiá el 50 por lo que te guste)
            // [0] es la columna X, [1] es la columna Y
            dgvDatos.Columns[0].Width = 100;
            dgvDatos.Columns[1].Width = 100;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Leer los datos del DataGridView
                List<double> listaX = new List<double>();
                List<double> listaY = new List<double>();

                foreach (DataGridViewRow row in dgvDatos.Rows)
                {
                    if (!row.IsNewRow && row.Cells[0].Value != null && row.Cells[1].Value != null)
                    {
                        // Escudo de cultura invariante para los decimales
                        string xStr = row.Cells[0].Value.ToString().Replace(",", ".");
                        string yStr = row.Cells[1].Value.ToString().Replace(",", ".");

                        listaX.Add(Convert.ToDouble(xStr, System.Globalization.CultureInfo.InvariantCulture));
                        listaY.Add(Convert.ToDouble(yStr, System.Globalization.CultureInfo.InvariantCulture));
                    }
                }

                if (listaX.Count < 2)
                {
                    MessageBox.Show("Debes ingresar al menos 2 pares de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int grado = (int)nudGrado.Value;
                if (listaX.Count <= grado)
                {
                    MessageBox.Show($"Para un polinomio de grado {grado}, necesitas al menos {grado + 1} puntos de datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Ejecutar Motor Matemático
                double[] coeficientes;
                double r2;
                EjecutarRegresionPolinomial(listaX.ToArray(), listaY.ToArray(), grado, out coeficientes, out r2);

                // NUEVO: Escupir la tabla de desglose matemático para el usuario
                GenerarTablaExcel(listaX.ToArray(), listaY.ToArray(), grado, coeficientes);

                // 3. Formatear y mostrar Ecuación
                string ecuacion = $"y = {Math.Round(coeficientes[0], 4)} ";
                for (int i = 1; i <= grado; i++)
                {
                    double c = coeficientes[i];
                    string signo = c >= 0 ? "+" : "-";
                    ecuacion += $"{signo} {Math.Abs(Math.Round(c, 4))}x^{i} ";
                }

                lblEcuacion.Text = "Ecuación: \n" + ecuacion;
                lblR2.Text = $"R² = {Math.Round(r2, 4)} ({(r2 * 100).ToString("0.00")}%)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en los cálculos. Revisa que no haya letras o celdas vacías.\n\nDetalle: " + ex.Message, "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarTablaExcel(double[] x, double[] y, int grado, double[] coeficientes)
        {
            dgvResultados.Columns.Clear();
            dgvResultados.Rows.Clear();

            int n = x.Length;
            double yPromedio = y.Average();

            // 1. Crear las columnas dinámicas iniciales
            dgvResultados.Columns.Add("X", "X");
            dgvResultados.Columns.Add("Y", "Y");

            // Columnas de potencias puras (desde X^2 hasta X^(2m))
            for (int i = 2; i <= grado * 2; i++)
            {
                dgvResultados.Columns.Add($"X{i}", $"X^{i}");
            }

            // Columnas combinadas (X*Y hasta X^m*Y)
            dgvResultados.Columns.Add("XY", "X*Y");
            for (int i = 2; i <= grado; i++)
            {
                dgvResultados.Columns.Add($"X{i}Y", $"X^{i}*Y");
            }

            // Columnas de análisis de error (SET y SER)
            dgvResultados.Columns.Add("Y_Modelo", "Y_modelo");
            dgvResultados.Columns.Add("SET", "(y - y_promedio)²");
            dgvResultados.Columns.Add("SER", "(y - y_modelo)²");

            // 2. Llenar las filas iterando cada punto de datos
            for (int k = 0; k < n; k++)
            {
                List<object> fila = new List<object>();
                fila.Add(Math.Round(x[k], 4));
                fila.Add(Math.Round(y[k], 4));

                // Calcular e insertar X^i
                for (int i = 2; i <= grado * 2; i++)
                {
                    fila.Add(Math.Round(Math.Pow(x[k], i), 4));
                }

                // Calcular e insertar X^i * Y
                fila.Add(Math.Round(x[k] * y[k], 4)); // La de X*Y simple
                for (int i = 2; i <= grado; i++)
                {
                    fila.Add(Math.Round(Math.Pow(x[k], i) * y[k], 4));
                }

                // Calcular Y_modelo evaluando el polinomio en X
                double yModelo = 0;
                for (int i = 0; i <= grado; i++)
                {
                    yModelo += coeficientes[i] * Math.Pow(x[k], i);
                }
                fila.Add(Math.Round(yModelo, 4));

                // Calcular SET y SER
                double set = Math.Pow(y[k] - yPromedio, 2);
                double ser = Math.Pow(y[k] - yModelo, 2);

                // Redondeamos a 6 decimales para precisión visual
                fila.Add(Math.Round(set, 6));
                fila.Add(Math.Round(ser, 6));

                // Insertar la fila completa al DataGridView
                dgvResultados.Rows.Add(fila.ToArray());
            }
        }

        // =========================================================
        // MOTOR MATEMÁTICO: REGRESIÓN POLINOMIAL
        // =========================================================
        private void EjecutarRegresionPolinomial(double[] x, double[] y, int grado, out double[] coeficientes, out double r2)
        {
            int n = x.Length;
            int m = grado;

            // 1. CONSTRUCCIÓN DE MATRIZ DE ECUACIONES NORMALES (Tamaño m+1 x m+1)
            double[,] A = new double[m + 1, m + 1];
            double[] B = new double[m + 1];

            for (int i = 0; i <= m; i++)
            {
                // Llenar Matriz A (Sumatorias de X)
                for (int j = 0; j <= m; j++)
                {
                    double sumA = 0;
                    for (int k = 0; k < n; k++)
                    {
                        sumA += Math.Pow(x[k], i + j);
                    }
                    A[i, j] = sumA;
                }

                // Llenar Vector B (Sumatorias de X^i * Y)
                double sumB = 0;
                for (int k = 0; k < n; k++)
                {
                    sumB += Math.Pow(x[k], i) * y[k];
                }
                B[i] = sumB;
            }

            // A[0,0] por definición matemática debe ser igual a N
            A[0, 0] = n;

            // 2. RESOLUCIÓN DEL SISTEMA MEDIANTE GAUSS-JORDAN (Desde cero)
            coeficientes = ResolverGaussJordan(A, B);

            // 3. CÁLCULO DEL COEFICIENTE DE DETERMINACIÓN (R^2)
            double yPromedio = y.Average();
            double St = 0; // Error Total
            double Sr = 0; // Error Residual

            for (int k = 0; k < n; k++)
            {
                // Calcular St = Σ(y_real - y_promedio)^2
                St += Math.Pow(y[k] - yPromedio, 2);

                // Calcular Y del modelo (valores teóricos)
                double yModelo = 0;
                for (int i = 0; i <= m; i++)
                {
                    yModelo += coeficientes[i] * Math.Pow(x[k], i);
                }

                // Calcular Sr = Σ(y_real - y_modelo)^2
                Sr += Math.Pow(y[k] - yModelo, 2);
            }

            // R^2 final
            r2 = (St - Sr) / St;
        }

        // =========================================================
        // ALGORITMO GAUSS-JORDAN CON PIVOTEO PARCIAL OBLIGATORIO
        // =========================================================
        private double[] ResolverGaussJordan(double[,] A, double[] B)
        {
            int n = B.Length;
            double[,] mat = new double[n, n + 1];

            // Construir matriz aumentada
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++) mat[i, j] = A[i, j];
                mat[i, n] = B[i];
            }

            // Proceso de Eliminación
            for (int i = 0; i < n; i++)
            {
                // 1. Pivoteo Parcial (Buscar el número más grande en la columna para evitar división por cero o errores de redondeo)
                double max = Math.Abs(mat[i, i]);
                int maxRow = i;
                for (int k = i + 1; k < n; k++)
                {
                    if (Math.Abs(mat[k, i]) > max)
                    {
                        max = Math.Abs(mat[k, i]);
                        maxRow = k;
                    }
                }

                // Si el pivote es extremadamente cercano a cero, el sistema no tiene solución única (matriz singular)
                if (max < 1e-12)
                {
                    throw new Exception("El sistema de ecuaciones es singular o está mal condicionado (no se puede generar el polinomio con estos datos).");
                }

                // Intercambiar filas si el máximo no está en la fila actual
                if (maxRow != i)
                {
                    for (int k = i; k <= n; k++)
                    {
                        double temp = mat[i, k];
                        mat[i, k] = mat[maxRow, k];
                        mat[maxRow, k] = temp;
                    }
                }

                // 2. Normalizar la fila pivote (Hacer que el pivote sea 1)
                double pivote = mat[i, i];
                for (int k = i; k <= n; k++)
                {
                    mat[i, k] /= pivote;
                }

                // 3. Eliminación hacia adelante y hacia atrás (Hacer ceros el resto de la columna)
                for (int j = 0; j < n; j++)
                {
                    if (i != j) // No tocamos la fila del pivote
                    {
                        double factor = mat[j, i];
                        for (int k = i; k <= n; k++)
                        {
                            mat[j, k] -= factor * mat[i, k];
                        }
                    }
                }
            }

            // Extraer resultados (b0, b1, ..., bm)
            double[] solucion = new double[n];
            for (int i = 0; i < n; i++)
            {
                solucion[i] = mat[i, n];
            }

            return solucion;
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

        private void FormRegresion_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (regresandoAlMenu == false)
            {
                Environment.Exit(0);
            }
        }

        private void nudGrado_ValueChanged(object sender, EventArgs e)
        {
            // Revisamos el valor actual del NumericUpDown
            if (nudGrado.Value == 1)
            {
                lblTipoRegresion.Text = "Modelo: Simple";
            }
            else if (nudGrado.Value >= 2)
            {
                lblTipoRegresion.Text = "Modelo: Polinomial";
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
