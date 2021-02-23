using System.Threading.Tasks;
using TagSDK.Models.Authentication;

namespace TagSDK.Services.Interfaces
{
    public interface IAuthenticateService
    {
        Task<TokenResponse> GetToken(TokenRequest model);
    }
}
