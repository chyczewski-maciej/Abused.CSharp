using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AbusedCSharp.Extensions.TaskExtensions
{
    public static class AwaitTupleExtensions
    {
        public static TaskAwaiter<(T1, T2)> GetAwaiter<T1, T2>(this (Task<T1> task1, Task<T2> task2) tasks)
        {
            return AwaitValueTuple(tasks.task1, tasks.task2).GetAwaiter();

            async Task<(T1, T2)> AwaitValueTuple(Task<T1> t1, Task<T2> t2) => (await t1, await t2);
        }

        public static TaskAwaiter<(T1, T2, T3)> GetAwaiter<T1, T2, T3>(this (Task<T1> task1, Task<T2> task2, Task<T3> task3) tasks)
        {
            return AwaitValueTuple(tasks.task1, tasks.task2, tasks.task3).GetAwaiter();

            async Task<(T1, T2, T3)> AwaitValueTuple(Task<T1> t1, Task<T2> t2, Task<T3> t3) => (await t1, await t2, await t3);
        }

        public static TaskAwaiter<(T1, T2, T3, T4)> GetAwaiter<T1, T2, T3, T4>(this (Task<T1> task1, Task<T2> task2, Task<T3> task3, Task<T4> task4) tasks)
        {
            return AwaitValueTuple(tasks.task1, tasks.task2, tasks.task3, tasks.task4).GetAwaiter();

            async Task<(T1, T2, T3, T4)> AwaitValueTuple(Task<T1> t1, Task<T2> t2, Task<T3> t3, Task<T4> t4) => (await t1, await t2, await t3, await t4);
        }

        public static TaskAwaiter<(T1, T2, T3, T4, T5)> GetAwaiter<T1, T2, T3, T4, T5>(this (Task<T1> task1, Task<T2> task2, Task<T3> task3, Task<T4> task4, Task<T5> task5) tasks)
        {
            return AwaitValueTuple(tasks.task1, tasks.task2, tasks.task3, tasks.task4, tasks.task5).GetAwaiter();

            async Task<(T1, T2, T3, T4, T5)> AwaitValueTuple(Task<T1> t1, Task<T2> t2, Task<T3> t3, Task<T4> t4, Task<T5> t5) => (await t1, await t2, await t3, await t4, await t5);
        }

        public static TaskAwaiter<(T1, T2, T3, T4, T5, T6)> GetAwaiter<T1, T2, T3, T4, T5, T6>(this (Task<T1> task1, Task<T2> task2, Task<T3> task3, Task<T4> task4, Task<T5> task5, Task<T6> task6) tasks)
        {
            return AwaitValueTuple(tasks.task1, tasks.task2, tasks.task3, tasks.task4, tasks.task5, tasks.task6).GetAwaiter();

            async Task<(T1, T2, T3, T4, T5, T6)> AwaitValueTuple(Task<T1> t1, Task<T2> t2, Task<T3> t3, Task<T4> t4, Task<T5> t5, Task<T6> t6) => (await t1, await t2, await t3, await t4, await t5, await t6);
        }

        public static TaskAwaiter<(T1, T2, T3, T4, T5, T6, T7)> GetAwaiter<T1, T2, T3, T4, T5, T6, T7>(this (Task<T1> task1, Task<T2> task2, Task<T3> task3, Task<T4> task4, Task<T5> task5, Task<T6> task6, Task<T7> task7) tasks)
        {
            return AwaitValueTuple(tasks.task1, tasks.task2, tasks.task3, tasks.task4, tasks.task5, tasks.task6, tasks.task7).GetAwaiter();

            async Task<(T1, T2, T3, T4, T5, T6, T7)> AwaitValueTuple(Task<T1> t1, Task<T2> t2, Task<T3> t3, Task<T4> t4, Task<T5> t5, Task<T6> t6, Task<T7> t7) => (await t1, await t2, await t3, await t4, await t5, await t6, await t7);
        }
    }
}
