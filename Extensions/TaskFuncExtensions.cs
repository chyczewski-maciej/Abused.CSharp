using System;
using System.Threading.Tasks;

namespace AbusedCSharp.Extensions
{
    public static class TaskApplicativeFunctor
    {
        public static Task<Func<T1, TResult>> Return<T1, TResult>(Func<T1, TResult> func) => Task.FromResult(func);
        public static Task<Func<T1, T2, TResult>> Return<T1, T2, TResult>(Func<T1, T2, TResult> func) => Task.FromResult(func);

        public static async Task<TResult> Apply<T1, TResult>(this Task<Func<T1, TResult>> func, Task<T1> value) => (await func)(await value);

        public static async Task<Func<T1, TResult>> Apply<T1, T2, TResult>(this Task<Func<T1, T2, TResult>> func, Task<T2> value)
        {
            T2 v = await value;
            Func<T1, T2, TResult> f = await func;
            return (T1 t1) => f(t1, v);
        }
    }
}
