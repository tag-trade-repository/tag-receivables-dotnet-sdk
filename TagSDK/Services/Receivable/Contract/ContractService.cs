using RestSharp;
using System;
using System.Threading.Tasks;
using TagSDK.Extensions;
using TagSDK.Models.Enums;
using TagSDK.Models.Receivable.Contract;
using TagSDK.Models.Request;
using TagSDK.Utils;

namespace TagSDK.Services.Receivable.Contract
{
    public class ContractService : BaseService, IContractService
    {
        private const string _pathBase = Constants.Constants.Endorsement.Contract.BasePath;
        private const string _pathBaseHistory = Constants.Constants.Endorsement.Contract.BasePathHistory;
        private const string _pathBaseKey = Constants.Constants.Endorsement.Contract.BasePathKey;
        private const string _pathBaseProcessKey = Constants.Constants.Endorsement.Contract.BasePathProcessKey;
        private const string _pathBaseReference = Constants.Constants.Endorsement.Contract.BasePathReference;
        private readonly Profile _baseProfile = Profile.CREDITOR;

        public ContractService(IServiceProvider serviceProvider, SDKOptions options) : base(serviceProvider, options) { }

        public async Task<ContractResponse> InsertContract(ContractRequest contract)
        {
            var request = new RestRequest($"{Options.BaseUrl}/{_pathBase}", DataFormat.Json)
            {
                Method = Method.POST
            };
            request.AddJsonBody(contract);

            return await GetPipeline<ContractResponse>().Execute(new Commands.RequestCommand<ContractResponse>()
            {
                Model = contract,
                RestRequest = request,
                Profile = _baseProfile
            }).MapResponse();
        }

        public async Task<ContractPaginatedQueryResponse> ListContractsByReference(string reference, Pagination page)
        {
            var path = $"{Options.BaseUrl}/{_pathBaseReference}/{reference}";
            var queryParams = new CustomQueryParams().ReturnQueryParams(page);
            var request = new RestRequest($"{path}{queryParams}", DataFormat.Json)
            {
                Method = Method.GET
            };

            return await GetPipeline<ContractPaginatedQueryResponse>().Execute(new Commands.RequestCommand<ContractPaginatedQueryResponse>()
            {
                RestRequest = request,
                Profile = _baseProfile
            }).MapResponse();
        }

        public async Task<ContractPaginatedQueryResponse> ListContractsByKey(string key)
        {
            var request = new RestRequest($"{Options.BaseUrl}/{_pathBaseKey}/{key}", DataFormat.Json)
            {
                Method = Method.GET
            };

            return await GetPipeline<ContractPaginatedQueryResponse>().Execute(new Commands.RequestCommand<ContractPaginatedQueryResponse>()
            {
                RestRequest = request,
                Profile = _baseProfile
            }).MapResponse();
        }

        public async Task<ContractPaginatedQueryResponse> ListContractsByProcessKey(string processKey, Pagination page)
        {
            var path = $"{Options.BaseUrl}/{ _pathBaseProcessKey}/{processKey}";
            var queryParams = new CustomQueryParams().ReturnQueryParams(page);
            var request = new RestRequest($"{path}{queryParams}", DataFormat.Json)
            {
                Method = Method.GET
            };

            return await GetPipeline<ContractPaginatedQueryResponse>().Execute(new Commands.RequestCommand<ContractPaginatedQueryResponse>()
            {
                RestRequest = request,
                Profile = _baseProfile
            }).MapResponse();
        }

        public async Task<ContractPaginatedQueryResponse> ListContractsWithParams(ContractQueryFilter contractFilter, Pagination page)
        {
            var pathRequest = $"{Options.BaseUrl}/{_pathBase}";

            var queryParams = new CustomQueryParams().ReturnQueryParams(contractFilter, page);
            if (!string.IsNullOrEmpty(queryParams))
            {
                pathRequest = $"{pathRequest}{queryParams}";
            }

            var request = new RestRequest(pathRequest, DataFormat.Json);

            return await GetPipeline<ContractPaginatedQueryResponse>().Execute(new Commands.RequestCommand<ContractPaginatedQueryResponse>()
            {
                RestRequest = request,
                Profile = _baseProfile
            }).MapResponse();
        }

        public async Task<ContractHistoryResponse> GetContractHistoryWithKey(string key)
        {
            var request = new RestRequest($"{Options.BaseUrl}/{_pathBaseHistory}?key={key}", DataFormat.Json);
            return await GetPipeline<ContractHistoryResponse>().Execute(new Commands.RequestCommand<ContractHistoryResponse>()
            {
                RestRequest = request,
                Profile = _baseProfile
            }).MapResponse();
        }
    }
}




