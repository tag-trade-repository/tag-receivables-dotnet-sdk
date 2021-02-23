using System.Threading.Tasks;
using TagSDK.Models.Receivable.Reconciliation;

namespace TagSDK.Services.Receivable.Reconciliation
{
    public interface IReconciliationService
    {
        Task<ReconciliationResponse> InsertConciliation(ReconciliationRequest reconciliationInput);
        Task<ReconciliationQueryResponse> GetReconciliationWithKey(string reconciliationKey);
        Task<ReconciliationConfirmationResponse> ConfirmReconciliation(string reconciliationKey, ReconciliationConfirmationRequest recConfirmationInput);
    }
}
