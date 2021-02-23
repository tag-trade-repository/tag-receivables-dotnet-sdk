using System;
using System.Threading.Tasks;
using TagSDK.Commands;
using System.Diagnostics;

namespace TagSDK.Pipeline
{
    public class LogMidleware<T, T2> : Filter<RequestCommand<T, T2>, ResponseCommand<T2>>
    {
        protected SDKOptions Options;

        public LogMidleware() { }

        protected override async Task<ResponseCommand<T2>> Execute(RequestCommand<T, T2> context, Func<RequestCommand<T, T2>, Task<ResponseCommand<T2>>> next)
        {
            var sw = Stopwatch.StartNew();

            var result = await next(context);

            sw.Stop();

            Console.WriteLine($"Chegou o request {context} e gerou o result {result.Response}, demorou {sw.Elapsed.TotalMilliseconds} milisegundos");

            return result;
        }
    }
}

