using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace TagSDK.Exceptions
{
    [Serializable]
    public class TagSDKException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public ResponseError Error { get; set; }

        public TagSDKException() { }

        public TagSDKException(string message)
            : base(message) { }

        public TagSDKException(HttpStatusCode statusCode)
            : base(statusCode.ToString())
        {
            StatusCode = statusCode;
        }

        public TagSDKException(string message, Exception inner)
            : base(message, inner) { }

        public TagSDKException(string message, HttpStatusCode statusCode, ResponseError error)
            : this(message)
        {
            StatusCode = statusCode;
            Error = error;
        }

        public TagSDKException(string message, HttpStatusCode statusCode)
           : this(message)
        {
            StatusCode = statusCode;
        }
        public class ResponseError
        {
            [JsonProperty("errors")]
            public List<string> Errors { get; set; }

            [JsonProperty("error")]
            private List<string> AltErrors { set => Errors = value; }

            [JsonProperty("processKey")]
            public string ProcessKey { get; set; }

            [JsonProperty("processkey")]
            private string AltProcessKey { set => ProcessKey = value; }

            [JsonProperty("createdAt")]
            public DateTime? CreatedAt { get; set; }

            [JsonProperty("createdDate")]
            private DateTime? AltCreatedAt { set => CreatedAt = value; }
        }
    }
}
