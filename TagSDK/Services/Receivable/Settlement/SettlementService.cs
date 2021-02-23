using System;
using RestSharp;
using System.Threading.Tasks;
using TagSDK.Extensions;
using TagSDK.Utils;
using TagSDK.Models.Receivable.Settlement;
using TagSDK.Models.Request;
using TagSDK.Models.Response;
using TagSDK.Models.Enums;

namespace TagSDK.Services.Receivable.Settlement
{
    public class SettlementService : BaseService, ISettlementService
    {
        private const string _path = Constants.Constants.Settlement.BasePath;
        private const string _pathReject = Constants.Constants.Settlement.BasePathReject;
        private const string _pathKey = Constants.Constants.Settlement.BasePathKey;
        private const string _pathProcessKey = Constants.Constants.Settlement.BasePathProcessKey;
        private const string _pathReference = Constants.Constants.Settlement.BasePathReference;
        private readonly Profile _baseProfile = Profile.ACQUIRER;

        public SettlementService(IServiceProvider serviceProvider, SDKOptions options) : base(serviceProvider, options) { }

        public async Task<SettlementPaginatedQueryResponse> GetSettlementWithParams(SettlementQueryFilter settlementParams, Pagination pagination)
        {
            var pathRequest = $"{Options.BaseUrl}/{_path}";
            var queryParams = new CustomQueryParams().ReturnQueryParams(settlementParams, pagination);

            if (!string.IsNullOrEmpty(queryParams))
            {
                pathRequest = $"{pathRequest}/{queryParams}";
            }

            var request = new RestRequest(pathRequest, DataFormat.Json);

            return await GetPipeline<SettlementPaginatedQueryResponse>().Execute(new Commands.RequestCommand<SettlementPaginatedQueryResponse>()
            {
                RestRequest = request,
                Profile = _baseProfile
            }).MapResponse();
        }

        public async Task<SettlementQueryResponse> GetSettlementByKey(string key)
        {
            var request = new RestRequest($"{Options.BaseUrl}/{_pathKey}/{key}", DataFormat.Json);

            return await GetPipeline<SettlementQueryResponse>().Execute(new Commands.RequestCommand<SettlementQueryResponse>()
            {
                RestRequest = request,
                Profile = _baseProfile
            }).MapResponse();
        }

        public async Task<SettlementPaginatedQueryResponse> GetSettlementByProcessKey(string processKey, Pagination pagination)
        {
            var queryParams = $"?processkey={processKey}";
            queryParams = new CustomQueryParams().ReturnQueryParams(queryParams, pagination);

            var request = new RestRequest($"{Options.BaseUrl}/{_pathProcessKey}{queryParams}", DataFormat.Json);

            return await GetPipeline<SettlementPaginatedQueryResponse>().Execute(new Commands.RequestCommand<SettlementPaginatedQueryResponse>()
            {
                RestRequest = request,
                Profile = _baseProfile
            }).MapResponse();
        }

        public async Task<SettlementPaginatedQueryResponse> GetSettlementByReference(string reference, Pagination pagination)
        {
            var queryParams = $"?reference={reference}";
            queryParams = new CustomQueryParams().ReturnQueryParams(queryParams, pagination);

            var request = new RestRequest($"{Options.BaseUrl}/{_pathReference}{queryParams}", DataFormat.Json);

            return await GetPipeline<SettlementPaginatedQueryResponse>().Execute(new Commands.RequestCommand<SettlementPaginatedQueryResponse>()
            {
                RestRequest = request,
                Profile = _baseProfile
            }).MapResponse();
        }

        public async Task<SettlementResponse> ReportSettlement(SettlementRequest receivableSettlement)
        {
            var request = new RestRequest($"{Options.BaseUrl}/{_path}", DataFormat.Json)
            {
                Method = Method.PATCH
            };
            request.AddJsonBody(receivableSettlement);

            return await GetPipeline<SettlementResponse>().Execute(new Commands.RequestCommand<SettlementResponse>()
            {
                Model = receivableSettlement,
                RestRequest = request,
                Profile = _baseProfile
            }).MapResponse();
        }

        public async Task<BaseResponse> RejectSettlement(SettlementRejectRequest receivableSettlement)
        {
            var request = new RestRequest($"{Options.BaseUrl}/{_pathReject}", DataFormat.Json)
            {
                Method = Method.PATCH
            };
            request.AddJsonBody(receivableSettlement);

            return await GetPipeline<BaseResponse>().Execute(new Commands.RequestCommand<BaseResponse>()
            {
                Model = receivableSettlement,
                RestRequest = request,
                Profile = _baseProfile
            }).MapResponse();
        }
    }
}
