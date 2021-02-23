using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TagSDK.Models.Authentication;
using TagSDK.Models.Enums;
using TagSDK.Services.Interfaces;

namespace TagSDK.Authorization
{
    public class DefaultAuthorizator : IAuthorizator
    {
        protected readonly IAuthenticateService AuthenticateService;
        protected readonly SDKOptions Options;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public DefaultAuthorizator(IAuthenticateService authenticateService, SDKOptions options)
        {
            AuthenticateService = authenticateService;
            Options = options;
        }

        private readonly Dictionary<Profile, string> _token = new Dictionary<Profile, string>();
        public async Task<string> GetToken(Profile profile, bool refresh = false)
        {
            try
            {
                await _semaphore.WaitAsync();

                if (refresh || !_token.ContainsKey(profile))
                {

                    var response = await AuthenticateService.GetToken(Options.GetCredential(profile));

                    _token[profile] = response.AccessToken;
                }
            }
            finally
            {
                _semaphore.Release();
            }

            return _token[profile];
        }
    }
}
