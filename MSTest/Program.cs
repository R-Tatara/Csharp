using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class MyClass
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClass obj = new MyClass();
            int a = 1;
            int b = 2;
            int result;

            result = obj.Sum(a, b);
            Console.WriteLine(result);
        }
    }
}
