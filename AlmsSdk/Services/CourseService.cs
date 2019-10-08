using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlmsSdk.Domain;
using AlmsSdk.Functions;
using AlmsSdk.Domain;
using RestSharp;
using AlmsSdk.ServiceContracts;
using AlmsSdk.Service;
using Newtonsoft.Json;

namespace AlmsSdk.Services
{
    class CourseService : BaseService, ICourseService
    {
        #region Constants

        #endregion

        #region Ctor

        public CourseService(AuthConfig authConfig, string baseApiURI)
            : base(authConfig, baseApiURI) { }

        #endregion

        #region Methods

        public Course Get(Guid courseGuid)
        {
            IRestRequest request = new RestRequest(string.Format("/api/course?courseGuid={0}", courseGuid), Method.GET);
            IRestResponse response = Client.Get<Course>(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return (response as RestResponse<Course>).Data;
            else { this.setError(response); return null; }
        }

        public IEnumerable<Course> Search(string keyword, bool isActive,string termGuid, int offset = 0, int limit = 100)
        {
            IRestRequest request = new RestRequest(string.Format("/api/course/Search?keyword={0}&isActive={1}&offset={2}&limit={3}&termGuid={4}", System.Uri.EscapeUriString(keyword), isActive, offset, limit,termGuid), Method.GET);
            IRestResponse response = Client.Get<List<Course>>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK) return (response as RestResponse<List<Course>>).Data;
            else { this.setError(response); return null; }
        }

        public Guid Create(Course course)
        {
            IRestRequest request = new RestRequest("/api/course", Method.POST);
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(course), ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = Client.Post(request);

            Guid guid = Guid.Empty;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Guid.TryParse(Newtonsoft.Json.JsonConvert.DeserializeObject<ApiObjectId>(response.Content).Id, out guid);
            }
            else { this.setError(response); }
            return guid;
        }

        public bool Delete(Guid courseGuid)
        {
            IRestRequest request = new RestRequest(string.Format("/api/course?courseGuid={0}", courseGuid), Method.DELETE);
            IRestResponse response = Client.Delete(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent) return true;
            else { this.setError(response); return false; }
        }

        public bool Update(Course Course)
        {
            IRestRequest request = new RestRequest("/api/course", Method.PUT);
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(Course), ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = Client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK) return true;
            else { this.setError(response); return false; }
        }

        public bool AddTeachers(string CourseGuid, List<string> Teachers)
        {
            IRestRequest request = new RestRequest(string.Format("/api/course/addteachers?courseguid={0}", CourseGuid), Method.POST);
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(Teachers), ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = Client.Post<bool>(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return true;
            else { this.setError(response); return false; }
        }

        public bool RemoveTeachers(string CourseGuid, List<string> Teachers)
        {
            IRestRequest request = new RestRequest(string.Format("/api/course/removeteachers?courseguid={0}", CourseGuid), Method.POST);
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(Teachers), ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = Client.Post<bool>(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return true;
            else { this.setError(response); return false; }
        }

        public IEnumerable<Class> GetClassList(string courseGuid)
        {
            IRestRequest request = new RestRequest(string.Format("/api/course/GetClassList?CourseId={0}", courseGuid), Method.GET);
            IRestResponse response = Client.Get<List<Class>>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK) return (response as RestResponse<List<Class>>).Data;
            else { this.setError(response); return null; }
        }

        public IEnumerable<Activities> GetActivityList(string courseExternalKey , bool? isActive = null)
        {
            IRestRequest request = new RestRequest(string.Format("/api/course/GetActivityList?CourseExternalKey={0}&isActive={1}", courseExternalKey,isActive), Method.GET);
            IRestResponse response = Client.Get<List<Activities>>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK) return (response as RestResponse<List<Activities>>).Data;
            else { this.setError(response); return null; }
        }

        public bool ChangeActiveStatus(List<string> guildList, bool activeStatus)
        {
            IRestRequest request = new RestRequest(string.Format("/api/course/ChangeActiveStatus?activeStatus={0}", activeStatus), Method.POST);
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(guildList), ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = Client.Post<bool>(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return true;
            else { this.setError(response); return false; }
        }

        #endregion
    }
}
