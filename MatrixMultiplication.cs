using System;

namespace HWMatrixMultiplication
{
    public class MatrixMultiplication
    {
        public static int[,] MultiplyMatrices(int[,] matrixA, int[,] matrixB)
        {
            int rowsA = matrixA.GetLength(0);
            int colsA = matrixA.GetLength(1);
            int rowsB = matrixB.GetLength(0);
            int colsB = matrixB.GetLength(1);

            if (colsA != rowsB)
            {
                throw new InvalidOperationException("The number of columns in matrix A must match the number of rows in matrix B.");
            }

            int[,] result = new int[rowsA, colsB];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    for (int k = 0; k < colsA; k++)
                    {
                        result[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return result;
        }

        public static void Main(string[] args)
        {
            // Инициализация матриц и их размерности
            int matrixSize = 10; 
            int[,] matrixA = new int[matrixSize, matrixSize];
            int[,] matrixB = new int[matrixSize, matrixSize];

            // Заполнение матриц случайными числами
            Random rand = new Random();
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    matrixA[i, j] = rand.Next(10);
                    matrixB[i, j] = rand.Next(10);
                }
            }

            // Умножение матриц
            int[,] result = MultiplyMatrices(matrixA, matrixB);

            // Вывод результата
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
