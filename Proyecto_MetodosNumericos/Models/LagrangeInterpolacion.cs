using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_MetodosNumericos.Models
{
    public class LagrangeInterpolacion
    {
        /// <summary>
        /// 1. CÁLCULO Y EXPANSIÓN SIMBÓLICA DE LOS Li(x)
        /// Genera los polinomios base de Lagrange Li(x) completamente expandidos.
        /// Nota matemática: Los Li(x) solo dependen de X, pero estructuramos la clase 
        /// para que retorne los strings listos para tu interfaz.
        /// </summary>
        public List<string> ObtenerPolinomiosLiExpandidos(double[] X)
        {
            List<string> listaLiStrings = new List<string>();
            List<double[]> listaLiArreglos = CalcularCoeficientesLi(X);

            // Formateamos cada arreglo de coeficientes a texto matemático
            for (int i = 0; i < listaLiArreglos.Count; i++)
            {
                string polinomioTexto = FormatearPolinomioAString(listaLiArreglos[i]);
                listaLiStrings.Add($"L{i}(x) = {polinomioTexto}");
            }

            return listaLiStrings;
        }

        /// <summary>
        /// 2. CONSTRUCCIÓN DEL POLINOMIO FINAL P(x)
        /// Multiplica cada Li(x) por su respectivo f(xi) [es decir, Y[i]] y reduce términos semejantes.
        /// </summary>
        public string ObtenerPolinomioFinal(double[] X, double[] Y)
        {
            int n = X.Length;
            List<double[]> listaLi = CalcularCoeficientesLi(X);

            // Arreglo para acumular los coeficientes del polinomio final P(x)
            double[] polinomioFinal = new double[n];

            for (int i = 0; i < n; i++)
            {
                double[] Li_actual = listaLi[i];
                double f_xi = Y[i];

                // Multiplicamos el polinomio Li(x) por Y[i] y lo sumamos al total
                for (int j = 0; j < Li_actual.Length; j++)
                {
                    polinomioFinal[j] += Li_actual[j] * f_xi;
                }
            }

            return FormatearPolinomioAString(polinomioFinal);
        }

        /// <summary>
        /// 3. EVALUACIÓN (APROXIMACIÓN NUMÉRICA)
        /// Aplica la fórmula pura de Lagrange para encontrar un valor específico sin pasar por la expansión simbólica.
        /// </summary>
        public double Evaluar(double[] X, double[] Y, double xInterpolar)
        {
            int n = X.Length;
            double resultado = 0;

            for (int i = 0; i < n; i++)
            {
                double numerador = 1.0;
                double denominador = 1.0;

                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        numerador *= (xInterpolar - X[j]);
                        denominador *= (X[i] - X[j]);
                    }
                }

                // Sumatoria de Y[i] * Li(x)
                resultado += Y[i] * (numerador / denominador);
            }

            return resultado;
        }

        // ==========================================
        // HELPERS DE CÁLCULO SIMBÓLICO Y VECTORES
        // ==========================================

        /// <summary>
        /// Método interno que hace el trabajo pesado: calcula los coeficientes reales de cada Li(x).
        /// </summary>
        public List<double[]> CalcularCoeficientesLi(double[] X)
        {
            int n = X.Length;
            List<double[]> listaLi = new List<double[]>();

            for (int i = 0; i < n; i++)
            {
                // Un polinomio inicia como "1" (grado 0)
                double[] polinomioNumerador = new double[] { 1.0 };
                double denominador = 1.0;

                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        // 1. Multiplicamos el numerador por el binomio (x - X[j])
                        polinomioNumerador = MultiplicarPolinomioPorBinomio(polinomioNumerador, X[j]);

                        // 2. Multiplicamos la constante del denominador por (X[i] - X[j])
                        denominador *= (X[i] - X[j]);
                    }
                }

                // Dividimos todo el polinomio numerador entre la constante del denominador
                for (int k = 0; k < polinomioNumerador.Length; k++)
                {
                    polinomioNumerador[k] /= denominador;
                }

                listaLi.Add(polinomioNumerador);
            }

            return listaLi;
        }

        /// <summary>
        /// LÓGICA DE MULTIPLICACIÓN (LA MAGIA SIMBÓLICA)
        /// Simula multiplicar un polinomio P(x) por un binomio (x - c).
        /// Cada índice del arreglo representa la potencia de x (ej: P[2] es el coeficiente de x^2).
        /// </summary>
        private double[] MultiplicarPolinomioPorBinomio(double[] P, double c)
        {
            // Al multiplicar por (x - c), el grado del polinomio sube en 1
            double[] resultado = new double[P.Length + 1];

            // P(x) * (x - c) = x*P(x) - c*P(x)
            for (int i = 0; i < resultado.Length; i++)
            {
                // x*P(x): Equivale a desplazar todos los coeficientes un grado hacia arriba
                double terminoX = (i > 0) ? P[i - 1] : 0.0;

                // -c*P(x): Equivale a multiplicar el coeficiente actual por -c
                double terminoC = (i < P.Length) ? -c * P[i] : 0.0;

                // Agrupamos términos semejantes sumándolos
                resultado[i] = terminoX + terminoC;
            }

            return resultado;
        }

        /// <summary>
        /// Transforma el arreglo de coeficientes a un string con formato matemático
        /// </summary>
        private string FormatearPolinomioAString(double[] P)
        {
            string ecuacion = "";

            // Leemos el polinomio de mayor a menor grado
            for (int i = P.Length - 1; i >= 0; i--)
            {
                // Limpiamos los errores microscópicos de punto flotante de la CPU
                double coef = Math.Round(P[i], 6);

                if (Math.Abs(coef) < 1E-10) continue; // Si es cero, no lo imprimimos

                // Manejo visual de signos
                if (coef > 0 && ecuacion != "") ecuacion += " + ";
                if (coef < 0 && ecuacion != "") ecuacion += " - ";
                if (coef < 0 && ecuacion == "") ecuacion += "-";

                double valAbsoluto = Math.Abs(coef);

                // Armado del término dependiendo de su grado (i)
                if (i == 0)
                {
                    ecuacion += valAbsoluto.ToString(); // Término independiente
                }
                else if (i == 1)
                {
                    ecuacion += (valAbsoluto == 1) ? "x" : $"{valAbsoluto}x"; // x lineal
                }
                else
                {
                    ecuacion += (valAbsoluto == 1) ? $"x^{i}" : $"{valAbsoluto}x^{i}"; // x a la n
                }
            }

            return ecuacion == "" ? "0" : ecuacion;
        }
    }
}
