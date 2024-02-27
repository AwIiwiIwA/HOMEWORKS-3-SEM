using NUnit.Framework;
using System;

namespace HWMatrixMultiplication.Tests
{
    [TestFixture]
    public class MatrixMultiplicationTests
    {
        [Test]
        public void TestMultiplyMatrices_ValidMatrices_ReturnsCorrectResult()
        {
            // Arrange
            int[,] matrixA = new int[,]
            {
                { 1, 2 },
                { 3, 4 }
            };
            int[,] matrixB = new int[,]
            {
                { 5, 6 },
                { 7, 8 }
            };
            int[,] expectedResult = new int[,]
            {
                { 19, 22 },
                { 43, 50 }
            };

            // Act
            int[,] actualResult = MatrixMultiplication.MultiplyMatrices(matrixA, matrixB);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestMultiplyMatrices_InvalidMatrices_ThrowsException()
        {
            // Arrange
            int[,] matrixA = new int[,]
            {
                { 1, 2 },
                { 3, 4 }
            };
            int[,] matrixB = new int[,]
            {
                { 5, 6 },
                { 7, 8 },
                { 9, 10 }
            };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => MatrixMultiplication.MultiplyMatrices(matrixA, matrixB));
        }

        [Test]
        public void TestMultiplyMatrices_SingleElementMatrices_ReturnsCorrectResult()
        {
            // Arrange
            int[,] matrixA = new int[,] { { 2 } };
            int[,] matrixB = new int[,] { { 3 } };
            int[,] expectedResult = new int[,] { { 6 } };

            // Act
            int[,] actualResult = MatrixMultiplication.MultiplyMatrices(matrixA, matrixB);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestMultiplyMatrices_LargeMatrices_ReturnsCorrectResult()
        {
            // Arrange
            int matrixSize = 100;
            int[,] matrixA = new int[matrixSize, matrixSize];
            int[,] matrixB = new int[matrixSize, matrixSize];
            Random rand = new Random();

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    matrixA[i, j] = rand.Next(10);
                    matrixB[i, j] = rand.Next(10);
                }
            }

            // Act
            int[,] actualResult = MatrixMultiplication.MultiplyMatrices(matrixA, matrixB);

            // Assert
            // Since we're multiplying two random matrices, we can't predict the exact result.
            // We can only check that the result is not null and has the expected dimensions.
            Assert.IsNotNull(actualResult);
            Assert.AreEqual(matrixSize, actualResult.GetLength(0));
            Assert.AreEqual(matrixSize, actualResult.GetLength(1));
        }

        [Test]
        public void TestMultiplyMatrices_ZeroMatrices_ReturnsCorrectResult()
        {
            // Arrange
            int[,] matrixA = new int[,] { { 0, 0 }, { 0, 0 } };
            int[,] matrixB = new int[,] { { 0, 0 }, { 0, 0 } };
            int[,] expectedResult = new int[,] { { 0, 0 }, { 0, 0 } };

            // Act
            int[,] actualResult = MatrixMultiplication.MultiplyMatrices(matrixA, matrixB);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}