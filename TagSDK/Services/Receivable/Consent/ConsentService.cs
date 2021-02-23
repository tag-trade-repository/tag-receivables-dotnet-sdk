using System;
using RestSharp;
using System.Threading.Tasks;
using TagSDK.Extensions;
using TagSDK.Utils;
using TagSDK.Models.Receivable.Consent;
using TagSDK.Models.Response;
using TagSDK.Models.Enums;

namespace TagSDK.Services.Receivable.Consent
{
    public class ConsentService : BaseService, IConsentService
    {
        private const string _pathBaseOptIn = Constants.Constants.Consent.BasePathOptIn;
        private const string _basePathOptOut = Constants.Constants.Consent.BasePathOptOut;
        private const string _pathBaseParams = Constants.Constants.Consent.BasePathOptInParams;
        private const string _pathBaseOptInReject = Constants.Constants.Consent.BasePathOptInReject;
        private readonly Profile _baseProfile = Profile.CREDITOR;

        public ConsentService(IServiceProvider serviceProvider, SDKOptions options) : base(serviceProvider, options) { }

        public async Task<ConsentResponse> InsertConsents(ConsentRequest optInRequest, Profile profile)
        {
            var request = new RestRequest($"{Options.BaseUrl}/{_pathBaseOptIn}", DataFormat.Json)
            {
                Method = Method.POST
            };
            request.AddJsonBody(optInRequest);

            return await GetPipeline<ConsentResponse>().Execute(new Commands.RequestCommand<ConsentResponse>()
            {
                Model = optInRequest,
                RestRequest = request,
                Profile = profile
            }).MapResponse();

        }

        public async Task<BaseResponse> RejectOptIn(ConsentRejectRequest optInRejInput, Profile profile)
        {
            var request = new RestRequest($"{Options.BaseUrl}/{_pathBaseOptInReject}", DataFormat.Json)
            {
                Method = Method.POST
            };
            request.AddJsonBody(optInRejInput);

            return await GetPipeline<BaseResponse>().Execute(new Commands.RequestCommand<BaseResponse>()
            {
                Model = optInRejInput,
                RestRequest = request,
                Profile = profile
            }).MapResponse();

        }
        public async Task<BaseResponse> PatchOptOut(string key)
        {
            var request = new RestRequest($"{Options.BaseUrl}/{_basePathOptOut}/{key}", DataFormat.Json)
            {
                Method = Method.PATCH
            };

            return await GetPipeline<BaseResponse>().Execute(new Commands.RequestCommand<BaseResponse>()
            {
                RestRequest = request,
                Profile = _baseProfile
            }).MapResponse();

        }
        public async Task<BaseResponse> ChangeOptInValidityDate(string key, ConsentValidityChangeRequest optInVChange, Profile profile)
        {
            var request = new RestRequest($"{Options.BaseUrl}/{_pathBaseOptIn}/{key}", DataFormat.Json)
            {
                Method = Method.PATCH
            };
            request.AddJsonBody(optInVChange);

            return await GetPipeline<BaseResponse>().Execute(new Commands.RequestCommand<BaseResponse>()
            {
                Model = optInVChange,
                RestRequest = request,
                Profile = profile
            }).MapResponse();

        }
        public async Task<ConsentQueryResponse> GetOptInWithKey(string key)
        {
            var request = new RestRequest($"{Options.BaseUrl}/{_pathBaseOptIn}/{key}", DataFormat.Json)
            {
                Method = Method.GET
            };

            return await GetPipeline<ConsentQueryResponse>().Execute(new Commands.RequestCommand<ConsentQueryResponse>()
            {
                RestRequest = request,
                Profile = _baseProfile
            }).MapResponse();

        }
        public async Task<ConsentQueryParameterizedResponse> GetOptInWithParams(ConsentQueryFilter consentQueryFilter)
        {

            var pathRequest = $"{Options.BaseUrl}/{_pathBaseParams}";

            var queryParams = new CustomQueryParams().ReturnQueryParams(consentQueryFilter);
            if (!string.IsNullOrEmpty(queryParams))
            {
                pathRequest = $"{pathRequest}{queryParams}";
            }

            var request = new RestRequest(pathRequest, DataFormat.Json)
            {
                Method = Method.GET
            };

            return await GetPipeline<ConsentQueryParameterizedResponse>().Execute(new Commands.RequestCommand<ConsentQueryParameterizedResponse>()
            {
                RestRequest = request,
                Profile = _baseProfile
            }).MapResponse();

        }
    }
}
