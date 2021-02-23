using Polly;
using RestSharp;
using TagSDK.Models.Enums;

namespace TagSDK.Commands
{
    public class RequestCommand<TResult> : RequestCommand<object, TResult> { }

    public class RequestCommand<TModel, TResult>
    {
        public bool Authenticate { get; set; } = true;
        public AsyncPolicy<IRestResponse<TResult>> CustomPolicy { get; set; }
        public IRestRequest RestRequest { get; set; }
        public Profile Profile { get; set; }
        public TModel Model { get; set; }
    }
}
