using RestSharp;

namespace TagSDK.Commands
{
    public class ResponseCommand { }

    public class ResponseCommand<T> : ResponseCommand
    {
        public IRestResponse<T> Response { get; set; }
    }
}
