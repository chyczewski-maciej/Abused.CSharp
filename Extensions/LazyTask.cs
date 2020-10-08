using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AbusedCSharp.Extensions
{
    public class LazyTask<TResult>
    {
        private readonly Func<Task<TResult>> _taskFactory_;

        public LazyTask(Func<Task<TResult>> taskFactory)
        {
            _taskFactory_ = taskFactory;
        }

        public TaskAwaiter<TResult> GetAwaiter() => _taskFactory_().GetAwaiter();
        public Task<TResult> StartAsTask() => _taskFactory_();

        public LazyTask<TNewResult> Map<TNewResult>(Func<TResult, TNewResult> map) => new LazyTask<TNewResult>(async () => map(await this));
        public LazyTask<TNewResult> Bind<TNewResult>(Func<TResult, LazyTask<TNewResult>> map) => new LazyTask<TNewResult>(async () => await map(await this));
        public static LazyTask<TResult> Return(TResult result) => new LazyTask<TResult>(() => Task.FromResult(result));
    }

    public static class LazyTaskExtensions
    {
        public static LazyTask<T1, LazyTask<TResult>> Return<T1, TResult>(this Func<T1, Func<TResult>> f) => new LazyTask<T1, LazyTask<TResult>>(v1 => LazyTask<TResult>.Return(f(v1)()));

        public static LazyTask<T1, LazyTask<T2, LazyTask<TResult>>> Return<T1, T2, TResult>(this Func<T1, Func<T2, Func<TResult>>> f)
            => new LazyTask<T1, LazyTask<T2, LazyTask<TResult>>>(f.Map(LazyTaskExtensions.Return));


        public static LazyTask<TResult> Apply<T1, TResult>(this LazyTask<T1, LazyTask<TResult>> lazy, LazyTask<T1> arg1)
        {
            return new LazyTask<TResult>(async () =>
            {
                T1 value1 = await arg1.StartAsTask();
                return await (await lazy.StartAsTask(value1)).StartAsTask();
            });
        }

        public static LazyTask<T2, TResult> Apply<T1, T2, TResult>(this LazyTask<T1, LazyTask<T2, TResult>> lazy, LazyTask<T1> arg1)
        {
            return new LazyTask<T2, TResult>(async (T2 arg2) =>
            {
                T1 value1 = await arg1.StartAsTask();
                return await (await lazy.StartAsTask(value1)).StartAsTask(arg2);
            });
        }
    }

    public class LazyTask<T1, TResult>
    {
        private readonly Func<T1, Task<TResult>> _taskFactory_;

        public LazyTask(Func<T1, TResult> taskFactory)
        {
            _taskFactory_ = taskFactory.Map(Task.FromResult);
        }

        public LazyTask(Func<T1, Task<TResult>> taskFactory)
        {
            _taskFactory_ = taskFactory;
        }

        public LazyTask(Func<T1, LazyTask<TResult>> taskFactory)
        {
            _taskFactory_ = taskFactory.Map(async l => await l.StartAsTask());
        }

        public LazyTask<T1, TNewResult> Map<TNewResult>(Func<TResult, TNewResult> map)
        {
            return new LazyTask<T1, TNewResult>(async (T1 t1) => map(await _taskFactory_(t1)));
        }

        public Task<TResult> StartAsTask(T1 arg1) => _taskFactory_(arg1);
    }
}