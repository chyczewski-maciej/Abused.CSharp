using AbusedCSharp.Extensions.TaskExtensions;
using System;
using System.Threading.Tasks;

namespace AbusedCSharp.Playground
{
    public static class Program
    {
        static async Task Main(String[] args)
        {
            Console.WriteLine("Hello World!");

            (Int32 number, String text) = await (GetIntAsync(), GetStringAsync());

            Console.WriteLine($"{number}:{text}");
        }

        public static async Task<Int32> GetIntAsync()
        {
            await Task.Delay(200);
            return 5;
        }

        public static async Task<String> GetStringAsync()
        {
            await Task.Delay(1200);
            return "Five";
        }
    }
}
