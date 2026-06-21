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

        // PARA SIMPSON 1/3 DOBLE
        public static double CalcularSimpson13Doble(string funcion, double a, double b, int nx, double c, double d, int ny, out System.Data.DataTable tablaPasos)
        {
            if (nx % 2 != 0 || ny % 2 != 0)
                throw new ArgumentException("Para Simpson 1/3 Doble, tanto Nx como Ny deben ser números pares.");

            double hx = (b - a) / nx;
            double hy = (d - c) / ny;

            int[] pesosX = GenerarPesosSimpson13(nx);
            int[] pesosY = GenerarPesosSimpson13(ny);

            double integral = 0;
            tablaPasos = new System.Data.DataTable();

            // Configurar columnas de la tabla (La primera es la etiqueta Y, las demás son las X)
            tablaPasos.Columns.Add("Y \\ X");
            for (int i = 0; i <= nx; i++)
            {
                tablaPasos.Columns.Add(Math.Round(a + i * hx, 4).ToString());
            }

            // Evaluar la cuadrícula
            for (int j = 0; j <= ny; j++)
            {
                double yj = c + j * hy;
                System.Data.DataRow fila = tablaPasos.NewRow();
                fila[0] = Math.Round(yj, 4).ToString(); // Etiqueta de la fila

                for (int i = 0; i <= nx; i++)
                {
                    double xi = a + i * hx;
                    double fxy = EvaluadorFunciones.EvaluarDoble(funcion, xi, yj);

                    fila[i + 1] = Math.Round(fxy, 6); // Guardamos para mostrar en la interfaz

                    // Multiplicador cruzado de Simpson 2D
                    integral += pesosX[i] * pesosY[j] * fxy;
                }
                tablaPasos.Rows.Add(fila);
            }

            return integral * (hx * hy / 9.0);
        }

        // Método auxiliar para generar el arreglo de pesos (1, 4, 2, 4... 1)
        private static int[] GenerarPesosSimpson13(int n)
        {
            int[] pesos = new int[n + 1];
            pesos[0] = 1;
            pesos[n] = 1;
            for (int i = 1; i < n; i++)
            {
                pesos[i] = (i % 2 == 0) ? 2 : 4;
            }
            return pesos;
        }

        // PARA IMPSON 3/8 DOBLE
        public static double CalcularSimpson38Doble(string funcion, double a, double b, int nx, double c, double d, int ny, out System.Data.DataTable tablaPasos)
        {
            // Regla de oro: múltiplos de 3 obligatorios
            if (nx % 3 != 0 || ny % 3 != 0)
                throw new ArgumentException("Para Simpson 3/8 Doble, tanto Nx como Ny deben ser múltiplos de 3 (ej: 3, 6, 9...).");

            double hx = (b - a) / nx;
            double hy = (d - c) / ny;

            int[] pesosX = GenerarPesosSimpson38(nx);
            int[] pesosY = GenerarPesosSimpson38(ny);

            double integral = 0;
            tablaPasos = new System.Data.DataTable();

            // Configurar columnas de la tabla
            tablaPasos.Columns.Add("Y \\ X");
            for (int i = 0; i <= nx; i++)
            {
                tablaPasos.Columns.Add(Math.Round(a + i * hx, 4).ToString());
            }

            // Evaluar la cuadrícula interactiva
            for (int j = 0; j <= ny; j++)
            {
                double yj = c + j * hy;
                System.Data.DataRow fila = tablaPasos.NewRow();
                fila[0] = Math.Round(yj, 4).ToString();

                for (int i = 0; i <= nx; i++)
                {
                    double xi = a + i * hx;
                    double fxy = EvaluadorFunciones.EvaluarDoble(funcion, xi, yj);

                    fila[i + 1] = Math.Round(fxy, 6);

                    // Cruzamos los pesos del algoritmo en 2D
                    integral += pesosX[i] * pesosY[j] * fxy;
                }
                tablaPasos.Rows.Add(fila);
            }

            // El factor de escala global para Simpson 3/8 en dos dimensiones
            return integral * (9.0 * hx * hy / 64.0);
        }

        // Generador dinámico de pesos para Simpson 3/8 (1, 3, 3, 2, 3, 3...)
        private static int[] GenerarPesosSimpson38(int n)
        {
            int[] pesos = new int[n + 1];
            pesos[0] = 1;
            pesos[n] = 1;
            for (int i = 1; i < n; i++)
            {
                pesos[i] = (i % 3 == 0) ? 2 : 3;
            }
            return pesos;
        }

        // =========================================================
        // PARA ROMBERG DOBLE
        // =========================================================

        // 1. Ayudante: Calcula la regla del Trapecio en 2D para un N específico
        private static double CalcularTrapecioDoble(string funcion, double a, double b, double c, double d, int n)
        {
            double hx = (b - a) / n;
            double hy = (d - c) / n;
            double suma = 0;

            for (int i = 0; i <= n; i++)
            {
                double xi = a + i * hx;
                // Pesos del trapecio en X: 1 en los extremos, 2 en el medio
                int pesoX = (i == 0 || i == n) ? 1 : 2;

                for (int j = 0; j <= n; j++)
                {
                    double yj = c + j * hy;
                    // Pesos del trapecio en Y: 1 en los extremos, 2 en el medio
                    int pesoY = (j == 0 || j == n) ? 1 : 2;

                    double fxy = EvaluadorFunciones.EvaluarDoble(funcion, xi, yj);

                    // Multiplicamos cruzado: PesoX * PesoY * f(x,y)
                    suma += pesoX * pesoY * fxy;
                }
            }

            // Factor multiplicador del Trapecio 2D
            return suma * (hx * hy / 4.0);
        }
         
        // 2. Matriz de Romberg para la Integral Doble
        public static double[,] CalcularRombergDoble(string funcion, double a, double b, double c, double d, int niveles)
        {
            if (niveles < 1)
                throw new ArgumentException("El nivel (N) debe ser mínimo 1 para aplicar Romberg.");

            double[,] I = new double[niveles + 1, niveles + 1];

            // ---------------------------------------------------------
            // FASE 1: Construir la Columna 1 (Trapecio Doble con n = 2^j)
            // ---------------------------------------------------------
            for (int j = 1; j <= niveles; j++)
            {
                int nTrapecio = (int)Math.Pow(2, j); // n = 2, 4, 8, 16...
                // Llamamos a nuestro ayudante para que haga el trabajo sucio
                I[j, 1] = CalcularTrapecioDoble(funcion, a, b, c, d, nTrapecio);
            }

            // ---------------------------------------------------------
            // FASE 2: Extrapolación de Romberg (Fórmula corregida de la profe)
            // I_{J,K} = (4^{k-1} * I_{J+1, K-1} - I_{J, K-1}) / (4^{k-1} - 1)
            // ---------------------------------------------------------
            for (int k = 2; k <= niveles; k++)
            {
                for (int j = 1; j <= niveles - k + 1; j++)
                {
                    double factor = Math.Pow(4, k - 1);
                    I[j, k] = (factor * I[j + 1, k - 1] - I[j, k - 1]) / (factor - 1);
                }
            }

            return I;
        }

    }
}
