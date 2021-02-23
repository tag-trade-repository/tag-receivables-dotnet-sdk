using System;
using Polly;
using System.Threading.Tasks;
using RestSharp;
using TagSDK.Commands;
using TagSDK.Authorization;
using TagSDK.Models.Enums;

namespace TagSDK.Pipeline
{
    public class RequestMidleware<T, T2> : Filter<RequestCommand<T, T2>, ResponseCommand<T2>>
    {

        protected IRestClient RestClient;
        protected IRestRequest Request;
        protected IAuthorizator Authorizator;

        public RequestMidleware(IRestClient restClient, IAuthorizator authorizator)
        {
            RestClient = restClient;
            Authorizator = authorizator;
        }

        protected override async Task<ResponseCommand<T2>> Execute(RequestCommand<T, T2> context, Func<RequestCommand<T, T2>, Task<ResponseCommand<T2>>> next)
        {
            Request = context.RestRequest;
            var profile = context.Profile;

            Polly.AsyncPolicy<IRestResponse<T2>> policy = Policy.NoOpAsync<IRestResponse<T2>>();

            if (context.Authenticate)
            {
                policy = context.CustomPolicy ?? Policy.NoOpAsync<IRestResponse<T2>>();

                Polly.AsyncPolicy<IRestResponse<T2>> mainPolicy = Policy
                    .HandleResult<IRestResponse<T2>>(resp => resp.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    .RetryAsync(
                        retryCount: 1,
                        onRetryAsync: async (result, retryNumber, ctx) => await GetAuthorizationTokenAsync(profile, true)
                        );

                policy = mainPolicy.WrapAsync(policy);


                await GetAuthorizationTokenAsync(profile);
            }

            var response = await policy.ExecuteAsync(async () => await RestClient.ExecuteAsync<T2>(context.RestRequest));

            var responseCommand = new ResponseCommand<T2>
            {
                Response = response
            };

            return responseCommand;
        }

        protected async Task GetAuthorizationTokenAsync(Profile profile, bool refresh = false)
        {
            var token = await Authorizator.GetToken(profile, refresh);

            Request.AddHeader("Authorization", $"Bearer {token}");
        }
    }
}
