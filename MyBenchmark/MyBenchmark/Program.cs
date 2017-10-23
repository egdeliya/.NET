using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

// библиотека для тестирования
namespace MyBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            TesterCore.RunAllTests(typeof(Program).Assembly);
            //TesterCore.RunAllTest(Test2);

        }


        [Params(100, 1000, 2000, 10000)]
        [MyTest(500)]
        public static void Test1(int arraySize)
        {
            var sha256 = SHA256.Create();
            var data = new byte[arraySize]; 

            new Random().NextBytes((data));

            byte[] Sha256 = sha256.ComputeHash(data);
        }

        [Params(100, 1000, 2000, 10000)]
        [MyTest]
        public static void Test2(int arraySize)
        {
            var md5 = MD5.Create();
            var data = new byte[arraySize];

            new Random().NextBytes((data));

            byte[] Md5 = md5.ComputeHash(data);
        }

        // метод без параметров
        [MyTest]
        public void Test3()
        {
            var md5 = MD5.Create();
            var data = new byte[100];

            new Random().NextBytes((data));

            byte[] Md5 = md5.ComputeHash(data);
        }


    }
}
