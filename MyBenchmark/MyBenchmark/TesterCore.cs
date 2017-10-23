﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyBenchmark
{
    public class TesterCore
    {
        public static void RunAllTests(Assembly asm)
        {
            foreach (var type in asm.GetTypes())
            {
                foreach (var method in type.GetMethods())
                {

                    var myTestAttrib = method.GetCustomAttribute<MyTestAttribute>();

                    if (myTestAttrib != null)
                    {
                        RunTest(method, type);
                    }
                }
            }
        }

        private static void RunTest(MethodInfo method, Type type)
        {
            if (!method.IsStatic)
            {
                RunTestForNotStatic(method, type);
            }
            else
            {
                RunTestForStatic(method);
            }
        }

        public static void RunTestForNotStatic(MethodInfo method, Type type)
        {
            var timer = new Stopwatch();

            var myTestAttrib = method.GetCustomAttribute<MyTestAttribute>();
            var paramsAttrib = method.GetCustomAttribute<ParamsAttribute>();
            var myClass = Activator.CreateInstance(type);

            if (paramsAttrib != null)
            {
                if (method.GetParameters().Length.Equals(0))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Метод без параметров вызван с атрибутом Params");
                }

                Console.Write("method get parameters \n" + method.GetParameters().Length);
                foreach (var param in paramsAttrib.Params)
                {
                    timer.Restart(); // Reset + Start

                    Console.Write("Begin {0}...", method.Name);

                    for (var i = 0; i < myTestAttrib.TestCount; i++)
                    {
                        method.Invoke(myClass, new[] {param});
                    }

                    timer.Stop();

                    var avgTime = timer.ElapsedMilliseconds/(double) myTestAttrib.TestCount;

                    // "\r" переведет каретку в начало строки и текст будет выведен по верх прошлой записи "Begin..."
                    ShowResult(method.Name, avgTime, timer.ElapsedMilliseconds, myTestAttrib.TestCount);
                }
            }
            else
            {
                if (!method.GetParameters().Length.Equals(0))
                {
                    throw new CustomAttributeFormatException("Метод с параметрами не помечен атрибутом Params!");
                }
               
                timer.Restart(); // Reset + Start

                Console.Write("Begin {0}...", method.Name);

                for (var i = 0; i < myTestAttrib.TestCount; i++)
                {
                    method.Invoke(myClass, new object[] { });
                }

                timer.Stop();

                var avgTime = timer.ElapsedMilliseconds / (double)myTestAttrib.TestCount;

                // "\r" переведет каретку в начало строки и текст будет выведен по верх прошлой записи "Begin..."
                ShowResult(method.Name, avgTime, timer.ElapsedMilliseconds, myTestAttrib.TestCount);
            }
        }

        public static void RunTestForStatic(MethodInfo method)
        {
            var timer = new Stopwatch();

            var myTestAttrib = method.GetCustomAttribute<MyTestAttribute>();
            var paramsAttrib = method.GetCustomAttribute<ParamsAttribute>();

            if (paramsAttrib == null)
            {
                if (!method.GetParameters().Length.Equals(0))
                {
                    throw new CustomAttributeFormatException("Метод с параметрами не помечен атрибутом Params!");
                }

                timer.Restart(); // Reset + Start

                Console.Write("Begin {0}...", method.Name);

                for (var i = 0; i < myTestAttrib.TestCount; i++)
                {
                    method.Invoke(method.GetType(), new object[] { });
                }

                timer.Stop();

                var avgTime = timer.ElapsedMilliseconds / (double)myTestAttrib.TestCount;

                // "\r" переведет каретку в начало строки и текст будет выведен по верх прошлой записи "Begin..."
                ShowResult(method.Name, avgTime, timer.ElapsedMilliseconds, myTestAttrib.TestCount);

            }
            else
            {
                if (method.GetParameters().Length.Equals(0))
                {
                    ConsoleColor currentForeground = ConsoleColor.Yellow;
                    Console.WriteLine("Метод без параметров вызван с атрибутом Params",
                        currentForeground);
                }

                foreach (var param in paramsAttrib.Params)
                {
                    timer.Restart(); // Reset + Start

                    Console.Write("Begin {0}...", method.Name);

                    for (var i = 0; i < myTestAttrib.TestCount; i++)
                    {
                        method.Invoke(null, new[] { param });
                    }

                    timer.Stop();

                    var avgTime = timer.ElapsedMilliseconds / (double)myTestAttrib.TestCount;

                    // "\r" переведет каретку в начало строки и текст будет выведен по верх прошлой записи "Begin..."
                    ShowResult(method.Name, avgTime, timer.ElapsedMilliseconds, myTestAttrib.TestCount);

                }
            }
        }

        public static void ShowResult(String methodName, double avgTime, double totalTime, int testCount)
        {
            Console.WriteLine("\r{0}:\tavg: {1} ms ( {2} ms / {3} )",
                   methodName,
                   avgTime,
                   totalTime,
                   testCount);
        }
    }
}
