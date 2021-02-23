using System.Threading.Tasks;
using TagSDK.Models.Receivable.Settlement;
using TagSDK.Models.Request;
using TagSDK.Models.Response;

namespace TagSDK.Services.Receivable.Settlement
{
    public interface ISettlementService
    {
        Task<SettlementResponse> ReportSettlement(SettlementRequest receivableSettlement);
        Task<BaseResponse> RejectSettlement(SettlementRejectRequest receivableSettlement);
        Task<SettlementQueryResponse> GetSettlementByKey(string key);
        Task<SettlementPaginatedQueryResponse> GetSettlementByProcessKey(string processKey, Pagination pagination);
        Task<SettlementPaginatedQueryResponse> GetSettlementByReference(string reference, Pagination pagination);
        Task<SettlementPaginatedQueryResponse> GetSettlementWithParams(SettlementQueryFilter settlementParams, Pagination pagination);
    }
}
