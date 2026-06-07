using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Proyecto_MetodosNumericos
{
    public partial class FormIterativos : Form
    {
        bool regresandoAlMenu = false;
        public FormIterativos()
        {
            InitializeComponent();

            // Configuración inicial
            cmbMetodos.SelectedIndex = 0; // Selecciona Gauss-Seidel por defecto
            nudVariables.Value = 3; // Empezamos con un sistema 3x3 por defecto
            ConfigurarEntradaMatriz();

            // Eventos
            nudVariables.ValueChanged += NudVariables_ValueChanged;
            btnCalcular.Click += BtnCalcular_Click;
        }
        private void NudVariables_ValueChanged(object sender, EventArgs e)
        {
            ConfigurarEntradaMatriz();
        }

        // Arma la cuadrícula para que el usuario escriba la matriz A y el vector B
        private void ConfigurarEntradaMatriz()
        {
            int n = (int)nudVariables.Value;
            dgvSistema.Columns.Clear();
            dgvSistema.Rows.Clear();
            dgvSistema.AllowUserToAddRows = false;

            // Columnas para Matriz A
            for (int i = 0; i < n; i++)
            {
                dgvSistema.Columns.Add($"X{i + 1}", $"X{i + 1}");
                dgvSistema.Columns[i].Width = 50;
            }

            // Columna para Vector B
            dgvSistema.Columns.Add("B", "B");
            dgvSistema.Columns[n].Width = 60;
            dgvSistema.Columns[n].DefaultCellStyle.BackColor = Color.LightYellow; // Distinguir vector b

            // Filas
            for (int i = 0; i < n; i++)
            {
                dgvSistema.Rows.Add();
            }
        }

        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            int n = (int)nudVariables.Value;
            string metodoSeleccionado = cmbMetodos.SelectedItem.ToString();

            double[,] A = new double[n, n];
            double[] B = new double[n];
            double[] X = new double[n]; // Vector de incógnitas actual
            double tolerancia = 0;

            try
            {
                // 1. LEER TOLERANCIA DE FORMA SEGURA (A prueba de fallos regionales)
                string tolTexto = txtTolerancia.Text.Replace(",", ".");
                if (!double.TryParse(tolTexto, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out tolerancia))
                {
                    MessageBox.Show("Ingresa una tolerancia válida.");
                    return;
                }

                // 2. LEER MATRIZ A Y VECTOR B (Blindado con InvariantCulture)
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        string valStr = dgvSistema.Rows[i].Cells[j].Value?.ToString().Replace(",", ".");
                        A[i, j] = Convert.ToDouble(valStr, System.Globalization.CultureInfo.InvariantCulture);
                    }
                    string bStr = dgvSistema.Rows[i].Cells[n].Value?.ToString().Replace(",", ".");
                    B[i] = Convert.ToDouble(bStr, System.Globalization.CultureInfo.InvariantCulture);

                    // 🛡️ ESCUDO: Verificar ceros en la diagonal
                    if (Math.Abs(A[i, i]) < 1E-12)
                    {
                        MessageBox.Show($"¡Error Matemático!\nEl elemento en la diagonal principal (Fila {i + 1}, Columna {i + 1}) es cero.\nPor favor, reordena las filas del sistema de ecuaciones para evitar divisiones entre cero.", "Diagonal Nula", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // 3. LEER VALORES INICIALES
                string[] valoresTexto = txtValoresIniciales.Lines.Where(l => !string.IsNullOrWhiteSpace(l)).ToArray();
                if (valoresTexto.Length != n)
                {
                    MessageBox.Show($"Debes ingresar exactamente {n} valores iniciales (uno por línea).");
                    return;
                }
                for (int i = 0; i < n; i++)
                {
                    string valInitStr = valoresTexto[i].Replace(",", ".");
                    X[i] = Convert.ToDouble(valInitStr, System.Globalization.CultureInfo.InvariantCulture);
                }

                // 4. PREPARAR TABLA DE RESULTADOS
                ConfigurarTablaResultados(n);

                // 5. EJECUTAR EL MÉTODO
                if (metodoSeleccionado == "Gauss-Seidel")
                {
                    EjecutarGaussSeidel(A, B, X, n, tolerancia);
                }
                else if (metodoSeleccionado == "Jacobi")
                {
                    EjecutarJacobi(A, B, X, n, tolerancia);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer los datos. Verifica que la matriz y los valores no tengan letras o celdas vacías.\n\nDetalle: " + ex.Message, "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool EsDiagonalmenteDominante(double[,] A, int n)
        {
            for (int i = 0; i < n; i++)
            {
                double sumaFila = 0;
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        sumaFila += Math.Abs(A[i, j]);
                    }
                }
                // Si el valor absoluto de la diagonal principal es menor que la suma del resto de la fila
                if (Math.Abs(A[i, i]) < sumaFila)
                {
                    return false;
                }
            }
            return true;
        }

        private void ConfigurarTablaResultados(int n)
        {
            dgvResultados.Columns.Clear();
            dgvResultados.Rows.Clear();
            dgvResultados.AllowUserToAddRows = false;
            dgvResultados.RowHeadersVisible = false;

            dgvResultados.Columns.Add("Iteracion", "Iter");

            // Columnas de Valores Iniciales (Viejos)
            for (int i = 0; i < n; i++) dgvResultados.Columns.Add($"Xv{i + 1}", $"X{i + 1} (Viejo)");

            // Columnas de Valores Nuevos
            for (int i = 0; i < n; i++) dgvResultados.Columns.Add($"Xn{i + 1}", $"X{i + 1} (Nuevo)");

            // Columnas de Errores Relativos
            for (int i = 0; i < n; i++) dgvResultados.Columns.Add($"Err{i + 1}", $"Error X{i + 1}");
        }

        // ==========================================
        // MOTOR GAUSS-SEIDEL
        // ==========================================
        private void EjecutarGaussSeidel(double[,] A, double[] B, double[] X, int n, double tolerancia)
        {
            int iteracion = 1;
            int iteracionesMaximas = 100;
            bool convergeGlobal = false;

            while (!convergeGlobal && iteracion <= iteracionesMaximas)
            {
                double[] X_viejo = (double[])X.Clone();
                double[] errores = new double[n];
                convergeGlobal = true; // Asumimos convergencia hasta probar lo contrario

                for (int i = 0; i < n; i++)
                {
                    double suma = 0;
                    for (int j = 0; j < n; j++)
                    {
                        if (i != j)
                        {
                            // La lógica fundamental: X[j] se actualiza en tiempo real
                            suma += A[i, j] * X[j];
                        }
                    }

                    X[i] = (B[i] - suma) / A[i, i];

                    // Calcular Error Relativo Fraccional (Exactamente como tu Excel)
                    if (X[i] != 0)
                    {
                        errores[i] = Math.Abs((X[i] - X_viejo[i]) / X[i]);
                    }
                    else
                    {
                        errores[i] = 1.0;
                    }

                    // Validar criterio de parada
                    if (iteracion == 1 || errores[i] > tolerancia)
                    {
                        convergeGlobal = false;
                    }
                }

                ImprimirFilaDetallada(iteracion, X_viejo, X, errores, n, iteracion == 1);

                // 🛡️ ESCUDO ANTI-DIVERGENCIA
                if (errores.Max() > 1000 || double.IsNaN(errores[0]))
                {
                    MessageBox.Show("¡Divergencia detectada!\n\nEl sistema está rebotando. Verifica que la matriz sea Diagonalmente Dominante.", "Fallo por Divergencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                iteracion++;
            }

            if (iteracion > iteracionesMaximas)
            {
                MessageBox.Show("Se alcanzó el límite de iteraciones sin llegar a la tolerancia.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show($"¡Convergencia alcanzada en {iteracion - 1} iteraciones usando Gauss-Seidel!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ==========================================
        // MOTOR JACOBI
        // ==========================================
        private void EjecutarJacobi(double[,] A, double[] B, double[] X, int n, double tolerancia)
        {
            // 1. Escudo de Diagonal Dominante (Requisito de tus apuntes)
            if (!EsDiagonalmenteDominante(A, n))
            {
                MessageBox.Show("Advertencia: La matriz ingresada NO es estrictamente diagonalmente dominante.\n\nEl método de Jacobi intentará resolverse, pero existe el riesgo de que el sistema diverja (rebotar sin encontrar solución).", "Advertencia de Convergencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            int iteracion = 1;
            int iteracionesMaximas = 100;
            bool convergeGlobal = false;

            // VECTOR TEMPORAL: Requisito clave de Jacobi para guardar los resultados nuevos
            // sin afectar los cálculos de la misma iteración.
            double[] X_nuevo = new double[n];

            while (!convergeGlobal && iteracion <= iteracionesMaximas)
            {
                double[] X_viejo = (double[])X.Clone();
                double[] errores = new double[n];
                convergeGlobal = true; // Asumimos convergencia hasta probar lo contrario

                // Calcular todos los nuevos valores simultáneamente
                for (int i = 0; i < n; i++)
                {
                    double suma = 0;
                    for (int j = 0; j < n; j++)
                    {
                        if (i != j)
                        {
                            // LA DIFERENCIA MATEMÁTICA CON SEIDEL:
                            // Usamos EXCLUSIVAMENTE X_viejo[j] de la iteración anterior.
                            suma += A[i, j] * X_viejo[j];
                        }
                    }

                    // Despejamos la variable de la diagonal principal
                    X_nuevo[i] = (B[i] - suma) / A[i, i];

                    // Calcular Error Relativo (Criterio de Parada)
                    if (X_nuevo[i] != 0)
                    {
                        errores[i] = Math.Abs((X_nuevo[i] - X_viejo[i]) / X_nuevo[i]);
                    }
                    else
                    {
                        errores[i] = 1.0;
                    }

                    if (iteracion == 1 || errores[i] > tolerancia)
                    {
                        convergeGlobal = false;
                    }
                }

                // Una vez calculadas TODAS las variables, actualizamos el vector solución real
                X = (double[])X_nuevo.Clone();

                // Enviamos los datos a tu DataGridView
                ImprimirFilaDetallada(iteracion, X_viejo, X, errores, n, iteracion == 1);

                // 🛡️ ESCUDO ANTI-DIVERGENCIA (Detectar si se va al infinito)
                if (errores.Max() > 1000 || double.IsNaN(errores[0]) || double.IsInfinity(X[0]))
                {
                    MessageBox.Show($"¡Divergencia detectada en la iteración {iteracion}!\n\nEl error está creciendo de forma descontrolada. El sistema no tiene solución mediante Jacobi con este orden de matriz.", "Fallo por Divergencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                iteracion++;
            }

            if (iteracion > iteracionesMaximas)
            {
                MessageBox.Show($"Se alcanzó el límite de {iteracionesMaximas} iteraciones sin llegar a la tolerancia permitida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show($"¡Convergencia alcanzada en {iteracion - 1} iteraciones usando Jacobi!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ImprimirFilaDetallada(int iteracion, double[] XViejos, double[] XNuevos, double[] errores, int n, bool esPrimeraIteracion)
        {
            List<object> row = new List<object> { iteracion };

            // 1. Llenar Valores Viejos
            for (int i = 0; i < n; i++) row.Add(Math.Round(XViejos[i], 8));

            // 2. Llenar Valores Nuevos
            for (int i = 0; i < n; i++) row.Add(Math.Round(XNuevos[i], 8));

            // 3. Llenar Errores
            for (int i = 0; i < n; i++)
            {
                if (esPrimeraIteracion)
                    row.Add("-"); // Iteración 1 no tiene error real
                else
                    row.Add(Math.Round(errores[i], 8).ToString("0.########"));
            }

            dgvResultados.Rows.Add(row.ToArray());
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvResultados.Columns.Clear();
            dgvSistema.Columns.Clear();
            txtValoresIniciales.Clear();
        }

        private void FormIterativos_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Si la bandera es FALSA, significa que el usuario le dio a la "X" roja.
            if (regresandoAlMenu == false)
            {
                // En lugar de Application.Exit(), usamos Environment.Exit(0)
                Environment.Exit(0);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            // Encendemos el semáforo para avisar que SÍ queremos regresar al menú
            regresandoAlMenu = true;

            // TRUCO: Buscamos el formulario principal que está oculto y lo volvemos a mostrar
            Form frmPrincipal = Application.OpenForms["FormPrincipal"];
            if (frmPrincipal != null)
            {
                frmPrincipal.Show();
            }

            // Ahora sí cerramos este formulario (esto disparará el evento de abajo)
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
