using System;
using System.Threading;

public class MatrixMultiplier
{
    public static Matrix MultiplyParallel(Matrix A, Matrix B, int numThreads)
    {
        if (A.Columns != B.Rows)
            throw new InvalidOperationException("The number of columns in matrix A must be equal to the number of rows in matrix B.");

        Matrix result = new Matrix(A.Rows, B.Columns);
        Thread[] threads = new Thread[numThreads];
        int rowsPerThread = A.Rows / numThreads;

        for (int i = 0; i < numThreads; i++)
        {
            int startRow = i * rowsPerThread;
            int endRow = (i == numThreads - 1) ? A.Rows : startRow + rowsPerThread;
            threads[i] = new Thread(() => MultiplyPartially(A, B, result, startRow, endRow));
            threads[i].Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        return result;
    }

    private static void MultiplyPartially(Matrix A, Matrix B, Matrix result, int startRow, int endRow)
    {
        for (int i = startRow; i < endRow; i++)
        {
            for (int j = 0; j < B.Columns; j++)
            {
                int sum = 0;
                for (int k = 0; k < A.Columns; k++)
                {
                    sum += A.Data[i, k] * B.Data[k, j];
                }
                result.Data[i, j] = sum;
            }
        }
    }
}
