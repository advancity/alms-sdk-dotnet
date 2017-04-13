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

    class OrganizationService : BaseService, IOrganizationService
    {
        #region Constants

        public DateTimeOffset RequestDate;

        #endregion

        #region Ctor

        public OrganizationService(AuthConfig authConfig, string baseApiURI)
            : base(authConfig, baseApiURI) { }

        public string OrganizationId { get; set; }

        #endregion

        #region Methods

        public bool Create(Organization organization)
        {
            IRestRequest request = new RestRequest("/api/Organization", Method.POST);
            string postData = JsonConvert.SerializeObject(organization);
            request.AddParameter("application/json; charset=utf-8", postData, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = Client.Post(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK) { OrganizationId = JsonConvert.DeserializeObject<string>(response.Content); return true; }
            else { this.setError(response); return false; }
        }

        #endregion
    }
}
