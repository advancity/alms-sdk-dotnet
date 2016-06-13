using AlmsSdk.Domain;
using AlmsSdk.Functions;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlmsSdk.Services
{
    using ServiceContracts;

    class MasterCourseService : BaseService, IMasterCourseService
    {
        #region Constants

        public DateTimeOffset RequestDate;

        #endregion

        #region Ctor

        public MasterCourseService(AuthConfig authConfig, string baseApiURI)
            : base(authConfig, baseApiURI) { }

        #endregion

        #region Methods

        public MasterCourse Get(Guid masterCourseGuid)
        {
            IRestRequest request = new RestRequest(string.Format("/api/mastercourse?masterCourseGuid={0}", masterCourseGuid.ToString()), Method.GET);
            IRestResponse response = Client.Get<MasterCourse>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK) return (response as RestResponse<MasterCourse>).Data;
            else { this.setError(response); return null; }
        }

        public IEnumerable<MasterCourse> Search(string keyword, bool isActive, int offset = 0, int limit = 100)
        {
            IRestRequest request = new RestRequest(string.Format("/api/mastercourse/search?keyword={0}&isActive={1}&offset={2}&limit={3}", Uri.EscapeUriString(keyword), isActive, offset, limit), Method.GET);
            IRestResponse response = Client.Get<List<MasterCourse>>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK) return (response as RestResponse<List<MasterCourse>>).Data;
            else { this.setError(response); return null; }
        }

        public Guid Create(MasterCourse masterCourse)
        {
            IRestRequest request = new RestRequest("/api/mastercourse", Method.POST);
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(masterCourse), ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = Client.Post<MasterCourse>(request);

            Guid guid = Guid.Empty;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Guid.TryParse(Newtonsoft.Json.JsonConvert.DeserializeObject<ApiObjectId>(response.Content).Id, out guid);
            }
            else { this.setError(response); }
            return guid;
        }

        public bool Delete(Guid masterCourseGuid)
        {
            IRestRequest request = new RestRequest(string.Format("/api/mastercourse?masterCourseGuid={0}", masterCourseGuid), Method.DELETE);
            IRestResponse response = Client.Delete(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent) return true;
            else { this.setError(response); return false; }
        }

        public bool Update(MasterCourse masterCourse)
        {
            IRestRequest request = new RestRequest("/api/mastercourse", Method.PUT);
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(masterCourse), ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = Client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK) return true;
            else { this.setError(response); return false; }
        }
        public bool ChangeActiveStatus(List<string> guildList , bool activeStatus )
        {
            IRestRequest request = new RestRequest(string.Format("/api/mastercourse/ChangeActiveStatus?activeStatus={0}", activeStatus), Method.POST);
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(guildList), ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = Client.Post<bool>(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return true;
            else { this.setError(response); return false; }
        }

        #endregion
    }
}
