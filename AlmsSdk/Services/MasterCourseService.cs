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
        #region Constances

        public DateTimeOffset RequestDate;

        #endregion

        #region Ctor

        public MasterCourseService(AuthConfig authConfig, string baseApiURI)
            : base(authConfig, baseApiURI) { }

        #endregion

        #region Methods

        public MasterCourse Get(Guid MasterCourseGuid)
        {
            IRestRequest request = new RestRequest(string.Format("/api/mastercourse?mastercourseguid={0}", MasterCourseGuid.ToString()), Method.GET);
            IRestResponse response = client.Get<MasterCourse>(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return (response as RestResponse<MasterCourse>).Data;
            else { this.setError(response); return null; }
        }

        public IEnumerable<MasterCourse> Search(string name, bool isActive)
        {
            IRestRequest request = new RestRequest(string.Format("/api/mastercourse/search?name={0}&activestatus={1}", name, isActive), Method.GET);
            IRestResponse response = client.Get<List<MasterCourse>>(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return (response as RestResponse<List<MasterCourse>>).Data;
            else { this.setError(response); return null; }
        }

        public bool Create(MasterCourse MasterCourse)
        {
            IRestRequest request = new RestRequest("/api/mastercourse", Method.POST);
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(MasterCourse), ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = client.Post<MasterCourse>(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return true;
            else { this.setError(response); return false; }
        }

        public bool Delete(string MasterCourseId)
        {
            IRestRequest request = new RestRequest(string.Format("/api/mastercourse?mastercourseguid={0}", MasterCourseId), Method.DELETE);
            IRestResponse response = client.Delete(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return true;
            else { this.setError(response); return false; }
        }

        public bool Update(MasterCourse MasterCourse)
        {
            IRestRequest request = new RestRequest("/api/mastercourse", Method.PUT);
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(MasterCourse), ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = client.Execute(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return true;
            else { this.setError(response); return false; }
        }

        #endregion
    }
}
