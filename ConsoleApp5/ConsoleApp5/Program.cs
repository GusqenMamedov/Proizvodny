using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace parzifal
{
    internal class Program
    {
        static void Main()
        {
            // Заданные узлы и значения функции
            double[] xi = { 0.441, 0.445, 0.449, 0.453, 0.457 };
            double[] yi = { 2.76058, 2.78612, 2.81190, 2.83792, 2.86226 };
            // Вычисление первой производной
            double[] firstDerivatives = CalculateFirstDerivatives(xi, yi);
            Console.WriteLine("Первая производная:"); for (int i = 0; i < firstDerivatives.Length; i++)
            {
                Console.WriteLine($"f'({xi[i]}) = {firstDerivatives[i]}");
            }
            // Вычисление второй производной
            double[] secondDerivatives = CalculateSecondDerivatives(xi, yi);
            Console.WriteLine("Вторая производная:"); for (int i = 0; i < secondDerivatives.Length; i++)
            {
                Console.WriteLine($"f''({xi[i]}) = {secondDerivatives[i]}");
            }
        }
        static double[] CalculateFirstDerivatives(double[] xi, double[] yi)
        {
            int n = xi.Length;
            double[] derivatives = new double[n];
            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    derivatives[i] = (-3 * yi[i] + 4 * yi[i + 1] - yi[i + 2]) / (2 * (xi[i + 1] - xi[i]));
                }
                else if (i == n - 1)
                {
                    derivatives[i] = (3 * yi[i] - 4 * yi[i - 1] + yi[i - 2]) / (2 * (xi[i] - xi[i - 1]));
                }
                else
                {
                    derivatives[i] = (yi[i + 1] - yi[i - 1]) / (xi[i + 1] - xi[i - 1]);
                }
            }
            return derivatives;
        }
        static double[] CalculateSecondDerivatives(double[] xi, double[] yi)
        {
            int n = xi.Length;
            double[] derivatives = new double[n];
            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    derivatives[i] = (2 * yi[i] - 5 * yi[i + 1] + 4 * yi[i + 2] - yi[i + 3]) / Math.Pow(xi[i + 1] - xi[i], 2);
                }
                else if (i == n - 1)
                {
                    derivatives[i] = (2 * yi[i] - 5 * yi[i - 1] + 4 * yi[i - 2] - yi[i - 3]) / Math.Pow(xi[i] - xi[i - 1], 2);
                }
                else
                {
                    derivatives[i] = (yi[i + 1] - 2 * yi[i] + yi[i - 1]) / Math.Pow(xi[i + 1] - xi[i], 2);
                }
            }
            return derivatives;
        }
    }
}