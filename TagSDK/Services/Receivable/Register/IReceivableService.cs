using System.Threading.Tasks;
using TagSDK.Models.Receivable.Register;

namespace TagSDK.Services.Receivable.Register
{
    public interface IReceivableService
    {
        Task<ReceivableResponse> RegisterReceivable(ReceivableRequest receivableInput);
    }
}
