using System;

namespace CpuCache
{
    internal static class MatrixTraversal
    {
        private const int Dimen = 10000;
        
        private static readonly int[] Matrix = new int[Dimen * Dimen];
        
        public static void Run()
        {            
            InitializeMatrix();
            Console.WriteLine("Matrix dimen: {0}", Dimen);
            
            var time = Benchmarking.MeasureExecution(RowTraversal);
            Console.WriteLine("Row-wise traversal execution time: {0} ms", time.TotalMilliseconds);
            
            time = Benchmarking.MeasureExecution(ColumnTraversal);
            Console.WriteLine("Column-wise traversal execution time: {0} ms", time.TotalMilliseconds);
        }

        private static void InitializeMatrix()
        {
            var counter = 0;
            for (var i = 0; i < Dimen; ++i)
            {
                for (var j = 0; j < Dimen; ++j)
                {
                    Matrix[i * Dimen + j] = counter++;
                }
            }
        }

        private static void RowTraversal()
        {
            var sum = 0L;
            for (var i = 0; i < Dimen; ++i)
            {
                for (var j = 0; j < Dimen; ++j)
                {
                    sum += Matrix[i * Dimen + j];
                }
            }
            Console.WriteLine("Sum result: {0}",sum);
        }

        private static void ColumnTraversal()
        {
            var sum = 0L;
            for (var j = 0; j < Dimen; ++j)
            {
                for (var i = 0; i < Dimen; ++i)
                {
                    sum += Matrix[i * Dimen + j];
                }
            }
            Console.WriteLine("Sum result: {0}",sum);
        }        
    }
}