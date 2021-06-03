using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_Algebra_Lineal
{
    class Operaciones
    {
        // Atributos
        public int[,] firstIntDimVector;
        private int[,] secondIntDimVector;
        private int escalar;

        // Constructor
        public Operaciones(int[,] firstIntDimVector, int[,] secondIntDimVector, int escalar)
        {
            this.firstIntDimVector = firstIntDimVector;
            this.secondIntDimVector = secondIntDimVector;
            this.escalar = escalar;
        }

        // Metodos
        // Suma
        public int[,] sumaMatriz()
        {
            int[,] sumVect = new int[firstIntDimVector.GetLength(0), secondIntDimVector.GetLength(0)];
            for (int i = 0; i < firstIntDimVector.GetLength(0); i++)
            {
                for (int j = 0; j < secondIntDimVector.GetLength(1); j++)
                {
                    sumVect[i, j] = firstIntDimVector[i, j] + secondIntDimVector[i, j];
                }
            }
            return sumVect;
        }

        // Resta
        public int[,] restaMatriz()
        {
            int[,] restaVect = new int[firstIntDimVector.GetLength(0), secondIntDimVector.GetLength(0)];
            for (int i = 0; i < firstIntDimVector.GetLength(0); i++)
            {
                for (int j = 0; j < secondIntDimVector.GetLength(1); j++)
                {
                    restaVect[i, j] = firstIntDimVector[i, j] - secondIntDimVector[i, j];
                }
            }
            return restaVect;
        }

        // Escalar
        public int[,] escalarMatriz()
        {
            int[,] escalarVect = new int[firstIntDimVector.GetLength(0), firstIntDimVector.GetLength(1)];
            for (int i = 0; i < firstIntDimVector.GetLength(0); i++)
            {
                for (int j = 0; j < firstIntDimVector.GetLength(1); j++)
                {
                    escalarVect[i, j] = escalar * firstIntDimVector[i, j];
                }
            }
            return escalarVect;
        }

        // Transpuesta
        public int[,] transpuestaMatriz()
        {
            int[,] transpuestaVect = new int[firstIntDimVector.GetLength(1), firstIntDimVector.GetLength(0)];
            for (int i = 0; i < transpuestaVect.GetLength(0); i++)
            {
                for (int j = 0; j < transpuestaVect.GetLength(1); j++)
                {
                    transpuestaVect[i, j] = firstIntDimVector[j, i];
                }
            }
            return transpuestaVect;
        }

        // Determinante con laplace
        public double laplaceDet(int[,] firstIntDimVector)
        {
            double det = 0;

            if (firstIntDimVector.GetLength(1) == 1)
            {
                return firstIntDimVector[0, 0];
            }
            else
            {
                for (int k = 0; k < firstIntDimVector.GetLength(1); k++)
                {
                    det = det + Math.Pow(-1, k) * firstIntDimVector[0, k] * laplaceDet(minor(firstIntDimVector, k));
                }
            }
            return det;
        }

        // Menor complementario para Laplace
        public int[,] minor(int[,] A, int index2)
        {
            int[,] minorC = new int[A.GetLength(0) - 1, A.GetLength(1) - 1];

            for (int i = 1; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    if (index2 == A.GetLength(1) - 1)
                    {
                        if (j != A.GetLength(1) - 1)
                        {
                            minorC[i - 1, j] = A[i, j];
                        }
                    }
                    else
                    {
                        if (j > index2)
                        {
                            minorC[i - 1, j - 1] = A[i, j];
                        }
                        else
                        {
                            if (index2 == 0)
                            {
                                minorC[i - 1, j] = A[i - 1, j + 1];
                            }
                            else
                            {
                                minorC[i - 1, j] = A[i, j];
                            }
                        }
                    }
                }
            }
            return minorC;
        }
        
        // Multiplicacion de matriz
        public int[,] multMatriz()
        {
            int[,] c = new int[firstIntDimVector.GetLength(0), secondIntDimVector.GetLength(1)];
            int suma = 0;
            for (int i = 0; i < firstIntDimVector.GetLength(0); i++)
            {
                for (int j = 0; j < secondIntDimVector.GetLength(1); j++)
                {
                    for (int k = 0; k < secondIntDimVector.GetLength(0); k++)
                    {
                        suma = suma + (firstIntDimVector[i, k] * secondIntDimVector[k, j]);
                    }
                    c[i, j] = suma;
                    suma = 0;
                }
            }
            return c;
        }
    }
}
