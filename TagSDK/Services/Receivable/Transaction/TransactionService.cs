using RestSharp;
using System;
using System.Threading.Tasks;
using TagSDK.Extensions;
using TagSDK.Models.Enums;
using TagSDK.Models.Receivable.Transaction;
using TagSDK.Models.Response;

namespace TagSDK.Services.Receivable.Transaction
{
    public class TransactionService : BaseService, ITransactionService
    {
        private const string _pathBase = Constants.Constants.Transaction.BasePathTransaction;
        private readonly Profile _baseProfile = Profile.ACQUIRER;

        public TransactionService(IServiceProvider serviceProvider, SDKOptions options) : base(serviceProvider, options) { }

        public async Task<BaseResponse> CreateTransactedUnitsReceivables(TransactionRequest transactionUnits)
        {
            var request = new RestRequest($"{Options.BaseUrl}/{_pathBase}", DataFormat.Json)
            {
                Method = Method.POST
            };
            request.AddJsonBody(transactionUnits);

            return await GetPipeline<BaseResponse>().Execute(new Commands.RequestCommand<BaseResponse>()
            {
                Model = transactionUnits,
                RestRequest = request,
                Profile = _baseProfile
            }).MapResponse();
        }

        public async Task<TransactionQueryResponse> GetTransaction(string key)
        {
            var request = new RestRequest($"{Options.BaseUrl}/{_pathBase}/{key}", DataFormat.Json);

            return await GetPipeline<TransactionQueryResponse>().Execute(new Commands.RequestCommand<TransactionQueryResponse>()
            {
                RestRequest = request,
                Profile = _baseProfile
            }).MapResponse();
        }

        public async Task<BaseResponse> RectifyTransactedUnitsReceivables(TransactionRequest transactionUnits)
        {
            var request = new RestRequest($"{Options.BaseUrl}/{_pathBase}", DataFormat.Json)
            {
                Method = Method.PATCH
            };
            request.AddJsonBody(transactionUnits);

            return await GetPipeline<BaseResponse>().Execute(new Commands.RequestCommand<BaseResponse>()
            {
                Model = transactionUnits,
                RestRequest = request,
                Profile = _baseProfile
            }).MapResponse();
        }
    }
}
