using System;
using System.Threading.Tasks;

namespace AbusedCSharp.Extensions
{


    public static class TaskFunc
    {

        public static Func<Task<TResult>> Return<TResult>(TResult value) => () => Task.FromResult(value);
        public static Func<T1, Task<TResult>> Return<T1, TResult>(Func<T1, TResult> f) => (T1 t1) => Task.FromResult(f(t1));
        public static Func<T1, T2, Task<TResult>> Return<T1, T2, TResult>(Func<T1, T2, TResult> f) => (T1 t1, T2 t2) => Task.FromResult(f(t1, t2));

        public static async Task IterAsync<TResult>(this Func<Task<TResult>> async, Func<TResult, Task> action) => await action(await async());
        public static async Task Iter<TResult>(this Func<Task<TResult>> async, Action<TResult> action) => action(await async());

        public static Func<T1, Task<TResult>> Map<T1, T2, TResult>(this Func<T1, Task<T2>> f, Func<T2, TResult> map)
        {
            return async (T1 t1) => map(await f(t1));
        }

        public static Func<T1, Task<TResult>> Bind<T1, T2, TResult>(this Func<T1, Task<T2>> f, Func<T2, Task<TResult>> map)
        {
            return async (T1 input) => await map(await f(input));
        }

        public static Func<Task<TResult>> Apply<T1, TResult>(this Func<T1, Task<TResult>> f, T1 value) => () => f(value);
        public static Func<Task<TResult>> Apply<T1, TResult>(this Func<T1, Task<TResult>> f, Func<Task<T1>> value)
            => async () => await f(await value());
        public static Func<T1, Task<TResult>> Apply<T1, T2, TResult>(this Func<T1, T2, Task<TResult>> f, Func<Task<T2>> value)
            => async (T1 t1) => await f(t1, await value());


        public static Func<T1, Task<TResult>> Apply<T1, T2, TResult>(this Func<T1, T2, Task<TResult>> f, T2 value)
        {
            return (T1 v) => f(v, value);
        }

        public static Func<T1, T2, Task<TResult>> Apply<T1, T2, T3, TResult>(this Func<T1, T2, T3, Task<TResult>> f, T3 value)
        {
            return (T1 v1, T2 v2) => f(v1, v2, value);
        }

        public static Func<T1, T2, T3, Task<TResult>> Apply<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, Task<TResult>> f, T4 value)
        {
            return (T1 v1, T2 v2, T3 v3) => f(v1, v2, v3, value);
        }
    }
}