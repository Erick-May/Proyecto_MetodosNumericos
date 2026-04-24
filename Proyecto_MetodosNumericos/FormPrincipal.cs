using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NCalc;
using Proyecto_MetodosNumericos.Data;
using Proyecto_MetodosNumericos.Models;
using System.Text.RegularExpressions;

namespace Proyecto_MetodosNumericos
{
    public partial class FormPrincipal : Form
    {
        private int idUsuarioActual;
        public FormPrincipal(int idUsuario)
        {
            InitializeComponent();
            idUsuarioActual = idUsuario;
            cmbMetodos.SelectedIndex = 0;
            ConfigurarTabla(cmbMetodos.SelectedItem.ToString());

            cmbMetodos.SelectedIndexChanged += cmbMetodos_SelectedIndexChanged;
            ActualizarEtiquetas(cmbMetodos.SelectedItem.ToString());
        }

        private void ConfigurarTabla(string metodo)
        {
            dgvIteraciones.Columns.Clear();

            if (metodo == "Biseccion")
            {
                dgvIteraciones.Columns.Add("Iteracion", "Iteración");
                dgvIteraciones.Columns.Add("A", "a");
                dgvIteraciones.Columns.Add("B", "b");
                dgvIteraciones.Columns.Add("Xm", "Xm (Punto Medio)");
                dgvIteraciones.Columns.Add("FA", "f(a)");
                dgvIteraciones.Columns.Add("FXm", "f(Xm)");
                dgvIteraciones.Columns.Add("Ea", "Ea (Absoluto)");
                dgvIteraciones.Columns.Add("Er", "Er%");
            }
            else if (metodo == "Regla Falsa")
            {
                dgvIteraciones.Columns.Add("Iteracion", "iteración");
                dgvIteraciones.Columns.Add("A", "a");
                dgvIteraciones.Columns.Add("B", "b");
                dgvIteraciones.Columns.Add("FA", "f(a)");
                dgvIteraciones.Columns.Add("FB", "f(b)");
                dgvIteraciones.Columns.Add("C", "c");
                dgvIteraciones.Columns.Add("FC", "f(c)");
                dgvIteraciones.Columns.Add("FA_FC", "f(a)*f(c)");
                dgvIteraciones.Columns.Add("Er", "Er%");
            }
            else if (metodo == "Newton-Raphson")
            {
                dgvIteraciones.Columns.Add("Iteracion", "iteración");
                dgvIteraciones.Columns.Add("Ci", "ci");
                dgvIteraciones.Columns.Add("FCi", "f(ci)");
                dgvIteraciones.Columns.Add("FpCi", "f'(ci) Numérica");
                dgvIteraciones.Columns.Add("Ci_1", "CI + 1");
                dgvIteraciones.Columns.Add("Ea", "Ea");
                dgvIteraciones.Columns.Add("Er", "Er%");
            }
            else if (metodo == "Secante")
            {
                dgvIteraciones.Columns.Add("Iteracion", "iteración");
                dgvIteraciones.Columns.Add("Ci", "Ci");
                dgvIteraciones.Columns.Add("F_Ci", "F(Ci)");
                dgvIteraciones.Columns.Add("C_menos1", "C-1");
                dgvIteraciones.Columns.Add("F_C_menos1", "F(C-1)");
                dgvIteraciones.Columns.Add("C_mas1", "Ci+1");
                dgvIteraciones.Columns.Add("F_C_mas1", "F(Ci+1)");
                dgvIteraciones.Columns.Add("Er", "Er%");
            }
            else if (metodo == "Punto Fijo")
            {
                dgvIteraciones.Columns.Add("Iteracion", "Iteración");
                dgvIteraciones.Columns.Add("Ci", "Ci");
                dgvIteraciones.Columns.Add("GCi", "g(Ci)");
                dgvIteraciones.Columns.Add("Er", "Er%");
            }
        }

