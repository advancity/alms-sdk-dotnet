using AlmsSdk.Domain;
using AlmsSdk.ServiceContracts;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlmsSdk.Services
{
    class EnrollmentService : BaseService , IEnrollmentService
    {
        public EnrollmentService(AuthConfig authConfig, string baseApiURI)
            : base(authConfig, baseApiURI) { }

        public Enrollment GetEnrollment(string enrollmentGuid)
        {
            IRestRequest request = new RestRequest(string.Format("/api/enrollment?enrollmentGuid={0}", enrollmentGuid), Method.GET);
            IRestResponse response = Client.Get<List<Enrollment>>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK) return (response as RestResponse<List<Enrollment>>).Data.FirstOrDefault();
            else { this.setError(response); return null; }
        }
    }
}
