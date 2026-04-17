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
                dgvIteraciones.Columns.Add("Error", "Error Absoluto");
            }
            else if (metodo == "Regla Falsa")
            {
                // Estructura exacta de tu Excel
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
        }

        private double EvaluarFuncion(string funcion, double valorX)
        {
            try
            {
                // 1. Arreglamos las potencias (x^2 -> Pow(x, 2))
                string funcionCorregida = Regex.Replace(funcion, @"([a-zA-Z0-9_.]+)\^([a-zA-Z0-9_.-]+)", "Pow($1, $2)");

                // Borramos el Regex.Replace del "ln"
                Expression e = new Expression(funcionCorregida);
                e.Parameters["x"] = valorX;

                // 2. Le enseñamos a NCalc qué hacer cuando lea "ln"
                e.EvaluateFunction += delegate (string name, FunctionArgs args)
                {
                    if (name.ToLower() == "ln")
                    {
                        // Evaluamos el valor de x que está dentro del paréntesis
                        double numero = Convert.ToDouble(args.Parameters[0].Evaluate());

                        // Math.Log en C# calcula directamente el logaritmo natural (base e)
                        args.Result = Math.Log(numero);

                        // ¡Importante! Le avisamos a NCalc que sí pudimos resolverlo
                        args.HasResult = true;
                    }
                };

                return Convert.ToDouble(e.Evaluate());
            }
            catch (Exception ex)
            {
                // Mejoramos el mensaje de error para que si te equivocas de sintaxis, 
                // te diga exactamente qué parte falló en lugar de un mensaje genérico.
                throw new Exception("Error al evaluar la función: " + ex.Message);
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            string funcion = txtFuncion.Text.Trim();
            string metodoSeleccionado = cmbMetodos.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(metodoSeleccionado))
            {
                MessageBox.Show("Por favor, selecciona un método.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Configuramos las columnas de la tabla antes de empezar
            ConfigurarTabla(metodoSeleccionado);
            dgvIteraciones.Rows.Clear(); // Limpiamos datos anteriores
            lblResultado.Text = "Resultado: ";

            if (!double.TryParse(txtA.Text, out double a) ||
                !double.TryParse(txtB.Text, out double b) ||
                !double.TryParse(txtTolerancia.Text, out double tolerancia))
            {
                MessageBox.Show("Por favor, ingresa valores numéricos válidos en a, b y Tolerancia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // METODO DE BISECCIÓN
                if (metodoSeleccionado == "Biseccion")
                {
                    double fa = EvaluarFuncion(funcion, a);
                    double fb = EvaluarFuncion(funcion, b);

                    if (fa * fb >= 0)
                    {
                        MessageBox.Show("La función no cambia de signo en el intervalo dado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int iteracion = 1;
                    double xm = 0;
                    double error = Math.Abs(b - a);

                    while (error >= tolerancia)
                    {
                        xm = (a + b) / 2.0;
                        fa = EvaluarFuncion(funcion, a);
                        double fxm = EvaluarFuncion(funcion, xm);

                        dgvIteraciones.Rows.Add(iteracion, Math.Round(a, 5), Math.Round(b, 5), Math.Round(xm, 5), Math.Round(fa, 5), Math.Round(fxm, 5), Math.Round(error, 5));

                        if (fa * fxm < 0) b = xm;
                        else a = xm;

                        error = Math.Abs(b - a);
                        iteracion++;
                        if (iteracion > 100) break;
                    }

                    lblResultado.Text = $"Resultado: La raíz aproximada es {Math.Round(xm, 6)}";
                    GuardarHistorial(metodoSeleccionado, funcion);
                }

                // METODO DE REGLA FALSA
                else if (metodoSeleccionado == "Regla Falsa")
                {
                    double fa = EvaluarFuncion(funcion, a);
                    double fb = EvaluarFuncion(funcion, b);

                    if (fa * fb >= 0)
                    {
                        MessageBox.Show("La función no cambia de signo en el intervalo dado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int iteracion = 1;
                    double c = 0;
                    double c_anterior = 0;
                    double errorRelativo = 100.0; // Lo iniciamos alto para que entre al while

                    while (true)
                    {
                        fa = EvaluarFuncion(funcion, a);
                        fb = EvaluarFuncion(funcion, b);

                        // Fórmula matemática de la Regla Falsa
                        c = b - ((fb * (a - b)) / (fa - fb));

                        double fc = EvaluarFuncion(funcion, c);
                        double productoSignos = fa * fc;

                        string errorMostrar = ""; // La iteración 1 no tiene error relativo aún

                        if (iteracion > 1)
                        {
                            // Fórmula de tu Excel: ABS((G7-G6)/G7) * 100
                            errorRelativo = Math.Abs((c - c_anterior) / c) * 100.0;
                            errorMostrar = Math.Round(errorRelativo, 2).ToString() + "%";
                        }

                        // Agregamos la fila a la tabla imitando tu Excel
                        dgvIteraciones.Rows.Add(
                            iteracion,
                            Math.Round(a, 8),
                            Math.Round(b, 8),
                            Math.Round(fa, 8),
                            Math.Round(fb, 8),
                            Math.Round(c, 8),
                            Math.Round(fc, 8),
                            Math.Round(productoSignos, 8),
                            errorMostrar
                        );

                        // Criterios de parada
                        // Si f(c) es prácticamente 0, o si el error es menor a la tolerancia
                        if (Math.Abs(fc) < 0.0000001 || (iteracion > 1 && errorRelativo < tolerancia))
                        {
                            break;
                        }

                        // Actualización de límites
                        if (productoSignos < 0)
                        {
                            b = c;
                        }
                        else
                        {
                            a = c;
                        }

                        c_anterior = c; // Guardamos el valor para calcular el error en la siguiente vuelta
                        iteracion++;

                        if (iteracion > 100) break; // Límite de seguridad
                    }

                    lblResultado.Text = $"Resultado: La raíz aproximada es {Math.Round(c, 6)}";
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
                MessageBox.Show("Se calculó bien, pero hubo un error al guardar en el historial: " + ex.Message);
            }
        }
    }
}
