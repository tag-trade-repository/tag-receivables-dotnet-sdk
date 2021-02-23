using RestSharp;
using System;
using System.Threading.Tasks;
using TagSDK.Extensions;
using TagSDK.Models.Enums;
using TagSDK.Models.Receivable.Advancement;
using TagSDK.Models.Response;

namespace TagSDK.Services.Receivable.Advancement
{
    public class AdvancementService : BaseService, IAdvancementService
    {
        private const string _pathBase = Constants.Constants.Endorsement.Advancement.BasePath;
        private readonly Profile _baseProfile = Profile.ACQUIRER;

        public AdvancementService(IServiceProvider serviceProvider, SDKOptions options) : base(serviceProvider, options) { }

        public async Task<BaseResponse> InsertAdvancements(AdvancementRequest advancement)
        {
            var request = new RestRequest($"{Options.BaseUrl}/{_pathBase}", DataFormat.Json)
            {
                Method = Method.POST
            };
            request.AddJsonBody(advancement);

            return await GetPipeline<BaseResponse>().Execute(new Commands.RequestCommand<BaseResponse>()
            {
                Model = advancement,
                RestRequest = request,
                Profile = _baseProfile
            }).MapResponse();
        }
    }
}
