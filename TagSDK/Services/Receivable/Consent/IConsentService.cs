using System.Threading.Tasks;
using TagSDK.Models.Enums;
using TagSDK.Models.Receivable.Consent;
using TagSDK.Models.Response;

namespace TagSDK.Services.Receivable.Consent
{
    public interface IConsentService
    {
        Task<ConsentResponse> InsertConsents(ConsentRequest optInRequest, Profile profile);
        Task<BaseResponse> RejectOptIn(ConsentRejectRequest optInRejInput, Profile profile);
        Task<BaseResponse> PatchOptOut(string key);
        Task<BaseResponse> ChangeOptInValidityDate(string key, ConsentValidityChangeRequest optInVChange, Profile profile);
        Task<ConsentQueryResponse> GetOptInWithKey(string key);
        Task<ConsentQueryParameterizedResponse> GetOptInWithParams(ConsentQueryFilter consentQueryFilter);
    }
}
