using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlmsSdk.Services
{
    using Domain;
    using ServiceContracts;
    using RestSharp;
    using AlmsSdk.Functions;
    using System.Globalization;

    internal class BaseService : IService
    {
        #region Constances

        protected AuthConfig Config { get; set; }
        protected RestClient Client { get; set; }
        public Error LastError { get; protected set; }
        public DateTimeOffset RequestDate;

        #endregion

        #region Ctor

        public BaseService(AuthConfig authConfig, string baseApiURI)
        {
            Config = authConfig;
            Client = new RestClient(baseApiURI);

            setClientHeaders();
        }

        #endregion

        #region SpecialMethods

        private void setClientHeaders()
        {
            RequestDate = DateTimeOffset.UtcNow;
            Client.AddDefaultHeader("Authorization", string.Format("alms-token apiAccessKey={0}, nonce={1}", Config.ApiAccessKey, Utilities.GenerateNonce(Config, RequestDate)));
            Client.AddDefaultHeader("Date", RequestDate.ToString(CultureInfo.GetCultureInfo("en-US").DateTimeFormat.RFC1123Pattern));
        }

        protected void setError(IRestResponse response)
        {
            LastError = new Error()
            {
                ErrorCode = response.StatusCode.GetHashCode(),
                ErrorCodeString= response.StatusDescription
            };
            try
            {
                if(!string.IsNullOrEmpty(response.Content))
                    LastError.Message = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiErrorMessage>(response.Content).Message;
            }
            finally { }
        }

        #endregion
    }
}
