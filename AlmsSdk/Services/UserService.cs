using AlmsSdk.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AlmsSdk.Domain;
using RestSharp;
using Newtonsoft.Json;

namespace AlmsSdk.Services
{
    class UserService : IUserService
    {
        #region Constants

        private AuthConfig config = null;
        private RestClient client = null;
        public DateTimeOffset RequestDate;
        public Error LastError { get; private set; }

        #endregion

        #region Ctor

        public UserService(AuthConfig authConfig, string baseApiURI)
        {
            config = authConfig;
            client = new RestClient(baseApiURI);
        }

        #endregion

        #region Methods

        public User Get(string Username)
        {
            setClientHeaders();

            IRestRequest request = new RestRequest(string.Format("/api/user?username={0}", Username), Method.GET);
            IRestResponse response = client.Get<User>(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return (response as RestResponse<User>).Data;
            else { setError(response); return null; }
        }

        public IEnumerable<User> Search(string Keyword)
        {
            setClientHeaders();

            IRestRequest request = new RestRequest(string.Format("/api/user/search?keyword={0}", Keyword), Method.GET);
            IRestResponse response = client.Get<List<User>>(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return (response as RestResponse<List<User>>).Data;
            else { setError(response); return null; }
        }

        public bool Create(User User)
        {
            setClientHeaders();
            IRestRequest request = new RestRequest("/api/user", Method.POST);
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(User), ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = client.Post<bool>(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return true;
            else { setError(response); return false; }
        }

        public bool Update(User User)
        {
            setClientHeaders();
            IRestRequest request = new RestRequest("/api/user", Method.PUT);
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(User), ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = client.Execute(request);


            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return true;
            else { setError(response); return false; }
        }

        public bool Delete(string Username)
        {
            setClientHeaders();

            IRestRequest request = new RestRequest(string.Format("/api/user?username={0}", Username), Method.DELETE);
            IRestResponse response = client.Delete(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return true;
            else { setError(response); return false; }
        }

        #endregion

        #region private methods

        private void setClientHeaders()
        {
            RequestDate = DateTimeOffset.UtcNow;
            client.AddDefaultHeader("Authorization", string.Format("alms-token apiAccessKey={0}, nonce={1}", config.ApiAccessKey, Utilities.GenerateNonce(config, RequestDate)));
            client.AddDefaultHeader("Date", RequestDate.ToString());
        }

        private void setError(IRestResponse response)
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
