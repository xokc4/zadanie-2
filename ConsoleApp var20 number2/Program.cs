using System;

namespace ConsoleApp_var20_zadanie2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, m, i, j, k, l = -1;
            double buf, eps = 0.001;
            Console.Write("Введите количество строк: ");
            n = Int16.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов: ");
            m = Int16.Parse(Console.ReadLine());
            double[,] matrix = new double[n,m];
            double[] answerX = new double[n];
            for (i = 0; i < n; i++)
            {
                Console.Write("Введите элементы {0} строки матрицы через пробел: ", i + 1);
                double[] bufMat = Array.ConvertAll(Console.ReadLine().Split(), Double.Parse);
                for (j = 0; j < m; j++)
                {
                    matrix[i, j] = bufMat[j];
                }
            }
            Console.Write("Введенная матрица: \n");
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    Console.Write("{0} ", matrix[i,j]);
                }
                Console.Write("\n");
            }

            i = 0; j = 0;
            while (i < n && j < m)
            {
                buf = 0.0;
                for (k = i; k < n; ++k)
                {
                    if (Math.Abs(matrix[k,j]) > buf)
                    {
                        l = k;
                        buf = Math.Abs(matrix[k,j]);
                    }
                }
                if (buf <= eps)
                {
                    for (k = i; k < n; ++k)
                    {
                        matrix[k,j] = 0.0;
                    }
                    ++j;
                    continue;
                }
                if (l != i)
                {
                    for (k = j; k < m; ++k)
                    {
                        buf = matrix[i,k];
                        matrix[i,k] = matrix[l,k];
                        matrix[l,k] = (-buf);
                    }
                }
                for (k = i + 1; k < n; ++k)
                {
                    buf = (-matrix[k,j] / matrix[i,j]);
                    matrix[k,j] = 0.0;
                    for (l = j + 1; l < m; ++l)
                    {
                        matrix[k,l] += buf * matrix[i,l];
                    }
                }
                ++i; ++j;
            }

            answerX[n-1] = matrix[n-1, m-1] / matrix[n-1, m - 2];
            for (i = n - 2; i >= 0; i--)
            {                
                answerX[i] = matrix[i,m-1];                
                for (j = i + 1; j + 1 < m; j++) answerX[i] -= matrix[i,j] * answerX[j];               
                answerX[i] = answerX[i] / matrix[i, i];

            }
            Console.WriteLine("Решение системы уравнений");
            for (i = 0; i < n; i++)
            {
                Console.Write("X{0} = {1:0.##} ", i+1, answerX[i]);
            }
        }
    }
}
