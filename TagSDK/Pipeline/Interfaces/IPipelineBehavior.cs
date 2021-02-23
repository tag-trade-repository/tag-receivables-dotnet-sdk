using TagSDK.Commands;

namespace TagSDK.Pipeline.Interfaces
{
    internal interface IPipelineBehavior<TIn, TOut>
    {
        IFilter<RequestCommand<TIn, TOut>, ResponseCommand<TOut>> GetPipiline();
    }
}
