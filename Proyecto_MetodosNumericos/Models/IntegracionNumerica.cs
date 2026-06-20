using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_MetodosNumericos.Models
{
    public class IntegracionNumerica
    {
        public static double[,] CalcularRomberg(string funcion, double a, double b, int niveles)
        {
            if (niveles < 1)
                throw new ArgumentException("El nivel (N) debe ser mínimo 1 para aplicar Romberg.");

            double[,] I = new double[niveles + 1, niveles + 1];

            // ---------------------------------------------------------
            // FASE 1: Construir la Columna 1 (Trapecio con n = 2^j)
            // ---------------------------------------------------------
            for (int j = 1; j <= niveles; j++)
            {
                int nTrapecio = (int)Math.Pow(2, j); // n = 2, 4, 8, 16...
                double h = (b - a) / nTrapecio;

                double suma = EvaluadorFunciones.Evaluar(funcion, a) + EvaluadorFunciones.Evaluar(funcion, b);

                for (int i = 1; i < nTrapecio; i++)
                {
                    double xi = a + (i * h);
                    suma += 2 * EvaluadorFunciones.Evaluar(funcion, xi);
                }

                I[j, 1] = (h / 2.0) * suma;
            }

            // ---------------------------------------------------------
            // FASE 2: Extrapolación de Romberg
            // ---------------------------------------------------------
            for (int k = 2; k <= niveles; k++)
            {
                for (int j = 1; j <= niveles - k + 1; j++)
                {
                    double factor = Math.Pow(4, k - 1);
                    I[j, k] = (factor * I[j + 1, k - 1] - I[j, k - 1]) / (factor - 1);
                }
            }

            return I; // Devolvemos la matriz armadita
        }


    }
}
