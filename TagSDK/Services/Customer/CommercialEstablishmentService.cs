using RestSharp;
using System;
using System.Threading.Tasks;
using TagSDK.Extensions;
using TagSDK.Models.Customer;
using TagSDK.Models.Enums;
using TagSDK.Models.Request;
using TagSDK.Models.Response;
using TagSDK.Services.Interfaces;

namespace TagSDK.Services
{
    public class CommercialEstablishmentService : BaseService, ICommercialEstablishmentService
    {
        private readonly Profile _baseProfile = Profile.ACQUIRER;
        private const string _path = Constants.Constants.CommercialEstablishment.BasePath;

        public CommercialEstablishmentService(IServiceProvider serviceProvider, SDKOptions options) : base(serviceProvider, options) { }

        public async Task<CommercialEstablishmentResponse> RegisterCommercialEstablishments(CommercialEstablishmentRequest cEstablishmentReq)
        {
            var request = new RestRequest($"{Options.BaseUrl}/{_path}", DataFormat.Json)
            {
                Method = Method.POST
            };
            request.AddJsonBody(cEstablishmentReq);

            return await GetPipeline<CommercialEstablishmentResponse>().Execute(new Commands.RequestCommand<CommercialEstablishmentResponse>()
            {
                Model = cEstablishmentReq,
                RestRequest = request,
                Profile = _baseProfile
            }).MapResponse();
        }

        public async Task<CommercialEstablishmentPaginatedQueryResponse> GetCommercialEstablishmentsWithPagination(Pagination pagination)
        {
            var request = new RestRequest($"{Options.BaseUrl}/{_path}/?perPage={pagination.Limit}&currentPage={pagination.Page}", DataFormat.Json);

            return await GetPipeline<CommercialEstablishmentPaginatedQueryResponse>().Execute(new Commands.RequestCommand<CommercialEstablishmentPaginatedQueryResponse>()
            {
                RestRequest = request,
                Profile = _baseProfile
            }).MapResponse();
        }

        public async Task<CommercialEstablishmentResponse> GetCommercialEstablishmentsWithDocumentNumber(string documentNumber)
        {
            var request = new RestRequest($"{Options.BaseUrl}/{_path}/{documentNumber}", DataFormat.Json);

            return await GetPipeline<CommercialEstablishmentResponse>().Execute(new Commands.RequestCommand<CommercialEstablishmentResponse>()
            {
                RestRequest = request,
                Profile = _baseProfile
            }).MapResponse();
        }

        public async Task<BaseResponse> UpdateCommercialEstablishments(string docNumber, CommercialEstablishmentUpdateRequest cEstablishmentReq)
        {
            var request = new RestRequest($"{Options.BaseUrl}/{_path}/{docNumber}", DataFormat.Json)
            {
                Method = Method.GET
            };
            request.AddJsonBody(cEstablishmentReq);

            return await GetPipeline<BaseResponse>().Execute(new Commands.RequestCommand<BaseResponse>()
            {
                Model = cEstablishmentReq,
                RestRequest = request,
                Profile = _baseProfile
            }).MapResponse();
        }
    }
}
