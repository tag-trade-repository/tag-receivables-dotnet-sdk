using RestSharp;
using System;
using System.Threading.Tasks;
using TagSDK.Extensions;
using TagSDK.Models.Enums;
using TagSDK.Models.Receivable.Reconciliation;

namespace TagSDK.Services.Receivable.Reconciliation
{
    public class ReconciliationService : BaseService, IReconciliationService
    {
        private const string _pathBaseKey = Constants.Constants.Reconciliation.BasePathKey;
        private const string _pathBase = Constants.Constants.Reconciliation.BasePath;
        private readonly Profile _baseProfile = Profile.ACQUIRER;

        public ReconciliationService(IServiceProvider serviceProvider, SDKOptions options) : base(serviceProvider, options) { }

        public async Task<ReconciliationConfirmationResponse> ConfirmReconciliation(string reconciliationKey, ReconciliationConfirmationRequest recConfirmationInput)
        {
            var pathRequest = $"{Options.BaseUrl}/{_pathBaseKey}/{reconciliationKey}";
            var request = new RestRequest(pathRequest, DataFormat.Json)
            {
                Method = Method.PATCH
            };
            request.AddJsonBody(recConfirmationInput);

            return await GetPipeline<ReconciliationConfirmationResponse>().Execute(new Commands.RequestCommand<ReconciliationConfirmationResponse>()
            {
                Model = recConfirmationInput,
                RestRequest = request,
                Profile = _baseProfile
            }).MapResponse();
        }

        public async Task<ReconciliationQueryResponse> GetReconciliationWithKey(string reconciliationKey)
        {
            var pathRequest = $"{Options.BaseUrl}/{_pathBaseKey}/{reconciliationKey}";

            var request = new RestRequest(pathRequest, DataFormat.Json);

            return await GetPipeline<ReconciliationQueryResponse>().Execute(new Commands.RequestCommand<ReconciliationQueryResponse>()
            {
                RestRequest = request,
                Profile = _baseProfile
            }).MapResponse();
        }

        public async Task<ReconciliationResponse> InsertConciliation(ReconciliationRequest reconciliationInput)
        {

            var request = new RestRequest($"{Options.BaseUrl}/{_pathBase}", DataFormat.Json)
            {
                Method = Method.POST
            };
            request.AddJsonBody(reconciliationInput);

            return await GetPipeline<ReconciliationResponse>().Execute(new Commands.RequestCommand<ReconciliationResponse>()
            {
                Model = reconciliationInput,
                RestRequest = request,
                Profile = _baseProfile
            }).MapResponse();
        }
    }
}
