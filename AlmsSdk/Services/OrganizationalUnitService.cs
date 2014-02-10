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

    class OrganizationalUnitService : BaseService, IOrganizationalUnitService
    {
        #region Constants

        public DateTimeOffset RequestDate;

        #endregion

        #region Ctor

        public OrganizationalUnitService(AuthConfig authConfig, string baseApiURI)
            : base(authConfig, baseApiURI) { }

        #endregion

        #region Methods

        public bool Create(OrganizationalUnit OrganizationalUnit)
        {
            IRestRequest request = new RestRequest("/api/organizationalunit", Method.POST);
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(OrganizationalUnit), ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = client.Post<bool>(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return true;
            else { this.setError(response); return false; }
        }

        public OrganizationalUnit Get(string OrganizationalUnitGuid)
        {
            IRestRequest request = new RestRequest(string.Format("/api/organizationalunit?organizationalunitguid={0}", OrganizationalUnitGuid), Method.GET);
            IRestResponse response = client.Get<OrganizationalUnit>(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return (response as RestResponse<OrganizationalUnit>).Data;
            else { this.setError(response); return null; }
        }

        public IEnumerable<OrganizationalUnit> Search(string Keyword, bool IsProgram)
        {
            IRestRequest request = new RestRequest(string.Format("/api/organizationalunit/search?name={0}&isprogram={1}", Keyword, IsProgram), Method.GET);
            IRestResponse response = client.Get<List<OrganizationalUnit>>(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return (response as RestResponse<List<OrganizationalUnit>>).Data;
            else { this.setError(response); return null; }
        }

        public bool Update(OrganizationalUnit OrganizationalUnit)
        {
            
            IRestRequest request = new RestRequest("/api/organizationalunit", Method.PUT);
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(OrganizationalUnit), ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = client.Execute(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return true;
            else { this.setError(response); return false; }
        }

        public bool Delete(string OrganizationalUnitGuid)
        {
            IRestRequest request = new RestRequest(string.Format("/api/organizationalunit?organizationalunitguid={0}", OrganizationalUnitGuid), Method.DELETE);
            IRestResponse response = client.Delete(request);

            if (response.StatusCode.GetHashCode().ToString().StartsWith("2")) return true;
            else { this.setError(response); return false; }
        }

        #endregion
    }
}
