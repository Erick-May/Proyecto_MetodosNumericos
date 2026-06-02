using NCalc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Proyecto_MetodosNumericos
{
    public partial class FormMatrices : Form
    {
        bool regresandoAlMenu = false;
        public FormMatrices()
        {
            InitializeComponent();

            if (cmbMetodosMatrices.Items.Count == 0)
            {
                cmbMetodosMatrices.Items.Add("Newton-Raphson no lineales");
            }
            cmbMetodosMatrices.SelectedIndex = 0;
            cmbMetodosMatrices.SelectedIndexChanged += cmbMetodosMatrices_SelectedIndexChanged;
        }

        // Limpiador de ruido de punto flotante (Evita basura microscópica de la CPU)
        private string FormatearValor(double valor)
        {
            // 1. Hacemos el redondeo a 8 decimales que pediste para los números normales
            double redondeado = Math.Round(valor, 8);

            // 2. Si el redondeo lo convirtió en un 0, PERO el número original no era un 0 perfecto (la "basura" microscópica)
            if (redondeado == 0 && Math.Abs(valor) > 0)
            {
                // Lo mostramos en notación científica para que salgan tus números morados de la profe
                return valor.ToString("E4");
            }

            // 3. Si es un número normal o un cero real, lo muestra redondeado y limpio
            return redondeado.ToString("0.########");
        }

        private string ArreglarPotencias(string expresion)
        {
            while (expresion.Contains("^"))
            {
                int index = expresion.IndexOf('^');
                int start = index - 1;
                int openParens = 0;
                if (start >= 0 && expresion[start] == ')')
                {
                    openParens = 1;
                    start--;
                    while (start >= 0 && openParens > 0)
                    {
                        if (expresion[start] == ')') openParens++;
                        if (expresion[start] == '(') openParens--;
                        start--;
                    }
                    start++;
                    while (start - 1 >= 0 && char.IsLetter(expresion[start - 1])) start--;
                }
                else
                {
                    while (start >= 0 && (char.IsLetterOrDigit(expresion[start]) || expresion[start] == '.' || expresion[start] == '_')) start--;
                    start++;
                }
                string baseStr = expresion.Substring(start, index - start);

                int end = index + 1;
                openParens = 0;
                if (end < expresion.Length && expresion[end] == '(')
                {
                    openParens = 1;
                    end++;
                    while (end < expresion.Length && openParens > 0)
                    {
                        if (expresion[end] == '(') openParens++;
                        if (expresion[end] == ')') openParens--;
                        end++;
                    }
                    end--;
                }
                else
                {
                    if (end < expresion.Length && expresion[end] == '-') end++;
                    // Eliminamos el '/' para evitar el bug del exponente division
                    while (end < expresion.Length && (char.IsLetterOrDigit(expresion[end]) || expresion[end] == '.' || expresion[end] == '_')) end++;
                    end--;
                }
                string expStr = expresion.Substring(index + 1, end - index);

                string prefijo = expresion.Substring(0, start);
                string sufijo = expresion.Substring(end + 1);
                expresion = prefijo + $"Pow({baseStr}, {expStr})" + sufijo;
            }
            return expresion;
        }

        private double EvaluarNoLineal(string funcion, List<string> vars, double[] vals)
        {
            string funcFix = funcion.ToLower();

            // 1. Evitar división entera (Convierte 1/2 a 1.0/2.0)
            funcFix = Regex.Replace(funcFix, @"(?<!\.)\b(\d+)\b(?!\.)", "$1.0");

            // 2. Multiplicación Implícita Segura
            funcFix = Regex.Replace(funcFix, @"(\d)([a-z\(])", "$1*$2"); // 2x -> 2*x
            funcFix = Regex.Replace(funcFix, @"(\))([a-z0-9\(])", "$1*$2"); // )( -> )*(

            // 3. Motor de Potencias
            funcFix = ArreglarPotencias(funcFix);

            Expression e = new Expression(funcFix);
            for (int i = 0; i < vars.Count; i++)
            {
                e.Parameters[vars[i]] = vals[i];
            }
            e.Parameters["e"] = Math.E;
            e.Parameters["pi"] = Math.PI;

            e.EvaluateFunction += delegate (string name, FunctionArgs args)
            {
                string nombre = name.ToLower();
                if (args.Parameters.Length > 0)
                {
                    double num = Convert.ToDouble(args.Parameters[0].Evaluate());
                    if (nombre == "sen" || nombre == "seno" || nombre == "sin") { args.Result = Math.Sin(num); args.HasResult = true; }
                    else if (nombre == "ln") { args.Result = Math.Log(num); args.HasResult = true; }
                    else if (nombre == "tan") { args.Result = Math.Tan(num); args.HasResult = true; }
                    else if (nombre == "cos") { args.Result = Math.Cos(num); args.HasResult = true; }
                    else if (nombre == "sqrt" || nombre == "raiz") { args.Result = Math.Sqrt(num); args.HasResult = true; }
                }
            };

            return Convert.ToDouble(e.Evaluate());
        }

        // Inversor de Matrices (Gauss-Jordan) para la Jacobiana
        private double[,] InvertirMatriz(double[,] matriz)
        {
            int n = matriz.GetLength(0);
            double[,] aug = new double[n, 2 * n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++) aug[i, j] = matriz[i, j];
                aug[i, i + n] = 1.0;
            }

            for (int i = 0; i < n; i++)
            {
                double pivote = aug[i, i];
                if (Math.Abs(pivote) < 1E-15) throw new Exception("La matriz Jacobiana es singular. No se puede invertir, revise sus datos.");
                for (int k = 0; k < 2 * n; k++) aug[i, k] /= pivote;
                for (int j = 0; j < n; j++)
                {
                    if (j != i)
                    {
                        double factor = aug[j, i];
                        for (int k = 0; k < 2 * n; k++) aug[j, k] -= factor * aug[i, k];
                    }
                }
            }
            double[,] res = new double[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++) res[i, j] = aug[i, j + n];
            return res;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                dgvMatrices.Columns.Clear();
                dgvMatrices.Rows.Clear();

                // 1. Obtener Ecuaciones y Valores Iniciales (Línea por línea)
                string[] ecuaciones = txtSistemasNL.Lines.Where(l => !string.IsNullOrWhiteSpace(l)).ToArray();
                string[] valoresTexto = txtValoresInicialesNL.Lines.Where(l => !string.IsNullOrWhiteSpace(l)).ToArray();
                int N = ecuaciones.Length;

                if (valoresTexto.Length != N)
                {
                    MessageBox.Show($"Error: Tenés {N} ecuaciones pero pusiste {valoresTexto.Length} valores iniciales.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double tolerancia = Convert.ToDouble(txtTolerancia.Text);
                double[] X = valoresTexto.Select(double.Parse).ToArray();

                // 2. DETECCIÓN AUTOMÁTICA DE VARIABLES (Lo que me pediste)
                // Buscamos nombres de variables en todas las ecuaciones
                List<string> varsDetectadas = new List<string>();
                foreach (string eq in ecuaciones)
                {
                    var matches = Regex.Matches(eq, @"[a-zA-Z_][a-zA-Z0-9_]*");
                    foreach (Match m in matches)
                    {
                        string v = m.Value.ToLower();
                        // Ignoramos funciones matemáticas y constantes
                        if (new[] { "e", "pi", "pow", "sin", "sen", "cos", "tan", "ln", "log", "sec", "csc", "cot" }.Contains(v)) continue;
                        if (!varsDetectadas.Contains(v)) varsDetectadas.Add(v);
                    }
                }
                varsDetectadas = varsDetectadas.OrderBy(v => v).ToList(); // Ordenamos x, y, z...

                // 3. Configurar Columnas dinámicas del DGV
                dgvMatrices.Columns.Add("X", "X (Variables)");
                for (int i = 0; i < N; i++) dgvMatrices.Columns.Add($"J{i}", $"J(X) C{i + 1}");
                for (int i = 0; i < N; i++) dgvMatrices.Columns.Add($"Jinv{i}", $"[J(X)]^-1 C{i + 1}");
                dgvMatrices.Columns.Add("FX", "F(X)");
                dgvMatrices.Columns.Add("DeltaX", "[J(X)]^-1 * F(X)");
                dgvMatrices.Columns.Add("Er", "Error %");

                dgvMatrices.AllowUserToAddRows = false; // Quita la fea fila blanca vacía del final
                dgvMatrices.RowHeadersVisible = false; // Quita la columna gris inútil de la izquierda
                dgvMatrices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Estira las columnas para rellenar los vacíos
                dgvMatrices.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Que la selección no rompa la celda

                int iteracion = 0;
                double h = 1E-6; // Salto para derivada numérica
                Color[] coloresExcel = { Color.LightGray, Color.CornflowerBlue, Color.SandyBrown, Color.LightGoldenrodYellow, Color.DarkSeaGreen, Color.SlateGray, Color.MediumOrchid };

                while (true)
                {
                    double[] F = new double[N];
                    double[,] J = new double[N, N];

                    // 1. Evaluar F(X) y aplicar Escudo Anti-NaN
                    for (int i = 0; i < N; i++)
                    {
                        F[i] = EvaluarNoLineal(ecuaciones[i], varsDetectadas, X);
                        if (double.IsNaN(F[i]) || double.IsInfinity(F[i]))
                        {
                            MessageBox.Show($"¡Divergencia detectada! La ecuación {i + 1} se indefine en los valores actuales. La matriz explotó matemáticamente.", "Escudo Activado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // 2. Construir Matriz Jacobiana Numérica (POR DIFERENCIAS CENTRALES)
                    for (int i = 0; i < N; i++)
                    {
                        for (int j = 0; j < N; j++)
                        {
                            double original = X[j];

                            // Salto hacia adelante
                            X[j] = original + h;
                            double f_mas_h = EvaluarNoLineal(ecuaciones[i], varsDetectadas, X);

                            // Salto hacia atrás
                            X[j] = original - h;
                            double f_menos_h = EvaluarNoLineal(ecuaciones[i], varsDetectadas, X);

                            // Restaurar valor y calcular derivada
                            X[j] = original;
                            J[i, j] = (f_mas_h - f_menos_h) / (2.0 * h);

                            if (double.IsNaN(J[i, j]) || double.IsInfinity(J[i, j]))
                            {
                                MessageBox.Show($"¡Error! La derivada parcial de la ecuación {i + 1} respecto a {varsDetectadas[j]} se volvió infinita o imaginaria.", "Divergencia Numérica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    // 3. Invertir Jacobiana (Atrapar si es Singular)
                    double[,] J_inv;
                    try
                    {
                        J_inv = InvertirMatriz(J);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "\n\nSugerencia: El método requiere empezar desde un punto inicial diferente donde las curvas no sean paralelas.", "Falla del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 4. Calcular Delta X = J_inv * F
                    double[] deltaX = new double[N];
                    for (int i = 0; i < N; i++)
                    {
                        for (int j = 0; j < N; j++)
                        {
                            deltaX[i] += J_inv[i, j] * F[j];
                        }
                    }

                    // 5. Calcular nuevo X y el Error de convergencia
                    double[] X_nuevo = new double[N];
                    double[] errores = new double[N];
                    bool fin = true;

                    for (int i = 0; i < N; i++)
                    {
                        X_nuevo[i] = X[i] - deltaX[i];

                        // Cuidarse de la división entre cero en el cálculo del error
                        if (X_nuevo[i] == 0)
                            errores[i] = Math.Abs(deltaX[i]) * 100.0;
                        else
                            errores[i] = Math.Abs(deltaX[i] / X_nuevo[i]) * 100.0;

                        if (errores[i] >= tolerancia) fin = false;
                    }

                    // ==========================================
                    // 6. IMPRESIÓN Y COLORES EN BLOQUE
                    // ==========================================
                    int filaInicio = dgvMatrices.Rows.Count;
                    for (int r = 0; r < N; r++)
                    {
                        List<object> row = new List<object> { FormatearValor(X[r]) };
                        for (int c = 0; c < N; c++) row.Add(FormatearValor(J[r, c]));
                        for (int c = 0; c < N; c++) row.Add(FormatearValor(J_inv[r, c]));
                        row.Add(FormatearValor(F[r]));
                        row.Add(FormatearValor(deltaX[r]));
                        row.Add(iteracion == 0 ? "-" : $"{Math.Round(errores[r], 4)}%");

                        dgvMatrices.Rows.Add(row.ToArray());
                    }

                    // Aplicar color sólido a todo el bloque de esta iteración
                    Color colorIter = coloresExcel[iteracion % coloresExcel.Length];
                    for (int k = filaInicio; k < dgvMatrices.Rows.Count; k++)
                    {
                        dgvMatrices.Rows[k].DefaultCellStyle.BackColor = colorIter;

                        // TRUCO: Que el color de selección sea igual al del bloque para que no se ponga azul al darle clic
                        dgvMatrices.Rows[k].DefaultCellStyle.SelectionBackColor = colorIter;
                        dgvMatrices.Rows[k].DefaultCellStyle.SelectionForeColor = Color.Black;
                    }

                    // 7. Rotar variables para la siguiente vuelta
                    X = X_nuevo;

                    // 8. Freno de Éxito
                    if (fin && iteracion > 0)
                    {
                        MessageBox.Show("¡Convergencia alcanzada! Las raíces del sistema han sido encontradas.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                    iteracion++;

                    // 9. Freno de Emergencia (Para no trabar la RAM)
                    if (iteracion > 50)
                    {
                        MessageBox.Show("Límite de iteraciones alcanzado. El sistema es altamente inestable o diverge con estos valores iniciales. Prueba con otro punto de partida.", "Aviso de Divergencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en los cálculos: " + ex.Message, "Error Matemático", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void cmbMetodosMatrices_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarEtiquetas(cmbMetodosMatrices.SelectedItem?.ToString() ?? "");
        }

        private void ActualizarEtiquetas(string metodo)
        {
            if (label1 == null) return;

            label1.Text = "METODOS DE MATRICES";

            if (metodo == "Newton-Raphson no lineales")
            {
                label1.Text = "Metodo de Newton-Raphson para SENL";
                btnCalcular.Text = "Calcular Newton-Raphson";
            }

        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            // 1. Preguntamos si quiere descargar el manual
            DialogResult respuesta = MessageBox.Show("¿Quieres descargar el manual de uso?", "Descargar Manual", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                // 2. Abrimos la ventana para guardar el archivo
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivo de Texto (*.txt)|*.txt";
                saveFileDialog.Title = "Guardar Manual de Uso";
                saveFileDialog.FileName = "Manual_MetodosMatrices.txt"; // Nombre por defecto

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 3. El texto que va a llevar el bloc de notas (Cámbialo según el Form)
                    string contenido = @"==================================================
 MANUAL DE USUARIO - SISTEMAS DE ECUACIONES NO LINEALES
==================================================
¡Bienvenido! Esta sección resuelve sistemas de ecuaciones complejos usando el método de Newton-Raphson para múltiples variables (Matrices).

¿CÓMO INGRESAR LOS DATOS?
1. Ecuaciones:
   - Escribe UNA ecuación por línea en el cuadro de texto grande.
   - Usa las letras que prefieras (x, y, z, etc.). El programa las detectará automáticamente.
   - Iguala tus ecuaciones a cero mentalmente (Ejemplo: Si tu ecuación es x^2 + y^2 = 10, debes escribir x^2 + y^2 - 10).

2. Valores Iniciales:
   - Escribe un valor inicial por línea en el segundo cuadro.
   - Deben estar en el mismo orden alfabético de las letras que usaste.
   - ¡Debe haber la misma cantidad de ecuaciones que de valores iniciales!

Ejemplo práctico:
[Ecuaciones]
x^2 + y^2 - 10
x^2 - y^2 - 1

[Valores Iniciales]
2.5
2.0

Luego, ingresa tu Tolerancia (ej: 0.01) y el programa generará la matriz Jacobiana paso a paso por colores.";

                    try
                    {
                        // 4. Creamos y guardamos el archivo físico
                        File.WriteAllText(saveFileDialog.FileName, contenido);
                        MessageBox.Show("¡Manual descargado correctamente! Revísalo donde lo guardaste.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hubo un error al guardar el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtTolerancia_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 1. Si el usuario presiona coma, la transformamos en punto automáticamente
            if (e.KeyChar == ',') e.KeyChar = '.';

            // 2. Si no es un número, ni la tecla de borrar, ni un punto, bloqueamos la tecla
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // 3. Evitar que ponga más de un punto (ej: 0.0.1)
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void FormMatrices_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Si la bandera es FALSA, significa que el usuario le dio a la "X" roja.
            if (regresandoAlMenu == false)
            {
                // En lugar de Application.Exit(), usamos Environment.Exit(0)
                Environment.Exit(0);
            }
        }
    }
}
