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
    using ServiceContracts;

    class UserService : BaseService, IUserService
    {
        #region Constants

        public DateTimeOffset RequestDate;

        #endregion

        #region Ctor

        public UserService(AuthConfig authConfig, string baseApiURI)
            : base(authConfig, baseApiURI)
        {
            //config = authConfig;
            //client = new RestClient(baseApiURI);
        }

        #endregion

        #region Methods

        public User Get(string Username)
        {
            IRestRequest request = new RestRequest(string.Format("/api/user?username={0}", Username), Method.GET);
            IRestResponse response = client.Get<User>(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return (response as RestResponse<User>).Data;
            else { this.setError(response); return null; }
        }

        public IEnumerable<User> Search(string Keyword)
        {
            IRestRequest request = new RestRequest(string.Format("/api/user/search?keyword={0}", Keyword), Method.GET);
            IRestResponse response = client.Get<List<User>>(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return (response as RestResponse<List<User>>).Data;
            else { this.setError(response); return null; }
        }

        public bool Create(User User)
        {
            IRestRequest request = new RestRequest("/api/user", Method.POST);
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(User), ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = client.Post<bool>(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return true;
            else { this.setError(response); return false; }
        }

        public bool Update(User User)
        {
            IRestRequest request = new RestRequest("/api/user", Method.PUT);
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(User), ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = client.Execute(request);


            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return true;
            else { this.setError(response); return false; }
        }

        public bool Delete(string Username)
        {
            IRestRequest request = new RestRequest(string.Format("/api/user?username={0}", Username), Method.DELETE);
            IRestResponse response = client.Delete(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return true;
            else { this.setError(response); return false; }
        }

        public bool Enroll(Enrollment enrollment)
        {
            IRestRequest request = new RestRequest("/api/user/enroll", Method.POST);
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(enrollment), ParameterType.RequestBody);
            IRestResponse response = client.Post<Enrollment>(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return true;
            else { this.setError(response); return false; }
        }

        #endregion
    }
}
