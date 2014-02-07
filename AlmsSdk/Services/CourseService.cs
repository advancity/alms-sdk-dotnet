using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlmsSdk.Services
{
    using AlmsSdk.Functions;
    using Domain;
    using Newtonsoft.Json;
    using RestSharp;
    using ServiceContracts;
    using Factory;

    class CourseService : BaseService, ICourseService
    {
        #region Constants

        public DateTimeOffset RequestDate;

        #endregion

        #region Ctor

        public CourseService(AuthConfig authConfig, string baseApiURI)
            : base(authConfig, baseApiURI) { }

        #endregion

        #region Methods

        public Course Get(string CourseTrackingGuid)
        {
            setClientHeaders();

            IRestRequest request = new RestRequest(string.Format("/api/course?coursetrackingguid={0}", CourseTrackingGuid), Method.GET);
            IRestResponse response = client.Get<Course>(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return (response as RestResponse<Course>).Data;
            else { setError(response); return null; }
        }

        public IEnumerable<Course> Search(string name, string activeStatus)
        {
            setClientHeaders();

            IRestRequest request = new RestRequest(string.Format("/api/course/search?name={0}&activestatus={1}",
                                                                                      name, activeStatus), Method.GET);
            IRestResponse response = client.Get<List<Course>>(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return (response as RestResponse<List<Course>>).Data;
            else { setError(response); return null; }
        }

        public bool Create(Course Course)
        {
            setClientHeaders();
            IRestRequest request = new RestRequest("/api/course", Method.POST);
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(Course), ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = client.Post<bool>(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return true;
            else { setError(response); return false; }
        }

        public bool Delete(string CourseTrackingGuid)
        {
            setClientHeaders();

            IRestRequest request = new RestRequest(string.Format("/api/course?coursetrackingguid={0}", CourseTrackingGuid), Method.DELETE);
            IRestResponse response = client.Delete(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return true;
            else { setError(response); return false; }
        }

        public bool Update(Course Course)
        {
            setClientHeaders();
            IRestRequest request = new RestRequest("/api/course", Method.PUT);
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(Course), ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = client.Execute(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return true;
            else { setError(response); return false; }
        }

        static void CreateCourse(Course course)
        {
            ServiceFactory factory = new ServiceFactory();
            ICourseService cService = factory.CreateCourseService();
            
            bool success = cService.Create(course);

            if (!success)
            {
                Console.WriteLine("ErrorCode: " + cService.LastError.ErrorCode);
                Console.WriteLine("ErrorMessage: " + cService.LastError.ErrorMessage);
            }
            else
            {
                Console.WriteLine(string.Format("User {0} was created.", course.Name));
            }
        }

        #endregion

        #region SpecialMethods

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
