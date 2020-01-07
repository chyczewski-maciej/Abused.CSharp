using System;
using System.Threading.Tasks;

namespace Extensions.UnitTests.TestExtensions
{
    public static class BddExtensions
    {
        public static T Do<T>(this T value, Action<T> action)
        {
            action(value);
            return value;
        }

        public static async Task<T> Do<T>(this T value, Func<T, Task> action)
        {
            await action(value);
            return value;
        }
        public static async Task<TOut> Bind<TIn, TOut>(this Task<TIn> task, Func<TIn, Task<TOut>> bind)
        {
            return await bind(await task);
        }

        public static Task<T> Do<T>(this Task<T> task, Action<T> action) => task.Map(value => { action(value); return value; });

        public static TOut Map<TIn, TOut>(this TIn value, Func<TIn, TOut> func) => func(value);
        public static async Task<TOut> Map<TIn, TOut>(this Task<TIn> task, Func<TIn, TOut> func) => func(await task);


        public static T Given<T>(T value) => value;
        public static T Given<T>(Func<T> f) => f();

        public static T Where<T>(this T t, Action<T> a) => t.Do(a);

        public static T When<T>(this T t, Action<T> a) => t.Do(a);
        public static TOut When<TIn, TOut>(this TIn t, Func<TIn, TOut> f) => t.Map(f);
        public static Task<T> When<T>(this Task<T> t, Action<T> a) => t.Do(a);
        public static Task<TOut> When<TIn, TOut>(this Task<TIn> t, Func<TIn, TOut> a) => t.Map(a);
        public static T AndWhen<T>(this T t, Action<T> a) => t.Do(a);
        public static T Then<T>(this T t, Action<T> a) => t.Do(a);
        public static Task<T> Then<T>(this T t, Func<T, Task> a) => t.Do(a);
        public static Task<TOut> Then<TIn, TOut>(this Task<TIn> task, Func<TIn, Task<TOut>> binder) => task.Bind(binder);
        public static Task<T> Then<T>(this Task<T> task, Action<T> a) => task.Do(a);
        public static T AndThen<T>(this T t, Action<T> a) => t.Do(a);
    }
}
