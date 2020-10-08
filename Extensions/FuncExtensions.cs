using System;

namespace AbusedCSharp.Extensions
{
  public static class FuncExtensions
  {
    public static Func<T1, Func<TResult>> Curry<T1, TResult>(this Func<T1, TResult> func) => (T1 t1) => () => func(t1);
    public static Func<T2, Func<T1, Func<TResult>>> Curry<T1, T2, TResult>(this Func<T1, T2, TResult> func) => (T2 arg2) => (T1 arg1) => () => func(arg1, arg2);
    public static Func<T3, Func<T2, Func<T1, Func<TResult>>>> Curry<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func) => (T3 arg3) => (T2 arg2) => (T1 arg1) => () => func(arg1, arg2, arg3);
    public static Func<T4, Func<T3, Func<T2, Func<T1, Func<TResult>>>>> Curry<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func) => (T4 arg4) => (T3 arg3) => (T2 arg2) => (T1 arg1) => () => func(arg1, arg2, arg3, arg4);

    public static Func<TResult> Apply<T1, TResult>(this Func<T1, TResult> func, T1 arg1) => () => func(arg1);
    public static Func<T1, TResult> Apply<T1, T2, TResult>(this Func<T1, T2, TResult> func, T2 arg2) => (T1 arg1) => func(arg1, arg2);
    public static Func<T1, T2, TResult> Apply<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func, T3 arg3) => (T1 arg1, T2 arg2) => func(arg1, arg2, arg3);
    public static Func<T1, T2, T3, TResult> Apply<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func, T4 arg4) => (T1 arg1, T2 arg2, T3 arg3) => func(arg1, arg2, arg3, arg4);

    public static Func<T2> Map<T1, T2>(this Func<T1> func, Func<T1, T2> map) => () => map(func());
    public static Func<T1, TResult2> Map<T1, TResult, TResult2>(this Func<T1, TResult> func, Func<TResult, TResult2> map) => (T1 arg1) => map(func(arg1));
    public static Func<T1, T2, T3, TResult2> Map<T1, T2, T3, TResult, TResult2>(this Func<T1, T2, T3, TResult> func, Func<TResult, TResult2> map) => (T1 arg1, T2 arg2, T3 arg3) => map(func(arg1, arg2, arg3));
    public static Func<T1, T2, T3, T4, TResult2> Map<T1, T2, T3, T4, TResult, TResult2>(this Func<T1, T2, T3, T4, TResult> func, Func<TResult, TResult2> map) => (T1 arg1, T2 arg2, T3 arg3, T4 arg4) => map(func(arg1, arg2, arg3, arg4));
  }
}
