using System;
using TagSDK.Commands;
using TagSDK.Pipeline.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace TagSDK.Pipeline
{
    public class PipelineDefaultBehavior<TIn, TOut> : IPipelineBehavior<TIn, TOut>
    {
        protected readonly IServiceProvider Provider;
        public PipelineDefaultBehavior(IServiceProvider provider)
        {
            Provider = provider;
        }

        public IFilter<RequestCommand<TIn, TOut>, ResponseCommand<TOut>> GetPipiline()
        {
            return new PipelineBuilder<RequestCommand<TIn, TOut>, ResponseCommand<TOut>>()
                .Register(Provider.GetService<LogMidleware<TIn, TOut>>())
                //.Register(this.provider.GetService<ValidateMidleware<TIn, TOut>>())
                .Register(Provider.GetService<RequestMidleware<TIn, TOut>>())
                .Build();

        }
    }
}
