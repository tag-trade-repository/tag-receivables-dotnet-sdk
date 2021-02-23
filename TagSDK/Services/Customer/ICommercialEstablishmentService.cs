using System.Threading.Tasks;
using TagSDK.Models.Customer;
using TagSDK.Models.Request;
using TagSDK.Models.Response;

namespace TagSDK.Services.Interfaces
{
    public interface ICommercialEstablishmentService
    {
        Task<CommercialEstablishmentResponse> RegisterCommercialEstablishments(CommercialEstablishmentRequest cEstablishmentReq);
        Task<BaseResponse> UpdateCommercialEstablishments(string docNumber, CommercialEstablishmentUpdateRequest cEstablishmentReq);
        Task<CommercialEstablishmentPaginatedQueryResponse> GetCommercialEstablishmentsWithPagination(Pagination pagination);
        Task<CommercialEstablishmentResponse> GetCommercialEstablishmentsWithDocumentNumber(string documentNumber);
    }
}
