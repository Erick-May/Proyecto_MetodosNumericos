using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Numerics;
using System.IO;

namespace Proyecto_MetodosNumericos
{
    public partial class FormPolinomios : Form
    {
        private List<TextBox> cajasCoeficientes = new List<TextBox>();
        public FormPolinomios()
        {
            InitializeComponent();

            if (cmbMetodosPolinomio.Items.Count == 0)
            {
                cmbMetodosPolinomio.Items.Add("Bairstow");
                cmbMetodosPolinomio.Items.Add("Muller");
                cmbMetodosPolinomio.Items.Add("Horner-Newton");
            }
            cmbMetodosPolinomio.SelectedIndex = 0;
            cmbMetodosPolinomio.SelectedIndexChanged += cmbMetodosPolinomio_SelectedIndexChanged;
            ActualizarInterfaz();
        }

        private void ActualizarInterfaz()
        {
            string metodo = cmbMetodosPolinomio.SelectedItem?.ToString() ?? "";

            if (metodo == "Bairstow")
            {
                // Mostramos lo de Bairstow
                txtR.Visible = true; txtS.Visible = true;
                label4.Visible = true; label5.Visible = true; // Labels de r0 y s0
                label7.Visible = false; label8.Visible = false; label9.Visible = false; // Labels de x0, x1, x2

                // Ocultamos lo de Muller
                txtX0.Visible = false; txtX1.Visible = false; txtX2.Visible = false;
            }
            else if (metodo == "Muller")
            {
                // Ocultamos lo de Bairstow
                txtR.Visible = false; txtS.Visible = false;
                label4.Visible = false; label5.Visible = false;

                // Mostramos lo de Muller
                txtX0.Visible = true; txtX1.Visible = true; txtX2.Visible = true;
                label7.Visible = true; label8.Visible = true; label9.Visible = true; // Labels de x0, x1, x2
            }
        }

        // ==========================================
        // HELPERS MATEMÁTICOS PARA POLINOMIOS
        // ==========================================
        private Complex EvaluarPolinomio(double[] a, Complex x)
        {
            Complex resultado = 0;
            int grado = a.Length - 1;
            for (int i = 0; i <= grado; i++)
            {
                // CORRECCIÓN MATEMÁTICA: El índice 'i' coincide exactamente con la potencia
                resultado += a[i] * Complex.Pow(x, i);
            }
            return resultado;
        }

        private string FormatearValor(double valor)
        {
            // Limpiamos la "basura" de precisión de la CPU para igualar el motor de Excel
            if (Math.Abs(valor) < 1E-14) return "0";

            // G10 le dice a C# que use hasta 10 dígitos y que cambie a 
            // notación científica (ej. 3.69E-11) automáticamente si el número es muy pequeño
            return valor.ToString("G10");
        }

        private string FormatearComplejo(Complex c)
        {
            // Si la parte imaginaria es prácticamente cero, mostramos solo la real
            if (Math.Abs(c.Imaginary) < 1E-10)
                return FormatearValor(c.Real);

            string signo = c.Imaginary >= 0 ? "+" : "-";
            return $"{FormatearValor(c.Real)} {signo} {FormatearValor(Math.Abs(c.Imaginary))}i";
        }

