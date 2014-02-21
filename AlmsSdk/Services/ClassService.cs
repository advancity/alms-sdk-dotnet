using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlmsSdk.Functions;
using AlmsSdk.Domain;
using Newtonsoft.Json;
using RestSharp;
using AlmsSdk.ServiceContracts;

namespace AlmsSdk.Services
{
    class ClassService : BaseService, IClassService
    {
        #region Constants

        #endregion

        #region Ctor

        public ClassService(AuthConfig authConfig, string baseApiURI)
            : base(authConfig, baseApiURI) { }

        #endregion

        #region Methods

        //public Course Get(string CourseTrackingGuid)
        //{
        //    IRestRequest request = new RestRequest(string.Format("/api/course?coursetrackingguid={0}", CourseTrackingGuid), Method.GET);
        //    IRestResponse response = client.Get<Class>(request);
        //
        //    if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return (response as RestResponse<Course>).Data;
        //    else { this.setError(response); return null; }
        //}

        //public IEnumerable<Course> Search(string name, string activeStatus)
        //{
        //    IRestRequest request = new RestRequest(string.Format("/api/course/search?name={0}&activestatus={1}",
        //                                                                              name, activeStatus), Method.GET);
        //    IRestResponse response = client.Get<List<Course>>(request);
        //
        //    if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return (response as RestResponse<List<Course>>).Data;
        //    else { this.setError(response); return null; }
        //}

        public Guid Create(Class Class)
        {
            IRestRequest request = new RestRequest("/api/class", Method.POST);
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(Class), ParameterType.RequestBody);
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

        public bool AddTeachers(string ClassGuid, List<string> Teachers)
        {
            IRestRequest request = new RestRequest(string.Format("/api/class/addteachers?classguid={0}", ClassGuid), Method.POST);
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(Teachers), ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = Client.Post<bool>(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return true;
            else { this.setError(response); return false; }
        }

        public bool RemoveTeachers(string ClassGuid, List<string> Teachers)
        {
            IRestRequest request = new RestRequest(string.Format("/api/class/removeteachers?classguid={0}", ClassGuid), Method.POST);
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(Teachers), ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = Client.Post<bool>(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return true;
            else { this.setError(response); return false; }
        }

        //public bool Delete(string CourseTrackingGuid)
        //{
        //    IRestRequest request = new RestRequest(string.Format("/api/course?coursetrackingguid={0}", CourseTrackingGuid), Method.DELETE);
        //    IRestResponse response = client.Delete(request);
        //
        //    if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return true;
        //    else { this.setError(response); return false; }
        //}

        //public bool Update(Course Course)
        //{
        //    IRestRequest request = new RestRequest("/api/course", Method.PUT);
        //    request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(Course), ParameterType.RequestBody);
        //    request.RequestFormat = DataFormat.Json;
        //
        //    IRestResponse response = client.Execute(request);
        //
        //    if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return true;
        //    else { this.setError(response); return false; }
        //}

        #endregion
    }
}
