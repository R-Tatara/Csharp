using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //引数なし、戻り値なし、１行のとき
            Action test1 = () => Console.WriteLine("Hi.");

            //引数なし、戻り値なし、複数行のとき
            Action test2 = () =>
            {
                Console.WriteLine("Hi.");
                Console.WriteLine("Hi.");
            };

            //引数１個、戻り値なし
            Action<string> test3 = (s) => Console.WriteLine(s);

            //引数２個、戻り値なし
            Action<string, string> test4 = (s, t) => Console.WriteLine(s + t);

            //引数なし、戻り値あり
            Func<int> test5 = () =>
            {
                return 0;
            };
            //Func<int> test5 = () => 0; //同じ意味

            //引数１個、戻り値あり
            Func<string, int> test6 = (s) =>
            {
                Console.WriteLine(s);
                return 0;
            };

            //引数２個、戻り値あり
            Func<string, string, int> test7 = (s, t) =>
            {
                Console.WriteLine(s + t);
                return 0;
            };

            test1();
            test2();
            test3("hoge");
            test4("hoge", "fuga");
            Console.WriteLine(test5());
            Console.WriteLine(test6("hoge"));
            Console.WriteLine(test7("hoge", "fuga"));
        }
    }
}
