using System;


namespace Lazy
{
    class Program
    {
        static void Main(string[] args)
        {
            // Пример использования LazySingleThread
            var lazySingleThread = new LazySingleThread<int>(() =>
            {
                Console.WriteLine("Calculating value in single-threaded mode...");
                return 42; // Пример вычисления значения
            });

            int singleThreadResult = lazySingleThread.Get();
            Console.WriteLine($"Single-threaded result: {singleThreadResult}");

            // Пример использования LazyMultiThread
            var lazyMultiThread = new LazyMultiThread<int>(() =>
            {
                Console.WriteLine("Calculating value in multi-threaded mode...");
                return 42; // Пример вычисления значения
            });

            int multiThreadResult = lazyMultiThread.Get();
            Console.WriteLine($"Multi-threaded result: {multiThreadResult}");
        }
    }

    public interface ILazy<T>
    {
        T Get();
    }

    public class LazySingleThread<T> : ILazy<T>
    {
        private Func<T> supplier;
        private T result;
        private bool isCalculated = false;

        public LazySingleThread(Func<T> supplier)
        {
            this.supplier = supplier;
        }

        public T Get()
        {
            if (!isCalculated)
            {
                result = supplier();
                isCalculated = true;
            }
            return result;
        }
    }

    public class LazyMultiThread<T> : ILazy<T>
    {
        private Func<T> supplier;
        private T result;
        private volatile bool isCalculated = false;
        private object syncRoot = new object();

        public LazyMultiThread(Func<T> supplier)
        {
            this.supplier = supplier;
        }

        public T Get()
        {
            if (!isCalculated)
            {
                lock (syncRoot)
                {
                    if (!isCalculated)
                    {
                        result = supplier();
                        isCalculated = true;
                    }
                }
            }
            return result;
        }
    }
}

   