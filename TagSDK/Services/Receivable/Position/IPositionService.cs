using System.Threading.Tasks;
using TagSDK.Models.Receivable.Position;

namespace TagSDK.Services.Receivable.Position
{
    public interface IPositionService
    {
        Task<PositionReceivablesQueryResponse> GetPositionsWithKey(string key);
        Task<PositionReceivablesQueryResponse> GetPositionsWithReference(string reference);
        Task<PositionReceivablesQueryResponse> GetPositionsWithProcessReference(string processReference);
        Task<PositionReceivablesQueryResponse> GetPositionsWithOriginalAssetHolder(string originalAssetHolder, PositionQueryFilter paramsObj);
        Task<PositionExpectationQueryResponse> GetPositionsWithAssetHolder(string assetHolder, PositionQueryFilter paramsObj);
    }
}
