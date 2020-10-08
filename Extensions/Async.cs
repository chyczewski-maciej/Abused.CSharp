using System;
using System.Threading.Tasks;

namespace AbusedCSharp.Extensions
{
    public class Async<TInput, TResult>
    {
        private readonly Func<TInput, Task<TResult>> _taskFactory_;

        public Async(Func<TInput, Task<TResult>> taskFactory)
        {
            _taskFactory_ = taskFactory;
        }

        public Async(Async<TInput, TResult> async)
        {
            _taskFactory_ = async._taskFactory_;
        }


        public Task<TResult> StartAsTask(TInput input) => _taskFactory_(input);
        public TResult RunSynchronously(TInput input) => _taskFactory_(input).GetAwaiter().GetResult();

        public Async<TInput, TResult2> Map<TResult2>(Func<TResult, TResult2> func) => new Async<TInput, TResult2>(_taskFactory_.Map(func));
        public Async<TInput, TResult2> Bind<TResult2>(Func<TResult, Task<TResult2>> func) => new Async<TInput, TResult2>(_taskFactory_.Bind(func));
        public Async<TInput, TResult2> Bind<TResult2>(Async<TResult, TResult2> async) => new Async<TInput, TResult2>(_taskFactory_.Bind(async._taskFactory_));
    }
}
