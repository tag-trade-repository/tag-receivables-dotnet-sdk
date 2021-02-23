using RestSharp;
using System;
using System.Threading.Tasks;
using TagSDK.Extensions;
using TagSDK.Models.Enums;
using TagSDK.Models.Receivable.Position;
using TagSDK.Utils;

namespace TagSDK.Services.Receivable.Position
{
    public class PositionService : BaseService, IPositionService
    {
        private const string _pathBaseKey = Constants.Constants.Position.BasePathKey;
        private const string _pathBaseAssetHolder = Constants.Constants.Position.BasePathAssetHolder;
        private const string _pathBaseOriginalAssetHolder = Constants.Constants.Position.BasePathOriginalAssetHolder;
        private const string _pathBaseProcessReference = Constants.Constants.Position.BasePathProcessReference;
        private const string _pathBaseReference = Constants.Constants.Position.BasePathReference;
        private readonly Profile _baseProfile = Profile.ACQUIRER;

        public PositionService(IServiceProvider serviceProvider, SDKOptions options) : base(serviceProvider, options) { }

        public async Task<PositionExpectationQueryResponse> GetPositionsWithAssetHolder(string assetHolder, PositionQueryFilter paramsObj)
        {
            var pathRequest = $"{Options.BaseUrl}/{_pathBaseAssetHolder}/{assetHolder}";


            var queryParams = new CustomQueryParams().ReturnQueryParams(paramsObj);
            if (!string.IsNullOrEmpty(queryParams))
            {
                pathRequest = $"{pathRequest}{queryParams}";
            }

            var request = new RestRequest(pathRequest, DataFormat.Json)
            {
                Method = Method.GET
            };

            return await GetPipeline<PositionExpectationQueryResponse>().Execute(new Commands.RequestCommand<PositionExpectationQueryResponse>()
            {
                RestRequest = request,
                Profile = _baseProfile
            }).MapResponse();

        }

        public async Task<PositionReceivablesQueryResponse> GetPositionsWithKey(string key)
        {
            var request = new RestRequest($"{Options.BaseUrl}/{_pathBaseKey}/{key}", DataFormat.Json);

            return await GetPipeline<PositionReceivablesQueryResponse>().Execute(new Commands.RequestCommand<PositionReceivablesQueryResponse>()
            {
                RestRequest = request,
                Profile = _baseProfile
            }).MapResponse();
        }

        public async Task<PositionReceivablesQueryResponse> GetPositionsWithOriginalAssetHolder(string originalAssetHolder, PositionQueryFilter paramsObj)
        {
            var pathRequest = $"{Options.BaseUrl}/{_pathBaseOriginalAssetHolder}";

            var queryParams = new CustomQueryParams().ReturnQueryParams(paramsObj);
            if (!string.IsNullOrEmpty(queryParams))
            {
                pathRequest = $"{pathRequest}/{originalAssetHolder}?{queryParams}";
            }

            var request = new RestRequest(pathRequest, DataFormat.Json)
            {
                Method = Method.GET
            };

            return await GetPipeline<PositionReceivablesQueryResponse>().Execute(new Commands.RequestCommand<PositionReceivablesQueryResponse>()
            {
                RestRequest = request,
                Profile = _baseProfile
            }).MapResponse();
        }

        public async Task<PositionReceivablesQueryResponse> GetPositionsWithProcessReference(string processReference)
        {

            var request = new RestRequest($"{Options.BaseUrl}/{_pathBaseProcessReference}/{processReference}", DataFormat.Json);

            return await GetPipeline<PositionReceivablesQueryResponse>().Execute(new Commands.RequestCommand<PositionReceivablesQueryResponse>()
            {
                RestRequest = request,
                Profile = _baseProfile
            }).MapResponse();
        }

        public async Task<PositionReceivablesQueryResponse> GetPositionsWithReference(string reference)
        {

            var request = new RestRequest($"{Options.BaseUrl}/{_pathBaseReference}/{reference}", DataFormat.Json);

            return await GetPipeline<PositionReceivablesQueryResponse>().Execute(new Commands.RequestCommand<PositionReceivablesQueryResponse>()
            {
                RestRequest = request,
                Profile = _baseProfile
            }).MapResponse();
        }
    }
}
