
    [TestFixture]
    public class MatrixTests
    {
        [Test]
        public void TestMatrixMultiplication()
        {
            // Создаем матрицы
            Matrix matrixA = new Matrix(2, 3);
            matrixA.Data[0, 0] = 1;
            matrixA.Data[0, 1] = 2;
            matrixA.Data[0, 2] = 3;
            matrixA.Data[1, 0] = 4;
            matrixA.Data[1, 1] = 5;
            matrixA.Data[1, 2] = 6;

            Matrix matrixB = new Matrix(3, 2);
            matrixB.Data[0, 0] = 7;
            matrixB.Data[0, 1] = 8;
            matrixB.Data[1, 0] = 9;
            matrixB.Data[1, 1] = 10;
            matrixB.Data[2, 0] = 11;
            matrixB.Data[2, 1] = 12;

            // Выполняем умножение
            Matrix result = Matrix.Multiply(matrixA, matrixB);

            // Проверяем результаты
            Assert.AreEqual(58, result.Data[0, 0]);
            Assert.AreEqual(64, result.Data[0, 1]);
            Assert.AreEqual(139, result.Data[1, 0]);
            Assert.AreEqual(154, result.Data[1, 1]);
        }

        [Test]
        public void TestMatrixMultiplicationInvalidDimensions()
        {
            // Создаем матрицы с неправильными размерами для умножения
            Matrix matrixA = new Matrix(2, 3);
            Matrix matrixB = new Matrix(4, 2);

            // Попытка умножения матриц с неправильными размерами должна вызывать исключение
            Assert.Throws<InvalidOperationException>(() => Matrix.Multiply(matrixA, matrixB));
        }

        [Test]
        public void TestMatrixMultiplicationIdentityMatrix()
        {
            // Создаем единичную матрицу
            Matrix identityMatrix = new Matrix(2, 2);
            identityMatrix.Data[0, 0] = 1;
            identityMatrix.Data[1, 1] = 1;

            // Умножаем единичную матрицу на другую матрицу
            Matrix matrixA = new Matrix(2, 2);
            matrixA.Data[0, 0] = 2;
            matrixA.Data[0, 1] = 3;
            matrixA.Data[1, 0] = 4;
            matrixA.Data[1, 1] = 5;

            Matrix result = Matrix.Multiply(identityMatrix, matrixA);

            // Результат должен быть равен исходной матрице
            Assert.IsTrue(Utils.AreMatricesEqual(matrixA, result));
        }

        [Test]
        public void TestMatrixMultiplicationZeroMatrix()
        {
            // Создаем нулевую матрицу
            Matrix zeroMatrix = new Matrix(3, 3);

            // Умножаем нулевую матрицу на другую матрицу
            Matrix matrixB = new Matrix(3, 3);
            matrixB.Data[0, 0] = 1;
            matrixB.Data[0, 1] = 2;
            matrixB.Data[0, 2] = 3;
            matrixB.Data[1, 0] = 4;
            matrixB.Data[1, 1] = 5;
            matrixB.Data[1, 2] = 6;
            matrixB.Data[2, 0] = 7;
            matrixB.Data[2, 1] = 8;
            matrixB.Data[2, 2] = 9;

            Matrix result = Matrix.Multiply(zeroMatrix, matrixB);

            // Результат должен быть нулевой матрицей
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(0, result.Data[i, j]);
                }
            }
        }
    }
