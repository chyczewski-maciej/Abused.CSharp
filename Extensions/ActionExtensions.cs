using System;

namespace AbusedCSharp.Extensions
{
    public static class ActionExtensions
    {
        public static Func<T1, Action> Curry<T1>(this Action<T1> func) => (T1 t1) => () => func(t1);
        public static Func<T2, Func<T1, Action>> Curry<T1, T2>(this Action<T1, T2> func) => (T2 arg2) => (T1 arg1) => () => func(arg1, arg2);
        public static Func<T3, Func<T2, Func<T1, Action>>> Curry<T1, T2, T3>(this Action<T1, T2, T3> func) => (T3 arg3) => (T2 arg2) => (T1 arg1) => () => func(arg1, arg2, arg3);
        public static Func<T4, Func<T3, Func<T2, Func<T1, Action>>>> Curry<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> func) => (T4 arg4) => (T3 arg3) => (T2 arg2) => (T1 arg1) => () => func(arg1, arg2, arg3, arg4);

        public static Action Apply<T1>(this Action<T1> func, T1 arg1) => () => func(arg1);
        public static Action<T1> Apply<T1, T2>(this Action<T1, T2> func, T2 arg2) => (T1 arg1) => func(arg1, arg2);
        public static Action<T1, T2> Apply<T1, T2, T3>(this Action<T1, T2, T3> func, T3 arg3) => (T1 arg1, T2 arg2) => func(arg1, arg2, arg3);
        public static Action<T1, T2, T3> Apply<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> func, T4 arg4) => (T1 arg1, T2 arg2, T3 arg3) => func(arg1, arg2, arg3, arg4);
    }
}
