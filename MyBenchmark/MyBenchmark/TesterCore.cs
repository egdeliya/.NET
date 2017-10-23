using System;
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
                    //if (!method.IsStatic)
                    //{
                    //    continue;
                    //}

                    var myTestAttrib = method.GetCustomAttribute<MyTestAttribute>();
                    //var myParamsAttrib = method.GetCustomAttribute<ParamsAttribute>();
                    if (myTestAttrib != null)
                    {
                        RunTest(method);
                        //if (myParamsAttrib != null)
                        //{
                        //    RunTest(method, myTestAttrib, myParamsAttrib);
                        //}
                        //else {
                        //    RunTestWithoutParams(method, myTestAttrib, type);
                        //}
                    }
                }
            }
        }

        private static void RunTestWithoutParams(MethodInfo method, MyTestAttribute myTestAttribute, Type myClass)
        {
            // класс для замера производительности (таймер)
            var timer = new Stopwatch();
            var iterateCounter = 100;

            timer.Restart();
            timer.Start();
            for (int i = 0; i < myTestAttribute.TestCount; i++)
            {
                method.Invoke(myClass, null);
            }
            timer.Stop();
            double avg = timer.ElapsedMilliseconds / (double)myTestAttribute.TestCount;
            Console.WriteLine("{3} AVG time {0}ms, Total time {1}ms, Test num {2}",
                avg, timer.ElapsedMilliseconds, myTestAttribute.TestCount,
                method.Name);
        }


        private static void RunTest(MethodInfo method)
        {
            var timer = new Stopwatch();

            var myTestAttrib = method.GetCustomAttribute<MyTestAttribute>();
            var paramsAttrib = method.GetCustomAttribute<ParamsAttribute>();
          
            if (!method.IsStatic)
            {
                var myClass = Activator.CreateInstance(method.GetType());

                throw new NotImplementedException("Статические методы не поддерживаются, сделайте ДЗ!");
            }

            if (paramsAttrib == null)
            {
                //throw new NotImplementedException("Методы без параметров не поддерживаются, сделайте ДЗ!");
                timer.Restart(); // Reset + Start

                Console.Write("Begin {0}...", method.Name);

                for (var i = 0; i < myTestAttrib.TestCount; i++)
                {
                    method.Invoke(method.GetType(), new object[] {});
                }

                timer.Stop();

                var avgTime = timer.ElapsedMilliseconds/(double) myTestAttrib.TestCount;

                // "\r" переведет каретку в начало строки и текст будет выведен по верх прошлой записи "Begin..."
                Console.WriteLine("\r{0}:\tavg: {1} ms ( {2} ms / {3} )",
                    method.Name,
                    avgTime,
                    timer.ElapsedMilliseconds,
                    myTestAttrib.TestCount);

            }
            else
            {
                foreach (var param in paramsAttrib.Params)
                {
                    timer.Restart();    // Reset + Start

                    Console.Write("Begin {0}...", method.Name);

                    for (var i = 0; i < myTestAttrib.TestCount; i++)
                    {
                        method.Invoke(null, new[] { param });
                    }

                    timer.Stop();

                    var avgTime = timer.ElapsedMilliseconds / (double)myTestAttrib.TestCount;

                    // "\r" переведет каретку в начало строки и текст будет выведен по верх прошлой записи "Begin..."
                    Console.WriteLine("\r{0}:\tavg: {1} ms ( {2} ms / {3} )",
                        method.Name,
                        avgTime,
                        timer.ElapsedMilliseconds,
                        myTestAttrib.TestCount);

                    // В C# 7.0 можно писать удобнее
                    //Console.WriteLine($"\r{method.Name}:\tavg: {avgTime} ms ( {timer.ElapsedMilliseconds} ms / {myTestAttrib.TestCount} )");
                }
            }
        }

            

        //private static void RunTest(MethodInfo method, MyTestAttribute myTestAttribute, ParamsAttribute myParamsAtribute)
        //{
        //    // класс для замера производительности (таймер)
        //    var timer = new Stopwatch();
        //    var iterateCounter = 100;


        //    foreach (var param in myParamsAtribute.Params)
        //    {
        //        timer.Restart();
        //        timer.Start();
        //        for (int i = 0; i < myTestAttribute.TestCount; i++)
        //        {
        //            method.Invoke(null, new object[] { param });
        //        }
        //        timer.Stop();
        //        double avg = timer.ElapsedMilliseconds / (double)myTestAttribute.TestCount;
        //        Console.WriteLine("{3} AVG time {0}ms, Total time {1}ms, Test num {2} for {4}",
        //            avg, timer.ElapsedMilliseconds, myTestAttribute.TestCount,
        //            method.Name, myParamsAtribute.ToString());
        //    }


        //}
    }
}
