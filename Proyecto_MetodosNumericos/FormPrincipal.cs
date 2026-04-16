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
            ConfigurarTabla();
        }

        private void ConfigurarTabla()
        {
            dgvIteraciones.Columns.Add("Iteracion", "Iteración");
            dgvIteraciones.Columns.Add("A", "a");
            dgvIteraciones.Columns.Add("B", "b");
            dgvIteraciones.Columns.Add("Xm", "Xm (Punto Medio)");
            dgvIteraciones.Columns.Add("FA", "f(a)");
            dgvIteraciones.Columns.Add("FXm", "f(Xm)");
            dgvIteraciones.Columns.Add("Error", "Error");
        }

        private double EvaluarFuncion(string funcion, double valorX)
        {
            try
            {
                string funcionCorregida = Regex.Replace(funcion, @"([a-zA-Z0-9_.]+)\^([a-zA-Z0-9_.-]+)", "Pow($1, $2)");

                Expression e = new Expression(funcionCorregida);
                e.Parameters["x"] = valorX;
                return Convert.ToDouble(e.Evaluate());
            }
            catch
            {
                throw new Exception("Error al evaluar la función. Revisa la sintaxis (ej. usa x * x en lugar de x^2 si da error).");
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            dgvIteraciones.Rows.Clear(); // Limpiar tabla anterior

            string funcion = txtFuncion.Text.Trim();
            string metodoSeleccionado = cmbMetodos.SelectedItem.ToString();

            if (!double.TryParse(txtA.Text, out double a) ||
                !double.TryParse(txtB.Text, out double b) ||
                !double.TryParse(txtTolerancia.Text, out double tolerancia))
            {
                MessageBox.Show("Por favor, ingresa valores numéricos válidos en a, b y Tolerancia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (metodoSeleccionado == "Biseccion")
                {
                    double fa = EvaluarFuncion(funcion, a);
                    double fb = EvaluarFuncion(funcion, b);

                    // Condición 1: f(a) * f(b) debe ser negativo
                    if (fa * fb >= 0)
                    {
                        MessageBox.Show("La función no cambia de signo en el intervalo dado. El producto de f(a) y f(b) debe ser menor a cero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int iteracion = 1;
                    double xm = 0;
                    double error = Math.Abs(b - a);

                    // Condición 2: El ciclo se repite mientras el error sea mayor a la tolerancia
                    while (error >= tolerancia)
                    {
                        xm = (a + b) / 2.0; // Punto medio exacto
                        fa = EvaluarFuncion(funcion, a);
                        double fxm = EvaluarFuncion(funcion, xm);

                        // Agregamos la fila a la tabla (interfaz visual solamente)
                        dgvIteraciones.Rows.Add(iteracion, Math.Round(a, 5), Math.Round(b, 5), Math.Round(xm, 5), Math.Round(fa, 5), Math.Round(fxm, 5), Math.Round(error, 5));

                        // Actualización de límites
                        if (fa * fxm < 0)
                        {
                            b = xm; // La raíz está a la izquierda
                        }
                        else
                        {
                            a = xm; // La raíz está a la derecha
                        }

                        error = Math.Abs(b - a);
                        iteracion++;

                        // Medida de seguridad por si ponen una tolerancia irreal y se hace un bucle infinito
                        if (iteracion > 100) break;
                    }

                    lblResultado.Text = $"Resultado: La raíz aproximada es {Math.Round(xm, 6)}";

                    // Guardamos el historial de la operación en SQL Server
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
