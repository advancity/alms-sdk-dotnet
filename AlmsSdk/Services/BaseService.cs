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

    internal class BaseService : IService
    {
        #region Constances

        public AuthConfig config { get; set; }
        public RestClient client { get; set; }
        public Error LastError { get; set; }
        public DateTimeOffset RequestDate;

        #endregion

        #region Ctor

        public BaseService(AuthConfig authConfig, string baseApiURI)
        {
            config = authConfig;
            client = new RestClient(baseApiURI);

            setClientHeaders();
        }

        #endregion

        #region SpecialMethods

        private void setClientHeaders()
        {
            RequestDate = DateTimeOffset.UtcNow;
            client.AddDefaultHeader("Authorization", string.Format("alms-token apiAccessKey={0}, nonce={1}", config.ApiAccessKey, Utilities.GenerateNonce(config, RequestDate)));
            client.AddDefaultHeader("Date", RequestDate.ToString());
        }

        protected void setError(IRestResponse response)
        {
            LastError = new Error()
            {
                ErrorCode = response.StatusCode.GetHashCode(),
                ErrorMessage = response.StatusDescription
            };
        }

        #endregion
    }
}
