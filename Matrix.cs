using System;

public class Matrix
{
    public int[,] Data { get; }
    public int Rows { get; }
    public int Columns { get; }

    public Matrix(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        Data = new int[rows, columns];
    }

    public static Matrix Multiply(Matrix A, Matrix B)
    {
        if (A.Columns != B.Rows)
            throw new InvalidOperationException("The number of columns in matrix A must be equal to the number of rows in matrix B.");

        Matrix result = new Matrix(A.Rows, B.Columns);

        for (int i = 0; i < A.Rows; i++)
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

        return result;
    }
}
