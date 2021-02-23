using TagSDK.Pipeline;
using TagSDK.Commands;
using System;
using Microsoft.Extensions.DependencyInjection;
using TagSDK.Pipeline.Interfaces;

namespace TagSDK.Services
{
    public abstract class BaseService
    {
        protected readonly IServiceProvider ServiceProvider;
        protected readonly SDKOptions Options;

        public BaseService(IServiceProvider serviceProvider, SDKOptions options)
        {
            ServiceProvider = serviceProvider;
            Options = options;
        }

        public IFilter<RequestCommand<object, TOut>, ResponseCommand<TOut>> GetPipeline<TOut>() =>
            GetPipeline<object, TOut>();

        public IFilter<RequestCommand<TIn, TOut>, ResponseCommand<TOut>> GetPipeline<TIn, TOut>() =>
            ServiceProvider.GetService<IPipelineBehavior<TIn, TOut>>().GetPipiline();
    }
}
