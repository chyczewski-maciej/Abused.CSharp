using AbusedCSharp.Extensions;
using System;
using System.Threading.Tasks;

namespace AbusedCSharp.Playground
{
    public static class Program
    {
        static async Task Main(String[] args)
        {
            Func<int, int> f = x => x;
            int y = f.Curry()(5)();
            Console.WriteLine(y);
            Console.WriteLine(y);
        }
    }
}
