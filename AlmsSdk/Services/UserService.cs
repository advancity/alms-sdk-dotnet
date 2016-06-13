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
        }

        #endregion

        #region Methods

        public User Get(string Username)
        {
            IRestRequest request = new RestRequest(string.Format("/api/user?username={0}&email=", Username), Method.GET);
            IRestResponse response = Client.Get<User>(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return (response as RestResponse<User>).Data;
            else { this.setError(response); return null; }
        }

        public IEnumerable<User> Search(string keyword, bool isActive = true, int offset = 0, int limit = 100)
        {
            IRestRequest request = new RestRequest(string.Format("/api/user/search?keyword={0}&isActive={1}&offset={2}&limit={3}", Uri.EscapeUriString(keyword), isActive, offset, limit), Method.GET);
            IRestResponse response = Client.Get<List<User>>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK) return (response as RestResponse<List<User>>).Data;
            else { this.setError(response); return null; }
        }

        public bool Create(User User)
        {
            IRestRequest request = new RestRequest("/api/user", Method.POST);
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(User), ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = Client.Post<bool>(request);
            bool success = false;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                success = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiObjectId>(response.Content).Id == User.UserName;
            }
            else { this.setError(response); }
            return success;
        }

        public bool Update(User User, Guid? OrganizationGuid = null)
        {
            IRestRequest request = new RestRequest(string.Format("/api/user?organizationGuid={0}", OrganizationGuid), Method.PUT);
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(User), ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = Client.Execute(request);


            if (response.StatusCode == System.Net.HttpStatusCode.OK) return true;
            else { this.setError(response); return false; }
        }

        public bool Delete(string username)
        {
            IRestRequest request = new RestRequest(string.Format("/api/user?username={0}", username), Method.DELETE);
            IRestResponse response = Client.Delete(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent) return true;
            else { this.setError(response); return false; }
        }

        public bool Enroll(Guid classGuid, params string[] usernames)
        {
            IRestRequest request = new RestRequest("/api/user/enroll?classGuid=" + classGuid.ToString(), Method.POST);
            string postData = JsonConvert.SerializeObject(usernames);
            request.AddParameter("application/json; charset=utf-8", postData, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = Client.Post(request);

            // TODO: number of enrollments can be returned...
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent) return true;
            else { this.setError(response); return false; }
        }

        public bool Disenroll(Guid classGuid, params string[] usernames)
        {
            IRestRequest request = new RestRequest("/api/user/disenroll?classGuid=" + classGuid.ToString(), Method.POST);
            string postData = JsonConvert.SerializeObject(usernames);
            request.AddParameter("application/json; charset=utf-8", postData, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = Client.Post(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent) return true;
            else { this.setError(response); return false; }
        }

        public bool Enroll(Guid programGuid, string className, params string[] usernames)
        {
            IRestRequest request = new RestRequest("/api/user/enroll?className=" + Uri.EscapeUriString(className) + "&programGuid=" + programGuid.ToString(), Method.POST);
            string postData = JsonConvert.SerializeObject(usernames);
            request.AddParameter("application/json; charset=utf-8", postData, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = Client.Post(request);

            // TODO: number of enrollments can be returned...
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent) return true;
            else { this.setError(response); return false; }
        }

        public string GetLoginToken(string username)
        {
            IRestRequest request = new RestRequest("/api/user/getlogintoken", Method.POST);
            string postData = JsonConvert.SerializeObject(username);
            request.AddParameter("application/json; charset=utf-8", postData, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = Client.Post(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK) return JsonConvert.DeserializeObject<string>(response.Content);
            else { this.setError(response); return null; }
        }

        #endregion

        public bool ExpireLoginToken(string username)
        {
            IRestRequest request = new RestRequest("/api/user/expirelogintoken", Method.POST);
            string postData = JsonConvert.SerializeObject(username);
            request.AddParameter("application/json; charset=utf-8", postData, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = Client.Post(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK) return true;
            else { this.setError(response); return false; }
        }

        public bool ChangeActiveStatus(List<string> guildList, bool activeStatus)
        {
            IRestRequest request = new RestRequest(string.Format("/api/User/ChangeActiveStatus?activeStatus={0}", activeStatus), Method.POST);
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(guildList), ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = Client.Post<bool>(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return true;
            else { this.setError(response); return false; }
        }
    }
}
