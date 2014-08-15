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

        public Guid Create(OrganizationalUnit organizationalUnit)
        {
            IRestRequest request = new RestRequest("/api/organizationalunit", Method.POST);
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(organizationalUnit), ParameterType.RequestBody);
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

        public OrganizationalUnit Get(Guid organizationalUnitGuid)
        {
            IRestRequest request = new RestRequest(string.Format("/api/organizationalunit?organizationalUnitGuid={0}", organizationalUnitGuid), Method.GET);
            IRestResponse response = Client.Get<OrganizationalUnit>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK) return (response as RestResponse<OrganizationalUnit>).Data;
            else { this.setError(response); return null; }
        }

        public IEnumerable<OrganizationalUnit> Search(string keyword, bool isProgram = false, bool isActive = true)
        {
            IRestRequest request = new RestRequest(string.Format("/api/organizationalunit/search?keyword={0}&isProgram={1}&isActive={2}", Uri.EscapeUriString(keyword), isProgram, isActive), Method.GET);
            IRestResponse response = Client.Get<List<OrganizationalUnit>>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK) return (response as RestResponse<List<OrganizationalUnit>>).Data;
            else { this.setError(response); return null; }
        }

        public bool Update(OrganizationalUnit organizationalUnit)
        {

            IRestRequest request = new RestRequest("/api/organizationalunit", Method.PUT);
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(organizationalUnit), ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = Client.Execute(request);
            
            if (response.StatusCode == System.Net.HttpStatusCode.OK) return true;
            else { this.setError(response); return false; }
        }

        public bool Delete(Guid organizationalUnitGuid)
        {
            IRestRequest request = new RestRequest(string.Format("/api/organizationalunit?organizationalUnitGuid={0}", organizationalUnitGuid), Method.DELETE);
            IRestResponse response = Client.Delete(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent) return true;
            else { this.setError(response); return false; }
        }

        #endregion
    }
}
