using System;

public static class Utils
{
    public static Matrix GenerateRandomMatrix(int rows, int columns, int maxValue)
    {
        Random rand = new Random();
        Matrix matrix = new Matrix(rows, columns);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix.Data[i, j] = rand.Next(maxValue);
            }
        }

        return matrix;
    }

    public static bool AreMatricesEqual(Matrix A, Matrix B)
    {
        if (A.Rows != B.Rows || A.Columns != B.Columns)
            return false;

        for (int i = 0; i < A.Rows; i++)
        {
            for (int j = 0; j < A.Columns; j++)
            {
                if (A.Data[i, j] != B.Data[i, j])
                    return false;
            }
        }

        return true;
    }
}
