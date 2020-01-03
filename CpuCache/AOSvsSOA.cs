#define AOS

using System;

namespace CpuCache
{
    public static class AOSvsSOA
    {        
        struct Person
        {
            public int age;
            public double x;
            public double y;
            public double z;
            public double w;
            public double q;
            public double e;
            public double r;
            public char flags;
        }

        struct Persons
        {
            public int[] age;
            public char[] flags;
            public double[] x;
            public double[] y;
            public double[] z;
            public double[] w;
            public double[] q;
            public double[] e;
            public double[] r;

            public Persons(int personCount)
            {
                age = new int[personCount];
                flags = new char[personCount];
                x = new double[personCount];
                y = new double[personCount];
                z = new double[personCount];
                w = new double[personCount];
                q = new double[personCount];
                e = new double[personCount];
                r = new double[personCount];
            }
        }
        
        private const int PersonCount = 200000;
        
        private static readonly Person[] ArrayOfStructs = new Person[PersonCount];
        private static readonly Persons StructOfArrays = new Persons(PersonCount);

        private static void SoATest()
        {
            for (var i = 0; i < PersonCount; ++i)
            {
                StructOfArrays.age[i] += 2;
            }
        }

        private static void AoSTest()
        {
            for (var i = 0; i < PersonCount; ++i)
            {
                ArrayOfStructs[i].age += 2;
            }
        }

        public static void Run()
        {
            
            for (var i = 0; i < PersonCount; ++i)
            {
                ArrayOfStructs[i].age = i % 10;
                StructOfArrays.age[i] = i % 10;
            }

            var aosTime = Benchmarking.MeasureExecution(AoSTest);
            Console.WriteLine("AoS traversal {0} ms", aosTime.TotalMilliseconds);
            
            var soaTime = Benchmarking.MeasureExecution(SoATest);
            Console.WriteLine("SoA traversal {0} ms", soaTime.TotalMilliseconds);
        }
    }
}