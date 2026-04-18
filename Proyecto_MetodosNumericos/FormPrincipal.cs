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
                // Estructura exacta de tu Excel de Newton
                dgvIteraciones.Columns.Add("Iteracion", "iteración");
                dgvIteraciones.Columns.Add("Ci", "ci");
                dgvIteraciones.Columns.Add("FCi", "f(ci)");
                dgvIteraciones.Columns.Add("FpCi", "f'(ci) Numérica"); // Aclaramos que la hace la máquina
                dgvIteraciones.Columns.Add("Ci_1", "CI + 1");
                dgvIteraciones.Columns.Add("Ea", "Ea");
                dgvIteraciones.Columns.Add("Er", "Er%");
            }
        }

        private double EvaluarFuncion(string funcion, double valorX)
        {
            try
            {
                // 1. Arreglamos las potencias que tienen paréntesis en el exponente (Ej: e^(2*x) -> Pow(e, 2*x))
                string funcionCorregida = Regex.Replace(funcion, @"([a-zA-Z0-9_.]+)\^\(([^)]+)\)", "Pow($1, $2)");

                // 2. Arreglamos las potencias simples sin paréntesis (Ej: x^2 -> Pow(x, 2))
                funcionCorregida = Regex.Replace(funcionCorregida, @"([a-zA-Z0-9_.]+)\^([a-zA-Z0-9_.]+)", "Pow($1, $2)");

                Expression e = new Expression(funcionCorregida);

                // 3. Parámetros principales
                e.Parameters["x"] = valorX;
                e.Parameters["e"] = Math.E; // ¡MAGIA! Ahora el programa entiende cuánto vale 'e' (2.71828...)

                // 4. Le enseñamos a NCalc qué hacer cuando lea "ln"
                e.EvaluateFunction += delegate (string name, FunctionArgs args)
                {
                    if (name.ToLower() == "ln")
                    {
                        double numero = Convert.ToDouble(args.Parameters[0].Evaluate());
                        args.Result = Math.Log(numero);
                        args.HasResult = true;
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

            // Newton usa solo "A" como valor inicial. Si es otro método, exigimos "B"
            double b_val = 0;
            if (metodoSeleccionado != "Newton-Raphson" && !double.TryParse(txtB.Text, out b_val))
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
                // LÓGICA PARA BISECCIÓN (FRENO ARREGLADO)
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

                        dgvIteraciones.Rows.Add(iteracion, Math.Round(a, 5), Math.Round(b, 5), Math.Round(xm, 5), Math.Round(fa, 5), Math.Round(fxm, 5), Math.Round(errorAbsoluto, 5), erMostrar);

                        // FRENO EXACTO: Error relativo < Tolerancia
                        if (Math.Abs(fxm) < 0.0000001 || (iteracion > 1 && errorRelativo < tolerancia)) break;

                        if (fa * fxm < 0) b = xm;
                        else a = xm;

                        xm_anterior = xm;
                        iteracion++;
                        if (iteracion > 100) break;
                    }
                    lblResultado.Text = $"Resultado: {Math.Round(xm, 6)}";
                    GuardarHistorial(metodoSeleccionado, funcion);
                }

                // ==========================================
                // LÓGICA PARA REGLA FALSA
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
                    lblResultado.Text = $"Resultado: {Math.Round(c, 6)}";
                    GuardarHistorial(metodoSeleccionado, funcion);
                }

                // ==========================================
                // LÓGICA PARA NEWTON-RAPHSON (MÁGICO)
                // ==========================================
                else if (metodoSeleccionado == "Newton-Raphson")
                {
                    double ci = a; // Usamos el cuadro "A" como el valor inicial (CI)
                    double ci_anterior = 0;
                    double errorRelativo = 100.0;
                    int iteracion = 0; // Tu Excel inicia en 0

                    // Diferencial minúsculo para calcular la derivada automáticamente
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
                            erMostrar = Math.Round(errorRelativo, 2).ToString() + "%";
                        }

                        dgvIteraciones.Rows.Add(iteracion, Math.Round(ci, 5), Math.Round(f_ci, 5), Math.Round(fp_ci, 5), Math.Round(c_nuevo, 5), eaMostrar, erMostrar);

                        // Freno: Si llegamos a la tolerancia, salimos del ciclo
                        if (Math.Abs(f_ci) < 0.0000001 || (iteracion > 0 && errorRelativo < tolerancia))
                        {
                            lblResultado.Text = $"Resultado: {Math.Round(c_nuevo, 6)}";
                            break;
                        }

                        ci_anterior = ci;
                        ci = c_nuevo;
                        iteracion++;
                        if (iteracion > 100) break;
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
    }
}
