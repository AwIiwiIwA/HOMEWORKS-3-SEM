using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        int numRows = 1000;
        int numCols = 1000;
        int maxValue = 100;

        Console.WriteLine("---------------------------------------\nGenerating random matrices...");
        Matrix matrixA = Utils.GenerateRandomMatrix(numRows, numCols, maxValue);
        Matrix matrixB = Utils.GenerateRandomMatrix(numCols, numRows, maxValue);

        int numThreads = Environment.ProcessorCount; // Используем все доступные ядра процессора

        Console.WriteLine("Multiplying matrices sequentially... \nPlease wait...\n---------------------------------------");
        Stopwatch sequentialStopwatch = new Stopwatch();
        sequentialStopwatch.Start();
        Matrix resultSequential = Matrix.Multiply(matrixA, matrixB);
        sequentialStopwatch.Stop();
        Console.WriteLine("Sequential multiplication completed.");

        Console.WriteLine("Multiplying matrices in parallel...");
        Stopwatch parallelStopwatch = new Stopwatch();
        parallelStopwatch.Start();
        Matrix resultParallel = MatrixMultiplier.MultiplyParallel(matrixA, matrixB, numThreads);
        parallelStopwatch.Stop();
        Console.WriteLine("Parallel multiplication completed.\n---------------------------------------");

        // Проверяем, что результаты последовательного и параллельного умножения совпадают
        bool resultsMatch = Utils.AreMatricesEqual(resultSequential, resultParallel);

        Console.WriteLine("Sequential Execution Time: " + sequentialStopwatch.ElapsedMilliseconds + " ms");
        Console.WriteLine("Parallel Execution Time: " + parallelStopwatch.ElapsedMilliseconds + " ms");
        Console.WriteLine("Results Match: " + resultsMatch + "\n---------------------------------------");

        Console.ReadKey(); // Остановить консоль до нажатия клавиши
    }
}
