using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_MetodosNumericos.Models
{
    public class NewtonDiferenciasDivididas
    {
        /// <summary>
        /// 1. CÁLCULO DE COEFICIENTES
        /// Genera la tabla de diferencias divididas y retorna la primera fila (los coeficientes b0, b1, ... bn)
        /// </summary>
        public double[] CalcularCoeficientes(double[] X, double[] Y)
        {
            int n = X.Length;
            // Usamos una matriz para construir la tabla de diferencias
            double[,] F = new double[n, n];

            // La primera columna son simplemente los valores de Y, es decir, f(x_i)
            for (int i = 0; i < n; i++)
            {
                F[i, 0] = Y[i];
            }

            // Llenamos el resto de la matriz usando la fórmula recursiva de diferencias divididas
            for (int j = 1; j < n; j++)
            {
                for (int i = 0; i < n - j; i++)
                {
                    // f[x_i, ..., x_i+j] = (f[x_i+1, ..., x_i+j] - f[x_i, ..., x_i+j-1]) / (x_i+j - x_i)
                    F[i, j] = (F[i + 1, j - 1] - F[i, j - 1]) / (X[i + j] - X[i]);
                }
            }

            // Los coeficientes principales son la primera fila de la matriz (la diagonal superior)
            double[] coeficientes = new double[n];
            for (int j = 0; j < n; j++)
            {
                coeficientes[j] = F[0, j];
            }

            return coeficientes;
        }

        /// <summary>
        /// 2. EVALUACIÓN (INTERPOLACIÓN)
        /// Evalúa el polinomio de Newton en un punto x específico
        /// </summary>
        public double Evaluar(double[] coeficientes, double[] X, double xInterpolar)
        {
            int n = coeficientes.Length;
            double resultado = coeficientes[0];
            double producto = 1.0;

            // Evaluamos usando P(x) = b0 + b1(x-x0) + b2(x-x0)(x-x1) + ...
            for (int i = 1; i < n; i++)
            {
                producto *= (xInterpolar - X[i - 1]);
                resultado += coeficientes[i] * producto;
            }

            return resultado;
        }

        /// <summary>
        /// 3. CONSTRUCCIÓN DEL POLINOMIO (EXPANSIÓN SIMBÓLICA)
        /// Expande y simplifica (x-x0)(x-x1)... multiplicándolo por sus coeficientes
        /// </summary>
        public string ObtenerPolinomioExpandido(double[] coeficientes, double[] X)
        {
            int n = coeficientes.Length;

            // Este arreglo guardará los coeficientes finales del polinomio expandido.
            // El índice representa el grado de X. Ej: polinomioFinal[2] es el coeficiente de x^2.
            double[] polinomioFinal = new double[n];

            // Agregamos el b0 que es independiente
            polinomioFinal[0] = coeficientes[0];

            // "terminoBase" representará las multiplicaciones acumuladas: (x-x0)(x-x1)...
            // Iniciamos con el equivalente a "1" (polinomio de grado 0)
            double[] terminoBase = new double[1] { 1.0 };

            for (int i = 1; i < n; i++)
            {
                // Multiplicamos el término base acumulado por el siguiente binomio: (x - X[i-1])
                terminoBase = MultiplicarPolinomioPorBinomio(terminoBase, X[i - 1]);

                // Multiplicamos ese resultado expandido por su coeficiente correspondiente (b_i)
                // y lo sumamos al polinomio final para agrupar términos semejantes
                for (int j = 0; j < terminoBase.Length; j++)
                {
                    polinomioFinal[j] += coeficientes[i] * terminoBase[j];
                }
            }

            return FormatearPolinomioAString(polinomioFinal);
        }

        // ==========================================
        // HELPERS MATEMÁTICOS INTERNOS
        // ==========================================

        /// <summary>
        /// Simula la multiplicación de un polinomio P(x) por un binomio (x - c).
        /// </summary>
        private double[] MultiplicarPolinomioPorBinomio(double[] P, double c)
        {
            // El nuevo polinomio tendrá un grado mayor, por lo que el arreglo crece en 1
            double[] R = new double[P.Length + 1];

            for (int i = 0; i < R.Length; i++)
            {
                // Si multiplicamos P(x) * x, todos los grados suben 1 nivel (desplazamiento a la derecha)
                double term1 = (i > 0) ? P[i - 1] : 0.0;

                // Si multiplicamos P(x) * (-c), los grados se mantienen igual, solo se multiplican
                double term2 = (i < P.Length) ? -c * P[i] : 0.0;

                // Sumamos ambos términos para reducir términos semejantes
                R[i] = term1 + term2;
            }

            return R;
        }

        /// <summary>
        /// Traduce el arreglo de coeficientes finales a un string matemático legible.
        /// </summary>
        private string FormatearPolinomioAString(double[] polinomioFinal)
        {
            string ecuacion = "";

            // Recorremos desde el grado más alto (el final del arreglo) hacia el grado 0
            for (int i = polinomioFinal.Length - 1; i >= 0; i--)
            {
                // Redondeamos para eliminar "basura" de punto flotante de la CPU (ej. 0.00000000000004)
                double coef = Math.Round(polinomioFinal[i], 6);

                if (Math.Abs(coef) < 1E-10) continue; // Omitimos términos que se hicieron cero

                // Manejo de signos para que se vea limpio
                if (coef > 0 && ecuacion != "") ecuacion += " + ";
                if (coef < 0 && ecuacion != "") ecuacion += " - ";
                if (coef < 0 && ecuacion == "") ecuacion += "-";

                double valAbsoluto = Math.Abs(coef);

                // Imprimir el valor y su correspondiente x^i
                if (i == 0)
                {
                    // Término independiente
                    ecuacion += valAbsoluto.ToString();
                }
                else if (i == 1)
                {
                    // Término lineal (x)
                    ecuacion += (valAbsoluto == 1) ? "x" : $"{valAbsoluto}x";
                }
                else
                {
                    // Términos de grado mayor
                    ecuacion += (valAbsoluto == 1) ? $"x^{i}" : $"{valAbsoluto}x^{i}";
                }
            }

            return ecuacion == "" ? "0" : ecuacion;
        }

        /// <summary>
        /// Genera y retorna la matriz bidimensional completa de diferencias divididas
        /// para poder imprimirla en la interfaz gráfica.
        /// </summary>
        public double[,] CalcularTablaDiferencias(double[] X, double[] Y)
        {
            int n = X.Length;
            double[,] F = new double[n, n];

            for (int i = 0; i < n; i++) F[i, 0] = Y[i];

            for (int j = 1; j < n; j++)
            {
                for (int i = 0; i < n - j; i++)
                {
                    F[i, j] = (F[i + 1, j - 1] - F[i, j - 1]) / (X[i + j] - X[i]);
                }
            }
            return F;
        }
    }
}
