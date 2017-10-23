using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBenchmark
{
    public class MyTestAttribute: Attribute
    {
        public int TestCount{ get; set; }

        //public MyTestAttribute()
        //{
        //    TestCount = 100;
        //}

        public MyTestAttribute(int count = 100)
        {
            TestCount = count;
        }
    }
}
