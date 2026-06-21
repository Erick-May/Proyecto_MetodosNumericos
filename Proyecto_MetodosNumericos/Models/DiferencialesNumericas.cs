using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Proyecto_MetodosNumericos.Models
{
    public class DiferencialesNumericas
    {
        // 1. EULER SIMPLE
        public static DataTable CalcularEulerSimple(string funcion, double x0, double y0, double xf, int pasos)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("i");
            tabla.Columns.Add("xi");
            tabla.Columns.Add("yi");
            tabla.Columns.Add("f(xi, yi) [Pendiente]");
            tabla.Columns.Add("yi+1 [Siguiente]");

            double h = (xf - x0) / pasos;
            double x = x0;
            double y = y0;

            for (int i = 0; i <= pasos; i++)
            {
                if (i == pasos)
                {
                    // En la última iteración ya llegamos al destino, no hay paso siguiente
                    tabla.Rows.Add(i, Math.Round(x, 8), Math.Round(y, 8), "-", "-");
                    break;
                }

                double fxy = EvaluadorFunciones.EvaluarDoble(funcion, x, y);
                double ySiguiente = y + h * fxy;

                tabla.Rows.Add(i, Math.Round(x, 8), Math.Round(y, 8), Math.Round(fxy, 8), Math.Round(ySiguiente, 8));

                // Avanzamos al siguiente punto
                y = ySiguiente;
                x += h;
            }

            return tabla;
        }

        // 2. EULER MODIFICADO (PREDICTOR-CORRECTOR)
        public static DataTable CalcularEulerModificado(string funcion, double x0, double y0, double xf, int pasos)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("i");
            tabla.Columns.Add("xi");
            tabla.Columns.Add("yi");
            tabla.Columns.Add("f(xi, yi)");
            tabla.Columns.Add("y* i+1 (Predictor)");
            tabla.Columns.Add("f(xi+1, y* i+1)");
            tabla.Columns.Add("yi+1 (Corrector)");

            double h = (xf - x0) / pasos;
            double x = x0;
            double y = y0;

            for (int i = 0; i <= pasos; i++)
            {
                if (i == pasos)
                {
                    tabla.Rows.Add(i, Math.Round(x, 8), Math.Round(y, 8), "-", "-", "-", "-");
                    break;
                }

                // Paso 1: Pendiente inicial
                double fxy = EvaluadorFunciones.EvaluarDoble(funcion, x, y);

                // Paso 2: Predicción (Euler Simple)
                double yPred = y + h * fxy;
                double xSiguiente = x + h;

                // Paso 3: Pendiente en el punto futuro predicho
                double fxySiguiente = EvaluadorFunciones.EvaluarDoble(funcion, xSiguiente, yPred);

                // Paso 4: Corrección usando el promedio de ambas pendientes
                double yCorrector = y + (h / 2.0) * (fxy + fxySiguiente);

                tabla.Rows.Add(i, Math.Round(x, 8), Math.Round(y, 8), Math.Round(fxy, 8),
                               Math.Round(yPred, 8), Math.Round(fxySiguiente, 8), Math.Round(yCorrector, 8));

                // Actualizamos variables para la siguiente vuelta
                y = yCorrector;
                x = xSiguiente;
            }

            return tabla;
        }
    }
}
