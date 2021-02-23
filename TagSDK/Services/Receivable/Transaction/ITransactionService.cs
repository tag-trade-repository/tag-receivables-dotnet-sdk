using System.Threading.Tasks;
using TagSDK.Models.Receivable.Transaction;
using TagSDK.Models.Response;

namespace TagSDK.Services.Receivable.Transaction
{
    public interface ITransactionService
    {
        Task<TransactionQueryResponse> GetTransaction(string key);
        Task<BaseResponse> CreateTransactedUnitsReceivables(TransactionRequest transactionUnits);
        Task<BaseResponse> RectifyTransactedUnitsReceivables(TransactionRequest transactionUnits);
    }
}