        private double EvaluarFuncion(string funcion, double valorX)
        {
            try
            {
                // 1. Arreglamos potencias con paréntesis (Ej: e^(2*x) -> Pow(e, 2*x))
                string funcionCorregida = Regex.Replace(funcion, @"([a-zA-Z0-9_.]+)\^\(([^)]+)\)", "Pow($1, $2)");

                // 2. Arreglamos potencias simples sin paréntesis (Ej: x^2 -> Pow(x, 2))
                funcionCorregida = Regex.Replace(funcionCorregida, @"([a-zA-Z0-9_.]+)\^([a-zA-Z0-9_.]+)", "Pow($1, $2)");

                Expression e = new Expression(funcionCorregida);

                // 3. Parámetros principales
                e.Parameters["x"] = valorX;
                e.Parameters["e"] = Math.E;

                // 4. EL CEREBRO MATEMÁTICO EXPANDIDO
                e.EvaluateFunction += delegate (string name, FunctionArgs args)
                {
                    string nombreFuncion = name.ToLower();

                    if (args.Parameters.Length > 0)
                    {
                        double numero = Convert.ToDouble(args.Parameters[0].Evaluate());

                        // --- Funciones Básicas ---
                        if (nombreFuncion == "ln")
                        {
                            args.Result = Math.Log(numero);
                            args.HasResult = true;
                        }
                        else if (nombreFuncion == "tan")
                        {
                            args.Result = Math.Tan(numero);
                            args.HasResult = true;
                        }
                        else if (nombreFuncion == "sin" || nombreFuncion == "sen" || nombreFuncion == "seno")
                        {
                            args.Result = Math.Sin(numero);
                            args.HasResult = true;
                        }
                        else if (nombreFuncion == "cos")
                        {
                            args.Result = Math.Cos(numero);
                            args.HasResult = true;
                        }

                        // --- Funciones Recíprocas (Las que preguntaste) ---
                        else if (nombreFuncion == "sec")
                        {
                            // Secante = 1 / Coseno
                            args.Result = 1.0 / Math.Cos(numero);
                            args.HasResult = true;
                        }
                        else if (nombreFuncion == "csc" || nombreFuncion == "cosec")
                        {
                            // Cosecante = 1 / Seno
                            args.Result = 1.0 / Math.Sin(numero);
                            args.HasResult = true;
                        }
                        else if (nombreFuncion == "cot" || nombreFuncion == "cotan")
                        {
                            // Cotangente = 1 / Tangente
                            args.Result = 1.0 / Math.Tan(numero);
                            args.HasResult = true;
                        }
                    }
                };

                return Convert.ToDouble(e.Evaluate());
            }
            catch (Exception ex)
            {
                throw new Exception("Error al evaluar la función: " + ex.Message);
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            string funcion = txtFuncion.Text.Trim();
            string metodoSeleccionado = cmbMetodos.SelectedItem?.ToString() ?? "";

            if (string.IsNullOrEmpty(metodoSeleccionado))
            {
                MessageBox.Show("Por favor, selecciona un método.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ConfigurarTabla(metodoSeleccionado);
            dgvIteraciones.Rows.Clear();
            lblResultado.Text = "Resultado: ";

            double b_val = 0;
            if (metodoSeleccionado != "Newton-Raphson" && !double.TryParse(txtB.Text, out b_val) && metodoSeleccionado != "Punto Fijo" && !double.TryParse(txtB.Text, out b_val))
            {
                MessageBox.Show("Ingresa el valor B.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtA.Text, out double a) || !double.TryParse(txtTolerancia.Text, out double tolerancia))
            {
                MessageBox.Show("Por favor, ingresa valores numéricos válidos en A y Tolerancia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // ==========================================
                // BISECCIÓN
                // ==========================================
                if (metodoSeleccionado == "Biseccion")
                {
                    double b = b_val;
                    double fa = EvaluarFuncion(funcion, a);
                    double fb = EvaluarFuncion(funcion, b);

                    if (fa * fb >= 0)
                    {
                        MessageBox.Show("La función no cambia de signo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int iteracion = 1;
                    double xm = 0;
                    double xm_anterior = 0;
                    double errorRelativo = 100.0;

                    while (true)
                    {
                        xm = (a + b) / 2.0;
                        fa = EvaluarFuncion(funcion, a);
                        double fxm = EvaluarFuncion(funcion, xm);

                        double errorAbsoluto = Math.Abs(b - a);
                        string erMostrar = "";

                        if (iteracion > 1)
                        {
                            errorRelativo = Math.Abs((xm - xm_anterior) / xm) * 100.0;
                            erMostrar = Math.Round(errorRelativo, 2).ToString() + "%";
                        }

                        dgvIteraciones.Rows.Add(iteracion, Math.Round(a, 8), Math.Round(b, 8), Math.Round(xm, 8), Math.Round(fa, 8), Math.Round(fxm, 8), Math.Round(errorAbsoluto, 5), erMostrar);

                        if (Math.Abs(fxm) < 0.0000001 || (iteracion > 1 && errorRelativo < tolerancia)) break;

                        if (fa * fxm < 0) b = xm;
                        else a = xm;

                        xm_anterior = xm;
                        iteracion++;
                        if (iteracion > 100) break;
                    }
                    lblResultado.Text = $"Resultado: {Math.Round(xm, 8)}";
                    GuardarHistorial(metodoSeleccionado, funcion);
                }

                // ==========================================
                // REGLA FALSA
                // ==========================================
                else if (metodoSeleccionado == "Regla Falsa")
                {
                    double b = b_val;
                    double fa = EvaluarFuncion(funcion, a);
                    double fb = EvaluarFuncion(funcion, b);

                    if (fa * fb >= 0)
                    {
                        MessageBox.Show("La función no cambia de signo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int iteracion = 1;
                    double c = 0;
                    double c_anterior = 0;
                    double errorRelativo = 100.0;

                    while (true)
                    {
                        fa = EvaluarFuncion(funcion, a);
                        fb = EvaluarFuncion(funcion, b);
                        c = b - ((fb * (a - b)) / (fa - fb));

                        double fc = EvaluarFuncion(funcion, c);
                        double productoSignos = fa * fc;
                        string errorMostrar = "";

                        if (iteracion > 1)
                        {
                            errorRelativo = Math.Abs((c - c_anterior) / c) * 100.0;
                            errorMostrar = Math.Round(errorRelativo, 2).ToString() + "%";
                        }

                        dgvIteraciones.Rows.Add(iteracion, Math.Round(a, 8), Math.Round(b, 8), Math.Round(fa, 8), Math.Round(fb, 8), Math.Round(c, 8), Math.Round(fc, 8), Math.Round(productoSignos, 8), errorMostrar);

                        if (Math.Abs(fc) < 0.0000001 || (iteracion > 1 && errorRelativo < tolerancia)) break;

                        if (productoSignos < 0) b = c;
                        else a = c;

                        c_anterior = c;
                        iteracion++;
                        if (iteracion > 100) break;
                    }
                    lblResultado.Text = $"Resultado: {Math.Round(c, 8)}";
                    GuardarHistorial(metodoSeleccionado, funcion);
                }

                // ==========================================
                // NEWTON-RAPHSON
                // ==========================================
                else if (metodoSeleccionado == "Newton-Raphson")
                {
                    double ci = a;
                    double ci_anterior = 0;
                    double errorRelativo = 100.0;
                    int iteracion = 0;

                    double h = 0.000001;

                    while (true)
                    {
                        double f_ci = EvaluarFuncion(funcion, ci);

                        // EL TRUCO MAESTRO: Derivación numérica f'(ci) = (f(ci + h) - f(ci)) / h
                        double f_ci_mas_h = EvaluarFuncion(funcion, ci + h);
                        double fp_ci = (f_ci_mas_h - f_ci) / h;

                        if (Math.Abs(fp_ci) < 0.0000001) // Para evitar dividir entre cero
                        {
                            MessageBox.Show("La derivada se hizo cero (o casi cero). El método se indefine porque la recta es paralela al eje X.", "Error Matemático", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }

                        // Fórmula de Newton: CI_nuevo = CI_viejo - f(CI) / f'(CI)
                        double c_nuevo = ci - (f_ci / fp_ci);

                        string eaMostrar = "";
                        string erMostrar = "";

                        // Calculamos errores imitando tu Excel
                        if (iteracion > 0)
                        {
                            double ea = Math.Abs(c_nuevo - ci);
                            errorRelativo = Math.Abs((ci - ci_anterior) / ci) * 100.0;

                            eaMostrar = Math.Round(ea, 5).ToString();
                            erMostrar = Math.Round(errorRelativo, 3).ToString() + "%";
                        }

                        dgvIteraciones.Rows.Add(iteracion, Math.Round(ci, 8), Math.Round(f_ci, 8), Math.Round(fp_ci, 8), Math.Round(c_nuevo, 8), eaMostrar, erMostrar);

                        // Freno: Si llegamos a la tolerancia, salimos del ciclo
                        if (Math.Abs(f_ci) < 0.0000001 || (iteracion > 0 && errorRelativo < tolerancia))
                        {
                            lblResultado.Text = $"Resultado: {Math.Round(c_nuevo, 8)}";
                            break;
                        }

                        ci_anterior = ci;
                        ci = c_nuevo;
                        iteracion++;
                        if (iteracion > 100) break;
                    }
                    GuardarHistorial(metodoSeleccionado, funcion);
                }
                // ==========================================
                // MÉTODO DE LA SECANTE
                // ==========================================
                else if (metodoSeleccionado == "Secante")
                {
                    // Secante exige A (como C-1) y B (como Ci)
                    if (string.IsNullOrEmpty(txtB.Text))
                    {
                        MessageBox.Show("Para el método de la Secante necesitas ingresar dos valores iniciales en A y B.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    double c_menos1 = a;     // El valor más viejo (C-1) entra por A
                    double ci = b_val;       // El valor más reciente (Ci) entra por B

                    double errorRelativo = 100.0;
                    int iteracion = 1;

                    while (true)
                    {
                        double f_c_menos1 = EvaluarFuncion(funcion, c_menos1);
                        double f_ci = EvaluarFuncion(funcion, ci);

                        double denominador = f_ci - f_c_menos1;

                        // Medida de seguridad: Si el denominador es cero, hay división entre cero
                        if (Math.Abs(denominador) < 0.0000001)
                        {
                            MessageBox.Show("El denominador se hizo cero (o casi cero). El método se indefine porque la recta secante es horizontal.", "Error Matemático", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }

                        // Fórmula de la Secante: Ci+1 = Ci - [f(Ci) * (Ci - C-1)] / [f(Ci) - f(C-1)]
                        double c_mas1 = ci - ((f_ci * (ci - c_menos1)) / denominador);

                        double f_c_mas1 = EvaluarFuncion(funcion, c_mas1);

                        string erMostrar = "";

                        // Calculamos el Er% evaluando la diferencia entre el nuevo (c_mas1) y el actual (ci)
                        if (iteracion > 1)
                        {
                            errorRelativo = Math.Abs((c_mas1 - ci) / c_mas1) * 100.0;
                            erMostrar = Math.Round(errorRelativo, 4).ToString() + "%";
                        }

                        // Imprimimos la fila en el orden exacto de tu Excel
                        dgvIteraciones.Rows.Add(
                            iteracion,
                            Math.Round(ci, 6),
                            Math.Round(f_ci, 6),
                            Math.Round(c_menos1, 6),
                            Math.Round(f_c_menos1, 6),
                            Math.Round(c_mas1, 6),
                            Math.Round(f_c_mas1, 6),
                            erMostrar
                        );

                        // Freno: Si llegamos a la raíz exacta o si vencimos a la tolerancia
                        if (Math.Abs(f_c_mas1) < 0.0000001 || (iteracion > 1 && errorRelativo < tolerancia))
                        {
                            lblResultado.Text = $"Resultado: {Math.Round(c_mas1, 6)}";
                            break;
                        }

                        // ==========================================
                        // LA ROTACIÓN DE VARIABLES (CRÍTICO)
                        // ==========================================
                        // El valor que era actual (ci) ahora envejece y pasa a ser el anterior
                        c_menos1 = ci;
                        // El nuevo valor recién calculado (c_mas1) pasa a ser el actual para la otra vuelta
                        ci = c_mas1;

                        iteracion++;
                        if (iteracion > 50) break; // Límite de seguridad
                    }
                    GuardarHistorial(metodoSeleccionado, funcion);
                }
                // ==========================================
                // MÉTODO DEL PUNTO FIJO
                // ==========================================
                else if (metodoSeleccionado == "Punto Fijo")
                {
                    double ci = a; // Usamos el cuadro A como valor inicial
                    double ci_anterior = 0; // NUEVO: Para guardar el histórico y calcular el error como en Excel
                    double errorRelativo = 100.0;
                    int iteracion = 0; // Tu Excel inicia en 0

                    while (true)
                    {
                        // Evaluamos la función g(x)
                        double g_ci = EvaluarFuncion(funcion, ci);

                        string erMostrar = "";

                        // Calculamos el error imitando exactamente las celdas de tu Excel
                        if (iteracion > 0)
                        {
                            // Excel usa: |(Ci actual - Ci anterior) / Ci actual|
                            errorRelativo = Math.Abs((ci - ci_anterior) / ci) * 100.0;
                            erMostrar = Math.Round(errorRelativo, 6).ToString() + "%";
                        }

                        // Agregamos a la tabla
                        dgvIteraciones.Rows.Add(iteracion, Math.Round(ci, 8), Math.Round(g_ci, 8), erMostrar);

                        // Freno: Si llegamos a la tolerancia
                        if (iteracion > 0 && errorRelativo < tolerancia)
                        {
                            // Imprimimos el Ci que acaba de cumplir la tolerancia
                            lblResultado.Text = $"Resultado: {Math.Round(ci, 8)}";
                            break;
                        }

                        // ==========================================
                        // ROTACIÓN DE VARIABLES (Como en tu Excel)
                        // ==========================================
                        ci_anterior = ci; // El Ci actual se vuelve el viejo
                        ci = g_ci;        // El g(Ci) recién calculado se vuelve el nuevo Ci de entrada
                        iteracion++;

                        // Freno de emergencia por si la función diverge (g'(x) > 1)
                        if (iteracion > 100)
                        {
                            MessageBox.Show("El método no convergió después de 100 iteraciones. Probablemente la función diverge porque su derivada es mayor a 1 en este punto.", "Aviso de Divergencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    }
                    GuardarHistorial(metodoSeleccionado, funcion);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Ejecución", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarHistorial(string metodo, string funcion)
        {
            try
            {
                using (var db = new AppMetodosContext())
                {
                    var registro = new HistorialOperacion
                    {
                        IdUsuario = idUsuarioActual,
                        Metodo = metodo,
                        FuncionEvaluada = funcion,
                        FechaConsulta = DateTime.Now
                    };
                    db.HistorialOperaciones.Add(registro);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Ignoramos error visual en base de datos si ocurre, para no molestar el flujo
            }
        }

        private void cmbMetodos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string metodo = cmbMetodos.SelectedItem?.ToString() ?? "";

            // Actualizamos las columnas de la tabla en vivo
            ConfigurarTabla(metodo);

            // Actualizamos los textos de Label6 y Label7
            ActualizarEtiquetas(metodo);
        }

        private void ActualizarEtiquetas(string metodo)
        {
            if (label6 == null || label7 == null || label8 == null) return;

            // Por defecto, la etiqueta pide la f(x) normal
            label8.Text = ".";

            if (metodo == "Biseccion" || metodo == "Regla Falsa")
            {
                label6.Text = ".";
                label7.Text = ".";
                txtB.Enabled = true;
            }
            else if (metodo == "Newton-Raphson")
            {
                label6.Text = "Ci (Valor Inicial)";
                label7.Text = ". (No se usa)";
                txtB.Enabled = false;
                txtB.Clear();
            }
            else if (metodo == "Punto Fijo")
            {
                // ¡AQUÍ ESTÁ LA MAGIA VISUAL!
                label8.Text = "Nota: Tienes que despejar X de la funcion f(x) para obtener g(x) y escribe g(x) para buscar su raiz ☝️";
                label6.Text = "Ci (Valor Inicial)";
                label7.Text = ". (No se usa)";
                txtB.Enabled = false;
                txtB.Clear();
            }
            else if (metodo == "Secante")
            {
                label6.Text = "C-1";
                label7.Text = "Ci";
                txtB.Enabled = true;
            }
        }
    }
    
}
