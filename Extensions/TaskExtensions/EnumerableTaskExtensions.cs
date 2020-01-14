using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AbusedCSharp.Extensions.TaskExtensions
{
    public static class EnumerableTaskExtensions
    {
        public static async Task<T[]> WhenAll<T>(this IEnumerable<Task<T>> tasks, Int32 degreeOfParallelism = 32, CancellationToken cancellationToken = default)
        {
            using (SemaphoreSlim semaphoreSlim = new SemaphoreSlim(degreeOfParallelism))
            using (IEnumerator<Task<T>> enumerator = tasks.GetEnumerator())
            {
                List<Task<T>> runningTasks = new List<Task<T>>();

                do
                {
                    await semaphoreSlim.WaitAsync();
                    cancellationToken.ThrowIfCancellationRequested();
                    if (!enumerator.MoveNext())
                        break;
                    runningTasks.Add(RunTaskAsync(enumerator.Current));
                }
                while (true);

                return await Task.WhenAll(runningTasks);

                async Task<T> RunTaskAsync(Task<T> task)
                {
                    try
                    {
                        return await task;
                    }
                    finally
                    {
                        semaphoreSlim.Release();
                    }
                }
            }
        }
    }
}
