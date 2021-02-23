using System.Threading.Tasks;
using TagSDK.Models.Receivable.Advancement;
using TagSDK.Models.Response;

namespace TagSDK.Services.Receivable.Advancement
{
    public interface IAdvancementService
    {
        Task<BaseResponse> InsertAdvancements(AdvancementRequest advancement);
    }
}
