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
using System.IO;

namespace Proyecto_MetodosNumericos
{
    public partial class FormPrincipal : Form
    {
        bool regresandoAlMenu = false;
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
                dgvIteraciones.Columns.Add("GpCi", "g'(Ci)"); // NUEVA COLUMNA DE LA DERIVADA
                dgvIteraciones.Columns.Add("Er", "Er%");
            }
        }

        private double EvaluarFuncion(string funcion, double valorX)
        {
            try
            {
                string funcionCorregida = funcion.ToLower();

                // 1. EVITAR DIVISIÓN ENTERA
                funcionCorregida = Regex.Replace(funcionCorregida, @"(?<!\.)\b(\d+)\b(?!\.)", "$1.0");

                // 🔥 2. EL FIX DE MULTIPLICACIÓN IMPLÍCITA: Ya detecta ()() y x(x-4)
                funcionCorregida = Regex.Replace(funcionCorregida, @"(\d)([a-z\(])", "$1*$2");
                funcionCorregida = Regex.Replace(funcionCorregida, @"(x)([a-z0-9\(])", "$1*$2");
                funcionCorregida = Regex.Replace(funcionCorregida, @"(\))([a-z0-9x\(])", "$1*$2");

                // 3. MOTOR DE POTENCIAS ARREGLADO
                funcionCorregida = ArreglarPotencias(funcionCorregida);

                Expression e = new Expression(funcionCorregida);
                e.Parameters["x"] = valorX;
                e.Parameters["e"] = Math.E;
                e.Parameters["pi"] = Math.PI;

                e.EvaluateFunction += delegate (string name, FunctionArgs args)
                {
                    string nombreFuncion = name.ToLower();
                    if (args.Parameters.Length > 0)
                    {
                        double numero = Convert.ToDouble(args.Parameters[0].Evaluate());

                        if (nombreFuncion == "ln") { args.Result = Math.Log(numero); args.HasResult = true; }
                        else if (nombreFuncion == "tan") { args.Result = Math.Tan(numero); args.HasResult = true; }
                        else if (nombreFuncion == "sin" || nombreFuncion == "sen" || nombreFuncion == "seno") { args.Result = Math.Sin(numero); args.HasResult = true; }
                        else if (nombreFuncion == "cos") { args.Result = Math.Cos(numero); args.HasResult = true; }
                        else if (nombreFuncion == "sqrt" || nombreFuncion == "raiz") { args.Result = Math.Sqrt(numero); args.HasResult = true; }
                        else if (nombreFuncion == "sec") { args.Result = 1.0 / Math.Cos(numero); args.HasResult = true; }
                        else if (nombreFuncion == "csc" || nombreFuncion == "cosec") { args.Result = 1.0 / Math.Sin(numero); args.HasResult = true; }
                        else if (nombreFuncion == "cot" || nombreFuncion == "cotan") { args.Result = 1.0 / Math.Tan(numero); args.HasResult = true; }
                    }
                };

                double resultadoFinal = Convert.ToDouble(e.Evaluate());

                // 🔥 MEGA ESCUDO ANTI-IMAGINARIOS Y ANTI-INFINITO
                if (double.IsNaN(resultadoFinal) || double.IsInfinity(resultadoFinal))
                {
                    throw new Exception("ERROR_MATEMATICO");
                }

                return resultadoFinal;
            }
            catch (Exception ex)
            {
                // Si fue el escudo, lanzamos el mensaje de divergencia/dominio. Si fue otra cosa, el de sintaxis.
                if (ex.Message == "ERROR_MATEMATICO")
                {
                    throw new Exception("La función se indefine matemáticamente en este punto (genera un número imaginario, NaN o división entre cero).\n\nCambia tu valor inicial o revisa el dominio de tu función.");
                }
                throw new Exception("Revise la sintaxis de su función. Probablemente te faltó cerrar un paréntesis o el orden es incorrecto.");
            }
        }

        private string ArreglarPotencias(string expresion)
        {
            while (expresion.Contains("^"))
            {
                int index = expresion.IndexOf('^');

                // Buscar la BASE (hacia atrás)
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
                    while (start >= 0 && (char.IsLetterOrDigit(expresion[start]) || expresion[start] == '.')) start--;
                    start++;
                }
                string baseStr = expresion.Substring(start, index - start);

                // Buscar el EXPONENTE (hacia adelante)
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

                    // AQUÍ ESTÁ EL FIX: Le quité la lectura de la división (/)
                    while (end < expresion.Length && (char.IsLetterOrDigit(expresion[end]) || expresion[end] == '.')) end++;

                    end--;
                }
                string expStr = expresion.Substring(index + 1, end - index);

                string prefijo = expresion.Substring(0, start);
                string sufijo = expresion.Substring(end + 1);
                expresion = prefijo + $"Pow({baseStr}, {expStr})" + sufijo;
            }
            return expresion;
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

            // =====================================
            // 🛡️ ESCUDO DE VALIDACIÓN DE LA FUNCIÓN
            // =====================================
            string funcionMinuscula = funcion.ToLower();

            if (string.IsNullOrEmpty(funcion))
            {
                MessageBox.Show("¡Ey! No has escrito ninguna función para evaluar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Validar que tenga la letra 'x' para que no pongan solo "1/2"
            if (!funcionMinuscula.Contains("x"))
            {
                MessageBox.Show("Tu función debe contener la variable 'x'. Si escribiste una fracción o constante numérica (ej. 1/2), agrégale la variable para que sea una ecuación válida.", "Falta la variable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validar que los paréntesis estén balanceados (mismo número de abiertos y cerrados)
            int abiertos = funcion.Split('(').Length - 1;
            int cerrados = funcion.Split(')').Length - 1;
            if (abiertos != cerrados)
            {
                MessageBox.Show($"Revisa tu ecuación. Tienes {abiertos} paréntesis abiertos y {cerrados} cerrados. Te faltó cerrar o abrir alguno.", "Error de Paréntesis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // =====================================

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
                            errorRelativo = Math.Abs((xm - xm_anterior) / xm) * 100;
                            erMostrar = Math.Round(errorRelativo, 8).ToString() + "%";
                        }

                        dgvIteraciones.Rows.Add(iteracion, Math.Round(a, 8), Math.Round(b, 8), Math.Round(xm, 8), Math.Round(fa, 8), Math.Round(fxm, 8), Math.Round(errorAbsoluto, 8), erMostrar);

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
                            errorRelativo = Math.Abs((c - c_anterior) / c) * 100;
                            errorMostrar = Math.Round(errorRelativo, 8).ToString() + "%";
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
                    double ci = a; // Valor inicial Xi
                    double ci_anterior = 0;
                    double errorRelativo = 100.0;
                    double ea = 0;
                    int iteracion = 1; // Tus amigos empiezan en la iteración 1

                    // h = 0.00001 es el balance perfecto para la Diferencia Central
                    double h = 0.00001;

                    while (true)
                    {
                        double f_ci = EvaluarFuncion(funcion, ci);

                        // EL TRUCO DEFINITIVO: Derivada Numérica por DIFERENCIAS CENTRALES
                        // Esto evita que la función diverja y hace que las iteraciones cuadren
                        double f_ci_mas_h = EvaluarFuncion(funcion, ci + h);
                        double f_ci_menos_h = EvaluarFuncion(funcion, ci - h);
                        double fp_ci = (f_ci_mas_h - f_ci_menos_h) / (2.0 * h);

                        if (Math.Abs(fp_ci) < 1E-12)
                        {
                            MessageBox.Show("La derivada se hizo cero. Tangente horizontal, el método diverge.", "Error Matemático", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }

                        // Fórmula de Newton: Xi+1 = Xi - ( f(Xi) / f'(Xi) )
                        double c_nuevo = ci - (f_ci / fp_ci);

                        string eaMostrar = "-";
                        string erMostrar = "-";

                        // Calculamos el error verificando la diferencia entre el actual y el de la vuelta anterior
                        if (iteracion > 1)
                        {
                            ea = Math.Abs(ci - ci_anterior);

                            // EL * 100.0 REGRESÓ: Es vital para que la tolerancia funcione como porcentaje
                            if (ci != 0)
                            {
                                errorRelativo = Math.Abs(ea / ci) * 100.0;
                            }

                            eaMostrar = Math.Round(ea, 8).ToString();
                            erMostrar = Math.Round(errorRelativo, 8).ToString() + "%";
                        }

                        // Imprimimos la fila limpia
                        dgvIteraciones.Rows.Add(
                            iteracion,
                            Math.Round(ci, 8),
                            Math.Round(f_ci, 8),
                            Math.Round(fp_ci, 8),
                            Math.Round(c_nuevo, 8),
                            eaMostrar,
                            erMostrar
                        );

                        // FRENOS DE ÉXITO (Igual que tus compañeros)
                        if (Math.Abs(f_ci) < 1E-12 || (iteracion > 1 && errorRelativo < tolerancia))
                        {
                            lblResultado.Text = $"Resultado: {Math.Round(c_nuevo, 8)}";
                            break;
                        }

                        // Rotación de variables para la siguiente vuelta
                        ci_anterior = ci;
                        ci = c_nuevo;
                        iteracion++;

                        if (iteracion > 100)
                        {
                            MessageBox.Show("Se alcanzó el límite de 100 iteraciones sin converger. Prueba con otro valor inicial.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
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
                            errorRelativo = Math.Abs((c_mas1 - ci) / c_mas1) * 100;
                            erMostrar = Math.Round(errorRelativo, 8).ToString() + "%";
                        }

                        // Imprimimos la fila en el orden exacto de tu Excel
                        dgvIteraciones.Rows.Add(
                            iteracion,
                            Math.Round(ci, 8),
                            Math.Round(f_ci, 8),
                            Math.Round(c_menos1, 8),
                            Math.Round(f_c_menos1, 8),
                            Math.Round(c_mas1, 8),
                            Math.Round(f_c_mas1, 8),
                            erMostrar
                        );

                        // Freno: Si llegamos a la raíz exacta o si vencimos a la tolerancia
                        if (Math.Abs(f_c_mas1) < 0.0000001 || (iteracion > 1 && errorRelativo < tolerancia))
                        {
                            lblResultado.Text = $"Resultado: {Math.Round(c_mas1, 8)}";
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
                        if (iteracion > 100) break; // Límite de seguridad
                    }
                    GuardarHistorial(metodoSeleccionado, funcion);
                }
                // ==========================================
                // MÉTODO DEL PUNTO FIJO
                // ==========================================
                else if (metodoSeleccionado == "Punto Fijo")
                {
                    if (string.IsNullOrEmpty(txtFxOriginal.Text))
                    {
                        MessageBox.Show("Tiene que escribir la funcion original para poder continuar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (txtFxOriginal != null && lblFxOriginal != null && !string.IsNullOrWhiteSpace(txtFxOriginal.Text))
                    {
                        lblFxOriginal.Text = "f(x) original: " + txtFxOriginal.Text;
                        txtFxOriginal.Clear();
                    }

                    double ci = a;
                    double ci_anterior = 0;
                    double errorRelativo = 100.0;
                    int iteracion = 0;
                    double h = 0.00001;

                    // ========================================================
                    // 🛡️ ESCUDO PRE-ARRANQUE: Evaluar divergencia ANTES de iterar
                    // ========================================================
                    double g_ci_pre_mas_h = EvaluarFuncion(funcion, ci + h);
                    double g_ci_pre_menos_h = EvaluarFuncion(funcion, ci - h);
                    double gp_ci_pre = (g_ci_pre_mas_h - g_ci_pre_menos_h) / (2.0 * h);

                    if (Math.Abs(gp_ci_pre) >= 1)
                    {
                        MessageBox.Show(
                            $"¡Alerta de Divergencia!\n\nEl sistema analizó tu punto inicial y detectó que la derivada absoluta es |g'(x)| = {Math.Round(Math.Abs(gp_ci_pre), 4)}.\n\n" +
                            "Como es MAYOR o IGUAL a 1, la matemática dicta que el método va a rebotar y NUNCA encontrará la raíz (va a divergir).\n\n" +
                            "El programa detuvo el cálculo para ahorrar recursos. ¡Intenta con otro despeje de g(x) o cambia el valor inicial!",
                            "Despeje Inestable",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return; // EL FRENO DE MANO: Corta la ejecución, no arma la tabla.
                    }
                    // ========================================================

                    // Si pasó el escudo, significa que |g'(x)| < 1 y arrancamos el motor
                    while (true)
                    {
                        double g_ci = EvaluarFuncion(funcion, ci);
                        double g_ci_mas_h = EvaluarFuncion(funcion, ci + h);
                        double g_ci_menos_h = EvaluarFuncion(funcion, ci - h);
                        double gp_ci = (g_ci_mas_h - g_ci_menos_h) / (2.0 * h);

                        string erMostrar = "-";

                        if (iteracion > 0)
                        {
                            errorRelativo = Math.Abs((ci - ci_anterior) / ci) * 100.0;
                            erMostrar = Math.Round(errorRelativo, 8).ToString() + "%";
                        }

                        dgvIteraciones.Rows.Add(iteracion, Math.Round(ci, 8), Math.Round(g_ci, 8), Math.Round(gp_ci, 8), erMostrar);

                        if (iteracion > 0 && errorRelativo < tolerancia)
                        {
                            lblResultado.Text = $"Resultado: {Math.Round(ci, 8)}";
                            break;
                        }

                        ci_anterior = ci;
                        ci = g_ci;
                        iteracion++;

                        if (iteracion > 100)
                        {
                            MessageBox.Show(
                                $"El método se detuvo por límite de iteraciones.\n\n" +
                                $"La última derivada calculada en su viaje fue {Math.Round(gp_ci, 6)}.\n\n" +
                                $"EXPLICACIÓN MATEMÁTICA:\nAunque arrancaste en una zona estable, la curva cambió y generó un efecto 'pinball', haciendo que los valores rebotaran alejándose de la respuesta.",
                                "Divergencia en el camino",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
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

            if (metodo == "Otros Metodos (Polinomios)")
            {
                FormPolinomios formPolinomios = new FormPolinomios();
                formPolinomios.ShowDialog();
                cmbMetodos.SelectedIndex = 0;
                return;
            }
            else if (metodo == "Otros Metodos (Matrices)")
            {
                FormMatrices formMatrices = new FormMatrices();
                formMatrices.ShowDialog();
                cmbMetodos.SelectedIndex = 0;
                return;
            }
            else if (metodo == "Otros Metodos (Iterativos)")
            {
                FormIterativos formIterativos = new FormIterativos();
                formIterativos.ShowDialog();
                cmbMetodos.SelectedIndex = 0;
                return;
            }
            else if (metodo == "Metodos de Regresion")
            {
                FormRegresion frmRegresion = new FormRegresion();
                frmRegresion.ShowDialog();
                cmbMetodos.SelectedIndex = 0;
                return;
            }
            else if (metodo == "Metodos Interpolantes")
            {
                FormInterpolantes frmInterpolantes = new FormInterpolantes();
                frmInterpolantes.ShowDialog();
                cmbMetodos.SelectedIndex = 0;
                return;
            }
            else if (metodo == "Integracion Numerica x Aproximacion")
            {
                FormIntegracion frmIntegracion = new FormIntegracion();
                frmIntegracion.ShowDialog();
                cmbMetodos.SelectedIndex = 0;
                return;
            }
            else if (metodo == "Aproximacion de Soluciones de EDO")
            {
                FormDiferenciales frmDiferenciales = new FormDiferenciales();
                frmDiferenciales.ShowDialog();
                cmbMetodos.SelectedIndex = 0;
                return;
            }
            else if (metodo == "Diferenciacion Numerica")
            {
                FormDerivadas frmDerivadas = new FormDerivadas();
                frmDerivadas.ShowDialog();
                cmbMetodos.SelectedIndex = 0;
                return;
            }

            // Actualizamos las columnas de la tabla en vivo
            ConfigurarTabla(metodo);

            // Actualizamos los textos de Label6 y Label7
            ActualizarEtiquetas(metodo);
        }

        private void ActualizarEtiquetas(string metodo)
        {
            if (label6 == null || label7 == null || label8 == null || label2 == null) return;

            label2.Text = "Escribir Funcion f(x)";
            label8.Text = ".";
            lblFxOriginal.Visible = false;
            txtFxOriginal.Visible = false;
            label10.Visible = false;

            if (metodo == "Biseccion" || metodo == "Regla Falsa")
            {
                label6.Text = ".";
                label7.Text = ".";
                txtB.Enabled = true;
                btnCalcular.Text = "Calcular";
            }
            else if (metodo == "Newton-Raphson")
            {
                label6.Text = "Ci (Valor Inicial)";
                label7.Text = ". (No se usa)";
                txtB.Enabled = false;
                btnCalcular.Text = "Calcular Newton-Raphson";
                txtB.Clear();
            }
            else if (metodo == "Punto Fijo")
            {
                label2.Text = "Escribir Funcion g(x)";
                label8.Text = "Nota: Tienes que despejar X de la funcion f(x) para obtener g(x) y escribe g(x) para buscar su raiz ☝️";
                label6.Text = "Ci (Valor Inicial)";
                label7.Text = ". (No se usa)";
                btnCalcular.Text = "Calcular Punto Fijo";
                txtB.Enabled = false;
                lblFxOriginal.Visible = true;
                txtFxOriginal.Visible = true;
                label10.Visible = true;
                txtB.Clear();
            }
            else if (metodo == "Secante")
            {
                label6.Text = "C-1";
                label7.Text = "Ci";
                btnCalcular.Text = "Calcular Secante";
                txtB.Enabled = true;
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
                saveFileDialog.FileName = "Manual_MetodosCerradosAbiertos.txt"; // Nombre por defecto

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 3. El texto que va a llevar el bloc de notas (Cámbialo según el Form)
                    string contenido = @"==================================================
      MANUAL DE USUARIO - ECUACIONES GENERALES
==================================================
¡Bienvenido! Aquí podrás resolver ecuaciones normales de forma automática.

¿CÓMO ESCRIBIR TU ECUACIÓN?
- Usa la letra 'x' minúscula.
- Para potencias usa el símbolo '^' (Ejemplo: x^2 - 4). 
- Para funciones matemáticas escribe: sin(x), cos(x), log(x), exp(x).

MÉTODOS DISPONIBLES:
1. MÉTODOS CERRADOS (Bisección, Falsa Posición):
   - Necesitas ingresar un Límite Inferior (Xi) y un Límite Superior (Xs).
   - ¡Importante! Asegúrate de que la raíz esté en medio de esos dos números (uno debe dar resultado positivo y el otro negativo al evaluarlos).

2. MÉTODOS ABIERTOS (Newton-Raphson, Secante):
   - Newton-Raphson solo te pedirá un valor inicial (Xi). Pon un número que creas que está cerca de la respuesta.
   - Secante te pedirá dos valores iniciales, pero no tienen que encerrar la raíz obligatoriamente.

TOLERANCIA:
- Es el margen de error que permites. Entre más ceros pongas (ej: 0.0001), más preciso será el resultado, pero tardará más iteraciones.";

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

        private void txtA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',') e.KeyChar = '.';

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            // El signo negativo '-' solo se puede poner al inicio
            if (e.KeyChar == '-' && (sender as TextBox).SelectionStart != 0)
            {
                e.Handled = true;
            }
        }

        private void txtB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',') e.KeyChar = '.';

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            // El signo negativo '-' solo se puede poner al inicio
            if (e.KeyChar == '-' && (sender as TextBox).SelectionStart != 0)
            {
                e.Handled = true;
            }
        }

        private void FormPrincipal_FormClosed(object sender, FormClosedEventArgs e)
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
