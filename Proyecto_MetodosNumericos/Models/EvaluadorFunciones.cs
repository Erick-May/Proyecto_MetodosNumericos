using NCalc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Proyecto_MetodosNumericos.Models
{
    public class EvaluadorFunciones
    {
        public static double Evaluar(string funcion, double valorX)
        {
            string funcionCorregida = funcion.ToLower();

            // 1. Evitar división entera
            funcionCorregida = Regex.Replace(funcionCorregida, @"(?<!\.)\b(\d+)\b(?!\.)", "$1.0");

            // 2. Fix de multiplicación implícita
            funcionCorregida = Regex.Replace(funcionCorregida, @"(\d)([a-z\(])", "$1*$2");
            funcionCorregida = Regex.Replace(funcionCorregida, @"(x)([a-z0-9\(])", "$1*$2");
            funcionCorregida = Regex.Replace(funcionCorregida, @"(\))([a-z0-9x\(])", "$1*$2");

            // 3. Arreglar potencias
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
                }
            };

            double resultadoFinal = Convert.ToDouble(e.Evaluate());

            // Escudo anti-imaginarios y divisiones por cero
            if (double.IsNaN(resultadoFinal) || double.IsInfinity(resultadoFinal))
                throw new Exception("ERROR_MATEMATICO");

            return resultadoFinal;
        }


        // PARA INTEGRALES DOBLES (X e Y)
        public static double EvaluarDoble(string funcion, double valorX, double valorY)
        {
            string funcionCorregida = funcion.ToLower();

            // Fix divisiones enteras y multiplicaciones implícitas
            funcionCorregida = Regex.Replace(funcionCorregida, @"(?<!\.)\b(\d+)\b(?!\.)", "$1.0");
            funcionCorregida = Regex.Replace(funcionCorregida, @"(\d)([a-z\(])", "$1*$2");
            // Aquí le enseñamos que tanto X como Y pueden multiplicarse implícitamente
            funcionCorregida = Regex.Replace(funcionCorregida, @"([xy])([a-z0-9\(])", "$1*$2");
            funcionCorregida = Regex.Replace(funcionCorregida, @"(\))([a-z0-9xy\(])", "$1*$2");

            funcionCorregida = ArreglarPotencias(funcionCorregida);

            Expression e = new Expression(funcionCorregida);
            e.Parameters["x"] = valorX;
            e.Parameters["y"] = valorY; // Este es para tomar en cuenta la Y
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
                }
            };

            double resultadoFinal = Convert.ToDouble(e.Evaluate());
            if (double.IsNaN(resultadoFinal) || double.IsInfinity(resultadoFinal))
                throw new Exception("ERROR_MATEMATICO");

            return resultadoFinal;
        }

        private static string ArreglarPotencias(string expresion)
        {
            while (expresion.Contains("^"))
            {
                int index = expresion.IndexOf('^');

                // Buscar la base
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

                // Buscar el exponente
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
    }
}
