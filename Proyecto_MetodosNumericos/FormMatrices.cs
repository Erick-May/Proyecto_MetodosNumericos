using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using NCalc;

namespace Proyecto_MetodosNumericos
{
    public partial class FormMatrices : Form
    {
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
            if (Math.Abs(valor) < 1E-14) return "0";
            return valor.ToString("G10"); // Usa notación científica si es muy pequeño
        }

        // Evaluador Multivariable: Ahora detecta variables dinámicamente
        private double EvaluarNoLineal(string funcion, List<string> vars, double[] vals)
        {
            string funcFix = Regex.Replace(funcion, @"([a-zA-Z0-9_.]+)\^\(([^)]+)\)", "Pow($1, $2)");
            funcFix = Regex.Replace(funcFix, @"([a-zA-Z0-9_.]+)\^([a-zA-Z0-9_.]+)", "Pow($1, $2)");

            Expression e = new Expression(funcFix);
            for (int i = 0; i < vars.Count; i++)
            {
                e.Parameters[vars[i]] = vals[i];
            }
            e.Parameters["e"] = Math.E;

            // Agregamos soporte para funciones trigonométricas en español o abreviadas
            e.EvaluateFunction += delegate (string name, FunctionArgs args)
            {
                string nombre = name.ToLower();
                if (args.Parameters.Length > 0)
                {
                    double num = Convert.ToDouble(args.Parameters[0].Evaluate());
                    if (nombre == "sen" || nombre == "seno") { args.Result = Math.Sin(num); args.HasResult = true; }
                    else if (nombre == "sec") { args.Result = 1.0 / Math.Cos(num); args.HasResult = true; }
                    else if (nombre == "csc") { args.Result = 1.0 / Math.Sin(num); args.HasResult = true; }
                    else if (nombre == "cot") { args.Result = 1.0 / Math.Tan(num); args.HasResult = true; }
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
                if (Math.Abs(pivote) < 1E-15) throw new Exception("La matriz Jacobiana es singular. No se puede invertir.");
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

                int iteracion = 0;
                double h = 1E-6; // Salto para derivada numérica
                Color[] coloresExcel = { Color.LightGray, Color.CornflowerBlue, Color.SandyBrown, Color.LightGoldenrodYellow, Color.DarkSeaGreen, Color.SlateGray, Color.MediumOrchid };

                while (true)
                {
                    double[] F = new double[N];
                    double[,] J = new double[N, N];

                    // Evaluar funciones
                    for (int i = 0; i < N; i++) F[i] = EvaluarNoLineal(ecuaciones[i], varsDetectadas, X);

                    // Jacobiana Numérica
                    for (int i = 0; i < N; i++)
                    {
                        for (int j = 0; j < N; j++)
                        {
                            double original = X[j];
                            X[j] += h;
                            double f_h = EvaluarNoLineal(ecuaciones[i], varsDetectadas, X);
                            X[j] = original;
                            J[i, j] = (f_h - F[i]) / h;
                        }
                    }

                    double[,] J_inv = InvertirMatriz(J);

                    // Delta X = J^-1 * F
                    double[] deltaX = new double[N];
                    for (int i = 0; i < N; i++)
                        for (int j = 0; j < N; j++) deltaX[i] += J_inv[i, j] * F[j];

                    double[] X_nuevo = new double[N];
                    double[] errores = new double[N];
                    bool fin = true;

                    for (int i = 0; i < N; i++)
                    {
                        X_nuevo[i] = X[i] - deltaX[i];
                        errores[i] = Math.Abs(deltaX[i] / (X_nuevo[i] == 0 ? 1 : X_nuevo[i])) * 100.0;
                        if (errores[i] >= tolerancia) fin = false;
                    }

                    // Llenar tabla y aplicar colores
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

                    Color colorIter = coloresExcel[iteracion % coloresExcel.Length];
                    for (int k = filaInicio; k < dgvMatrices.Rows.Count; k++)
                        dgvMatrices.Rows[k].DefaultCellStyle.BackColor = colorIter;

                    X = X_nuevo;
                    if (fin && iteracion > 0) break;
                    if (++iteracion > 50) break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en los cálculos: " + ex.Message, "Error Matemático", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
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
    }
}
