using System;
using System.Diagnostics;

namespace CpuCache
{
    public static class Benchmarking
    {

        public static void Main(string[] args)
        {
            MatrixTraversal.Run();
            AOSvsSOA.Run();
        }
        
        public static TimeSpan MeasureExecution(Action action)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            action.Invoke();
            stopWatch.Stop();
            return stopWatch.Elapsed;
        }
    }
}