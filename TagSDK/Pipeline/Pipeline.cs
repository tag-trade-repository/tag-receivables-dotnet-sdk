using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace TagSDK.Pipeline
{
    public interface IFilter<TIn, TOut>
    {
        void Register(IFilter<TIn, TOut> filter);
        Task<TOut> Execute(TIn context);
    }

    public abstract class Filter<TIn, TOut> : IFilter<TIn, TOut>
    {
        private IFilter<TIn, TOut> _next;
        protected abstract Task<TOut> Execute(TIn context, Func<TIn, Task<TOut>> next);

        public void Register(IFilter<TIn, TOut> filter)
        {
            if (_next == null)
            {
                _next = filter;
            }
            else
            {
                _next.Register(filter);
            }
        }

        Task<TOut> IFilter<TIn, TOut>.Execute(TIn context)
        {
            return Execute(context, ctx => _next == null
                  ? Task.FromResult(default(TOut))
                  : _next.Execute(ctx));
        }
    }

    public class PipelineBuilder<T, TOut>
    {
        private readonly List<Func<IFilter<T, TOut>>> _filters = new List<Func<IFilter<T, TOut>>>();

        public PipelineBuilder<T, TOut> Register(Func<IFilter<T, TOut>> filter)
        {
            _filters.Add(filter);
            return this;
        }

        public PipelineBuilder<T, TOut> Register(IFilter<T, TOut> filter)
        {
            _filters.Add(() => filter);
            return this;
        }

        public IFilter<T, TOut> Build()
        {
            var root = _filters.First().Invoke();

            foreach (var filter in _filters.Skip(1))
            {
                root.Register(filter.Invoke());
            }

            return root;
        }
    }
}