        private void btnCalcularBairstow_Click(object sender, EventArgs e)
        {
            try
            {
                double tolerancia = Convert.ToDouble(txtToleranciaP.Text);
                string metodo = cmbMetodosPolinomio.SelectedItem.ToString();

                dgvBairstow.Columns.Clear();
                dgvBairstow.Rows.Clear();

                // --------------------------------------------------------
                // MÉTODO DE BAIRSTOW
                // --------------------------------------------------------
                if (metodo == "Bairstow")
                {
                    string[] partes = txtCoeficientes.Text.Split(',');
                    int grado = partes.Length - 1;

                    if (grado < 2)
                    {
                        MessageBox.Show("El polinomio debe ser de al menos grado 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    double[] a = new double[grado + 1];
                    for (int i = 0; i <= grado; i++) a[grado - i] = Convert.ToDouble(partes[i].Trim());

                    double r = Convert.ToDouble(txtR.Text);
                    double s = Convert.ToDouble(txtS.Text);

                    dgvBairstow.Columns.Add("Iteracion", "Iter");
                    for (int i = grado; i >= 0; i--) dgvBairstow.Columns.Add($"b{i}", $"b{i}");
                    for (int i = grado; i >= 1; i--) dgvBairstow.Columns.Add($"c{i}", $"c{i}");
                    dgvBairstow.Columns.Add("Dr", "Δr"); dgvBairstow.Columns.Add("Ds", "Δs");
                    dgvBairstow.Columns.Add("r_nuevo", "r"); dgvBairstow.Columns.Add("s_nuevo", "s");
                    dgvBairstow.Columns.Add("Er_r", "Error_r%"); dgvBairstow.Columns.Add("Er_s", "Error_s%");
                    dgvBairstow.Columns.Add("X1", "X1"); dgvBairstow.Columns.Add("X2", "X2");

                    int iteracion = 0;
                    double[] b = new double[grado + 1];
                    double[] c = new double[grado + 1];

                    while (true)
                    {
                        b[grado] = a[grado];
                        b[grado - 1] = a[grado - 1] + r * b[grado];
                        for (int i = grado - 2; i >= 0; i--) b[i] = a[i] + r * b[i + 1] + s * b[i + 2];

                        c[grado] = b[grado];
                        c[grado - 1] = b[grado - 1] + r * c[grado];
                        for (int i = grado - 2; i >= 1; i--) c[i] = b[i] + r * c[i + 1] + s * c[i + 2];

                        double D = (c[2] * c[2]) - (c[1] * c[3]);
                        double delta_r = (b[0] * c[3] - b[1] * c[2]) / D;
                        double delta_s = (b[1] * c[1] - b[0] * c[2]) / D;

                        r += delta_r; s += delta_s;

                        // CÁLCULO PURO: Removido el Math.Round para que dé los 23 mil millones igual que Excel
                        double error_r = (r != 0) ? Math.Abs(delta_r / r) * 100.0 : 0;
                        double error_s = (s != 0) ? Math.Abs(delta_s / s) * 100.0 : 0;

                        double discriminante = (r * r) + (4 * s);
                        string x1 = "", x2 = "";

                        if (discriminante >= 0)
                        {
                            x1 = Math.Round((r + Math.Sqrt(discriminante)) / 2.0, 8).ToString();
                            x2 = Math.Round((r - Math.Sqrt(discriminante)) / 2.0, 8).ToString();
                        }
                        else
                        {
                            double pReal = Math.Round(r / 2.0, 8);
                            double pImag = Math.Round(Math.Sqrt(-discriminante) / 2.0, 8);
                            x1 = $"{pReal} + {pImag}i"; x2 = $"{pReal} - {pImag}i";
                        }

                        List<object> fila = new List<object> { iteracion };
                        for (int i = grado; i >= 0; i--) fila.Add(Math.Round(b[i], 8));
                        for (int i = grado; i >= 1; i--) fila.Add(Math.Round(c[i], 8));
                        fila.Add(Math.Round(delta_r, 8)); fila.Add(Math.Round(delta_s, 8));
                        fila.Add(Math.Round(r, 8)); fila.Add(Math.Round(s, 8));

                        // FORMATO DE CEROS: Usamos "0.########" para destruir la notación científica (la "E")
                        fila.Add(iteracion == 0 ? "-" : error_r.ToString("0.########"));
                        fila.Add(iteracion == 0 ? "-" : error_s.ToString("0.########"));

                        fila.Add(x1); fila.Add(x2);

                        dgvBairstow.Rows.Add(fila.ToArray());

                        if (iteracion > 0 && error_r < tolerancia && error_s < tolerancia) break;
                        iteracion++;
                        if (iteracion > 100) break;
                    }
                }
                // --------------------------------------------------------
                // MÉTODO DE MULLER
                // --------------------------------------------------------
                else if (metodo == "Muller")
                {
                    string[] partes = txtCoeficientes.Text.Split(',');
                    int grado = partes.Length - 1;

                    if (grado < 2)
                    {
                        MessageBox.Show("El polinomio debe ser de al menos grado 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    double[] a = new double[grado + 1];
                    for (int i = 0; i <= grado; i++) a[grado - i] = Convert.ToDouble(partes[i].Trim());

                    dgvBairstow.Columns.Add("Iteracion", "i");
                    dgvBairstow.Columns.Add("Xi", "Xi");
                    dgvBairstow.Columns.Add("Xi_1", "Xi+1");
                    dgvBairstow.Columns.Add("hi", "hi");
                    dgvBairstow.Columns.Add("hi_1", "hi+1");
                    dgvBairstow.Columns.Add("fXi", "f(Xi)");
                    dgvBairstow.Columns.Add("fXi_1", "f(Xi+1)");
                    dgvBairstow.Columns.Add("di", "δi");
                    dgvBairstow.Columns.Add("di_1", "δi+1");
                    dgvBairstow.Columns.Add("a", "a");
                    dgvBairstow.Columns.Add("b", "b");
                    dgvBairstow.Columns.Add("c", "c");
                    dgvBairstow.Columns.Add("Col1", "Raiz +");
                    dgvBairstow.Columns.Add("Col2", "Raiz -");
                    dgvBairstow.Columns.Add("Er", "Error %");
                    dgvBairstow.Columns.Add("Continuar", "Continuar");

                    Complex x0 = Convert.ToDouble(txtX0.Text);
                    Complex x1 = Convert.ToDouble(txtX1.Text);
                    Complex x2 = Convert.ToDouble(txtX2.Text);

                    int iteracion = 0;
                    double errorRelativo = 100.0;
                    Complex x0_anterior = x0;

                    while (true)
                    {
                        Complex h0 = x1 - x0;
                        Complex h1 = x2 - x1;

                        Complex fx0 = EvaluarPolinomio(a, x0);
                        Complex fx1 = EvaluarPolinomio(a, x1);
                        Complex fx2 = EvaluarPolinomio(a, x2);

                        // ==========================================
                        // MAGIA: Limpiador de punto flotante
                        // Si la función está peligrosamente cerca de 0, la forzamos a 0 
                        // para evitar que divida basura y genere resultados como tu "24"
                        // ==========================================
                        if (Complex.Abs(fx0) < 1E-12) fx0 = 0;
                        if (Complex.Abs(fx1) < 1E-12) fx1 = 0;
                        if (Complex.Abs(fx2) < 1E-12) fx2 = 0;

                        // Validamos que h no sea cero absoluto para evitar división entre cero
                        Complex d0 = h0 != 0 ? (fx1 - fx0) / h0 : 0;
                        Complex d1 = h1 != 0 ? (fx2 - fx1) / h1 : 0;

                        Complex a_m = (h1 + h0) != 0 ? (d1 - d0) / (h1 + h0) : 0;
                        Complex b_m = (a_m * h1) + d1;
                        Complex c_m = fx2;

                        Complex raiz = Complex.Sqrt((b_m * b_m) - (4.0 * a_m * c_m));

                        Complex col1 = b_m + raiz;
                        Complex col2 = b_m - raiz;

                        Complex denom = (Complex.Abs(col1) > Complex.Abs(col2)) ? col1 : col2;

                        Complex x3 = x2;
                        if (denom != 0)
                        {
                            x3 = x2 - ((2.0 * c_m) / denom);
                        }

                        if (Math.Abs(x3.Imaginary) < 0.00001)
                        {
                            x3 = new Complex(x3.Real, 0);
                        }

                        string erMostrar = "-";
                        string continuar = "-";

                        if (iteracion > 0)
                        {
                            // Error desfasado igual al de tu Excel
                            errorRelativo = Math.Abs(((x0 - x0_anterior) / x0).Real) * 100.0;

                            // Usamos el nuevo formato que respeta la notación científica
                            erMostrar = FormatearValor(errorRelativo);

                            if (errorRelativo < tolerancia)
                                continuar = "Finalizar";
                            else
                                continuar = "Continuar";
                        }

                        dgvBairstow.Rows.Add(
                            iteracion,
                            FormatearComplejo(x0),
                            FormatearComplejo(x1),
                            FormatearComplejo(h0),
                            FormatearComplejo(h1),
                            FormatearComplejo(fx0),
                            FormatearComplejo(fx1),
                            FormatearComplejo(d0),
                            FormatearComplejo(d1),
                            FormatearComplejo(a_m),
                            FormatearComplejo(b_m),
                            FormatearComplejo(c_m),
                            FormatearComplejo(col1),
                            FormatearComplejo(col2),
                            erMostrar,
                            continuar
                        );

                        // Freno si el error ya cumplió la meta de Excel
                        if (iteracion > 0 && errorRelativo < tolerancia) break;

                        // Rotación de puntos
                        x0_anterior = x0;
                        x0 = x1;
                        x1 = x2;
                        x2 = x3;

                        iteracion++;
                        if (iteracion > 100) break;
                    }
                }
                // --------------------------------------------------------
                // MÉTODO DE HORNER-NEWTON
                // --------------------------------------------------------
                else if (metodo == "Horner-Newton")
                {
                    if (cajasCoeficientes.Count == 0)
                    {
                        MessageBox.Show("Genera las cajas y llena los coeficientes primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int gradoN = cajasCoeficientes.Count - 1;
                    double[] A = new double[gradoN + 1];

                    // Leer los coeficientes (caja 0 es a_n, caja 'gradoN' es a_0)
                    for (int i = 0; i <= gradoN; i++)
                    {
                        // CORRECCIÓN 1: 'A' mayúscula
                        if (!double.TryParse(cajasCoeficientes[i].Text, out A[gradoN - i]))
                        {
                            MessageBox.Show("Verifica que todos los coeficientes sean numéricos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    double xi = Convert.ToDouble(txtX0.Text);

                    // Configurar columnas dinámicas
                    dgvBairstow.Columns.Add("Iteracion", "i");
                    dgvBairstow.Columns.Add("Xi", "Xi");

                    for (int i = gradoN; i >= 0; i--) dgvBairstow.Columns.Add($"b{i}", $"b{i}");
                    for (int i = gradoN - 1; i >= 0; i--) dgvBairstow.Columns.Add($"c{i}", $"c{i}");

                    dgvBairstow.Columns.Add("fXi", "f(Xi)");
                    dgvBairstow.Columns.Add("fpXi", "f'(Xi)");
                    dgvBairstow.Columns.Add("Xi_1", "Xi+1");
                    dgvBairstow.Columns.Add("Er", "Error %");

                    double[] b = new double[gradoN + 1];
                    double[] c = new double[gradoN];

                    int iteracion = 0;
                    double errorRelativo = 100.0;

                    while (true)
                    {
                        // 1ra División Sintética: Polinomio
                        // CORRECCIÓN 2: 'A' mayúscula
                        b[gradoN] = A[gradoN];
                        for (int i = gradoN - 1; i >= 0; i--)
                        {
                            // CORRECCIÓN 3: 'A' mayúscula
                            b[i] = A[i] + (xi * b[i + 1]);
                        }

                        // 2da División Sintética: Derivada
                        c[gradoN - 1] = b[gradoN];
                        for (int i = gradoN - 2; i >= 0; i--)
                        {
                            c[i] = b[i + 1] + (xi * c[i + 1]);
                        }

                        double f_xi = b[0];       // f(x)
                        double fp_xi = c[0];      // f'(x)

                        if (Math.Abs(fp_xi) < 1E-15)
                        {
                            MessageBox.Show("La derivada se hizo cero. Tangente horizontal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }

                        double xi_1 = xi - (f_xi / fp_xi);

                        string erMostrar = "-";
                        if (iteracion > 0)
                        {
                            errorRelativo = Math.Abs((xi_1 - xi) / xi_1) * 100.0;
                            // Ojo: Si no agregaste el método FormatearValor, puedes usar Math.Round(errorRelativo, 6)
                            erMostrar = Math.Round(errorRelativo, 6).ToString() + "%";
                        }

                        // Llenar Fila
                        List<object> fila = new List<object> { iteracion, Math.Round(xi, 6) };
                        for (int i = gradoN; i >= 0; i--) fila.Add(Math.Round(b[i], 6));
                        for (int i = gradoN - 1; i >= 0; i--) fila.Add(Math.Round(c[i], 6));

                        fila.Add(Math.Round(f_xi, 6));
                        fila.Add(Math.Round(fp_xi, 6));
                        fila.Add(Math.Round(xi_1, 6));
                        fila.Add(erMostrar);

                        dgvBairstow.Rows.Add(fila.ToArray());

                        if (iteracion > 0 && errorRelativo < tolerancia) break;

                        xi = xi_1;
                        iteracion++;
                        if (iteracion > 100) break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Revisa los coeficientes y variables iniciales. Error: " + ex.Message, "Error Matemático", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbMetodosPolinomio_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarInterfaz();
            dgvBairstow.Columns.Clear();
            ActualizarEtiquetas(cmbMetodosPolinomio.SelectedItem?.ToString() ?? "");
        }

        private void ActualizarEtiquetas(string metodo)
        {
            // Ocultar TODO por defecto
            txtR.Visible = false; txtS.Visible = false;
            label4.Visible = false; label5.Visible = false;
            txtX0.Visible = false; txtX1.Visible = false; txtX2.Visible = false;
            label7.Visible = false; label8.Visible = false; label9.Visible = false;
            txtCoeficientes.Visible = false; label2.Visible = false; label3.Visible = false;

            // Ocultar lo nuevo de Horner-Newton
            lblGradoHN.Visible = false; txtGradoHN.Visible = false;
            btnGenerarCajas.Visible = false; flpCoeficientes.Visible = false;

            if (metodo == "Bairstow")
            {
                txtCoeficientes.Visible = true; label2.Visible = true; label3.Visible = true;
                txtR.Visible = true; txtS.Visible = true;
                label4.Visible = true; label5.Visible = true;
                label1.Text = "METODO DE BAIRSTOW";
            }
            else if (metodo == "Muller")
            {
                txtCoeficientes.Visible = true; label2.Visible = true; label3.Visible = true;
                txtX0.Visible = true; txtX1.Visible = true; txtX2.Visible = true;
                label7.Text = "X0"; label7.Visible = true;
                label8.Text = "X1"; label8.Visible = true;
                label9.Text = "X2"; label9.Visible = true;
                label1.Text = "METODO DE MULLER";
            }
            else if (metodo == "Horner-Newton")
            {
                // Mostrar Horner y el X0
                lblGradoHN.Visible = true; txtGradoHN.Visible = true;
                btnGenerarCajas.Visible = true; flpCoeficientes.Visible = true;

                txtX0.Visible = true;
                label7.Text = "X0"; label7.Visible = true;
                label1.Text = "METODO DE HORNER-NEWTON";
            }
        }
        private void btnGenerarCajas_Click(object sender, EventArgs e)
        {
            // Limpiamos el contenedor por si el usuario cambia el grado y vuelve a darle clic
            flpCoeficientes.Controls.Clear();
            cajasCoeficientes.Clear();

            if (int.TryParse(txtGradoHN.Text, out int grado) && grado > 0)
            {
                // Generamos desde a_n hasta a_0 y las metemos en tu FlowLayoutPanel
                for (int i = grado; i >= 0; i--)
                {
                    Panel p = new Panel { Size = new Size(50, 50), Margin = new Padding(3) };
                    Label l = new Label { Text = $"a{i}", Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleCenter };
                    TextBox t = new TextBox { Dock = DockStyle.Bottom, Width = 40, TextAlign = HorizontalAlignment.Center };

                    p.Controls.Add(l);
                    p.Controls.Add(t);
                    flpCoeficientes.Controls.Add(p);

                    cajasCoeficientes.Add(t); // Guardamos la cajita para leerla después
                }
            }
            else
            {
                MessageBox.Show("Ingresa un grado válido (entero mayor a 0).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                saveFileDialog.FileName = "Manual_Polinomios.txt"; // Nombre por defecto

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 3. El texto que va a llevar el bloc de notas (Cámbialo según el Form)
                    string contenido = @"==================================================
        MANUAL DE USUARIO - MÉTODOS DE POLINOMIOS
==================================================
¡Bienvenido! Este programa te ayuda a encontrar las raíces (soluciones) de polinomios sin que tengas que hacer los cálculos a mano. No necesitas ser un experto en matemáticas para usarlo.

1. MÉTODO DE BAIRSTOW:
   - Útil para encontrar raíces reales y complejas.
   - En 'Coeficientes', escribe los números de tu polinomio separados por comas. 
     (Ejemplo: Si tu polinomio es 1x^3 - 2x^2 + 3, debes escribir: 1, -2, 0, 3).
     *Nota: Si falta una 'x', ponle un 0. El grado debe ser 2 o mayor.
   - Ingresa los valores iniciales 'r' y 's' (puedes probar con 1 y 1 si no sabes cuáles poner).
   - Pon la tolerancia (ej: 0.01) y presiona Calcular.

2. MÉTODO DE MULLER:
   - Escribe los coeficientes separados por comas, igual que en Bairstow.
   - Este método necesita 3 puntos de inicio (X0, X1, X2). Escribe tres números que estén cerca de donde crees que la gráfica cruza el cero (ejemplo: -1.5, -1.45, -1.4).

3. MÉTODO DE HORNER-NEWTON:
   - Selecciona el 'Grado' de tu polinomio (ej: 3 si empieza con x^3) y haz clic en 'Generar Cajas'.
   - Aparecerán cajitas para que pongas el número que acompaña a cada 'x'.
   - Ingresa un solo valor inicial (X0) y tu tolerancia.

¡Listo! El programa hará todas las iteraciones y se detendrá cuando el error sea menor a tu tolerancia.";

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

        private void txtToleranciaP_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtR_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtX0_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtS_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtX1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtX2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void FormPolinomios_Load(object sender, EventArgs e)
        {

        }
    }
}
