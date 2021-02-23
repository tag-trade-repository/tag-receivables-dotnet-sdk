using System.Collections.Generic;
using TagSDK.Models.Authentication;
using TagSDK.Models.Enums;

namespace TagSDK
{
    public class SDKOptions
    {
        public string BaseUrl { get; set; }
        public Polly.AsyncPolicy DefaultPolicy { get; set; }

        private readonly Dictionary<Profile, TokenRequest> _credentials = new Dictionary<Profile, TokenRequest>();

        public TokenRequest GetCredential(Profile profile)
        {
            return _credentials[profile];
        }

        public void SetCredential(TokenRequest tokenInput, Profile profile)
        {
            _credentials[profile] = tokenInput;
        }
    }
}
