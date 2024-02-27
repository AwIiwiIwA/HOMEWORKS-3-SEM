using Lazy;

namespace LazyTest
{
    [TestFixture]
    public class LazyTests
    {
        [Test]
        public void SingleThread_Get_ReturnsCorrectResult()
        {
            // Arrange
            int expectedResult = 42;
            var lazy = new LazySingleThread<int>(() => expectedResult);

            // Act
            int actualResult = lazy.Get();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void SingleThread_Get_ReturnsSameResultOnMultipleCalls()
        {
            // Arrange
            int expectedResult = 42;
            var lazy = new LazySingleThread<int>(() => expectedResult);

            // Act
            int result1 = lazy.Get();
            int result2 = lazy.Get();

            // Assert
            Assert.AreEqual(expectedResult, result1);
            Assert.AreEqual(expectedResult, result2);
        }

        [Test]
        public void MultiThread_Get_ReturnsCorrectResult()
        {
            // Arrange
            int expectedResult = 42;
            var lazy = new LazyMultiThread<int>(() => expectedResult);

            // Act
            int actualResult = lazy.Get();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void MultiThread_Get_ReturnsSameResultOnMultipleCalls()
        {
            // Arrange
            int expectedResult = 42;
            var lazy = new LazyMultiThread<int>(() => expectedResult);

            // Act
            int result1 = lazy.Get();
            int result2 = lazy.Get();

            // Assert
            Assert.AreEqual(expectedResult, result1);
            Assert.AreEqual(expectedResult, result2);
        }

        [Test]
        public void MultiThread_Get_NoRaceConditions()
        {
            // Arrange
            int expectedResult = 42;
            var lazy = new LazyMultiThread<int>(() => expectedResult);
            int numThreads = 100;
            var tasks = new Task[numThreads];

            // Act
            for (int i = 0; i < numThreads; i++)
            {
                tasks[i] = Task.Run(() => lazy.Get());
            }
            Task.WaitAll(tasks);

            // Assert
            int actualResult = lazy.Get();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}