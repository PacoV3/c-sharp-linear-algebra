using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_Algebra_Lineal
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declaras valores para trabajar y objetos para usar
            Operaciones Op1, Op2;
            int escalar;

            // Leer las matrices
            string inputText;
            string[] rengColumVal;
            Console.WriteLine("\t\t\t\t\t\t«Calculadora de Matrices»");
            Console.Write("Renglones y columnas de la matriz A: ");
            inputText = Console.ReadLine();
            rengColumVal = inputText.Split(' ');

            int[,] a = new int[int.Parse(rengColumVal[0]), int.Parse(rengColumVal[1])];
            pedirMatriz(a);

            Console.Write("\nRenglones y columnas de la matriz B: ");
            inputText = Console.ReadLine();
            rengColumVal = inputText.Split(' ');

            int[,] b = new int[int.Parse(rengColumVal[0]), int.Parse(rengColumVal[1])];
            pedirMatriz(b);

            Console.Write("\nValor del escalar: ");
            escalar = int.Parse(Console.ReadLine());

            Op1 = new Operaciones(a, b, escalar);
            Op2 = new Operaciones(b, a, escalar);

            // Validaciones para usar los metodos correctos
            if(a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1))
            {
                int[,] escalarA = Op1.escalarMatriz();
                int[,] escalarB = Op2.escalarMatriz();

                int[,] transpuestaA = Op1.transpuestaMatriz();
                int[,] transpuestaB = Op2.transpuestaMatriz();

                // Imprimir los datos de cada matriz
                Console.WriteLine("\nMatriz A");
                imprimirMatriz(a);
                Console.WriteLine("\nMatriz B");
                imprimirMatriz(b);

                if (a.GetLength(1) == b.GetLength(0))
                {
                    int[,] multiplicacion = Op1.multMatriz();

                    Console.WriteLine("\nA X B");
                    imprimirMatriz(multiplicacion);
                }
                else
                    Console.WriteLine("\nNo se puede calcular A X B, comprueba las columnas y filas de tus matrices");


                Console.WriteLine("\nEscalar de A con " + escalar);
                imprimirMatriz(escalarA);
                Console.WriteLine("\nEscalar de B con " + escalar);
                imprimirMatriz(escalarB);

                Console.WriteLine("\nTranspuesta de la matriz A");
                imprimirMatriz(transpuestaA);
                Console.WriteLine("\nTranspuesta de la matriz B");
                imprimirMatriz(transpuestaB);

                // Calcular Determinante
                if(a.GetLength(0) == a.GetLength(1) && b.GetLength(0) == b.GetLength(1))
                {
                    double detA = Op1.laplaceDet(a);
                    double detB = Op2.laplaceDet(a);

                    Console.WriteLine("\nDeterminante de la matriz A");
                    Console.WriteLine(detA);
                    Console.WriteLine("\nDeterminante de la matriz B");
                    Console.WriteLine(detB);
                }
                else
                {
                    if(a.GetLength(0) == a.GetLength(1))
                    {
                        double detA = Op1.laplaceDet(a);
                        Console.WriteLine("\nDeterminante de la matriz A");
                        Console.WriteLine(detA);
                        Console.WriteLine("\nB tiene que ser una matriz cuadrada para calcular su determinante");
                    }
                    else
                    {
                        if(b.GetLength(0) == b.GetLength(1))
                        {
                            double detB = Op2.laplaceDet(b);
                            Console.WriteLine("\nDeterminante de la matriz B");
                            Console.WriteLine(detB);
                            Console.WriteLine("\nA tiene que ser una matriz cuadrada para calcular su determinante");
                        }
                        else
                            Console.WriteLine("\nA y B tienen que ser matrices cuadradas para calcular su determinante");
                    }
                }
            }
            else
            {
                int[,] suma = Op1.sumaMatriz();
                int[,] restaAB = Op1.restaMatriz();
                int[,] restaBA = Op2.restaMatriz();

                int[,] escalarA = Op1.escalarMatriz();
                int[,] escalarB = Op2.escalarMatriz();

                int[,] transpuestaA = Op1.transpuestaMatriz();
                int[,] transpuestaB = Op2.transpuestaMatriz();

                Console.WriteLine("\nMatriz A");
                imprimirMatriz(a);
                Console.WriteLine("\nMatriz B");
                imprimirMatriz(b);

                Console.WriteLine("\nA + B");
                imprimirMatriz(suma);
                Console.WriteLine("\nA - B");
                imprimirMatriz(restaAB);
                Console.WriteLine("\nB - A");
                imprimirMatriz(restaAB);

                if (a.GetLength(1) == b.GetLength(0))
                {
                    int[,] multiplicacion = Op1.multMatriz();

                    Console.WriteLine("\nA X B");
                    imprimirMatriz(multiplicacion);
                }
                else
                    Console.WriteLine("\nNo se puede calcular A X B, comprueba las columnas y filas de tus matrices");

                Console.WriteLine("\nEscalar de A con " + escalar);
                imprimirMatriz(escalarA);
                Console.WriteLine("\nEscalar de B con " + escalar);
                imprimirMatriz(escalarB);

                Console.WriteLine("\nTranspuesta de la matriz A");
                imprimirMatriz(transpuestaA);
                Console.WriteLine("\nTranspuesta de la matriz B");
                imprimirMatriz(transpuestaB);

                // Calcular Determinante
                if (a.GetLength(0) == a.GetLength(1) && b.GetLength(0) == b.GetLength(1))
                {
                    double detA = Op1.laplaceDet(a);
                    double detB = Op2.laplaceDet(a);

                    Console.WriteLine("\nDeterminante de la matriz A");
                    Console.WriteLine(detA);
                    Console.WriteLine("\nDeterminante de la matriz B");
                    Console.WriteLine(detB);
                }
                else
                {
                    if (a.GetLength(0) == a.GetLength(1))
                    {
                        double detA = Op1.laplaceDet(a);
                        Console.WriteLine("\nDeterminante de la matriz A");
                        Console.WriteLine(detA);
                        Console.WriteLine("\nB tiene que ser una matriz cuadrada para calcular su determinante");
                    }
                    else
                    {
                        if (b.GetLength(0) == b.GetLength(1))
                        {
                            double detB = Op2.laplaceDet(b);
                            Console.WriteLine("\nDeterminante de la matriz B");
                            Console.WriteLine(detB);
                            Console.WriteLine("\nA tiene que ser una matriz cuadrada para calcular su determinante");
                        }
                        else
                            Console.WriteLine("\nA y B tienen que ser matrices cuadradas para calcular su determinante");
                    }
                }

            }

            Console.ReadLine();
        }
        
        // Funcion void para imprimir el contenido de una matriz
        public static void imprimirMatriz(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        // Funcion para leer los valores linea por linea y almacenarlos
        public static void pedirMatriz(int[,] a)
        {
            string inputText;
            string[] rengColumVal;

            Console.WriteLine("Valores de la matriz: ");
            for (int i = 0; i < a.GetLength(0); i++)
            {
                inputText = Console.ReadLine();
                rengColumVal = inputText.Split(' ');
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    a[i, j] = int.Parse(rengColumVal[j]);
                }
            }
        }
    }
    // Francisco Javier Ventura Segura 
}
