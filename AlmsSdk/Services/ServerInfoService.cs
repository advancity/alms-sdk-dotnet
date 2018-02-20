using AlmsSdk.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlmsSdk.Domain;
using RestSharp;
using Newtonsoft.Json;

namespace AlmsSdk.Services
{
    class ServerInfoService : BaseService, IServerInfoService
    {
        public ServerInfoService(AuthConfig authConfig, string baseApiURI) : base(authConfig, baseApiURI)
        {
        }
        public bool SendServerInfo(ServerInfo item)
        {
            IRestRequest request = new RestRequest("/api/serverinfo", Method.POST);
            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(item), ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = Client.Post(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK) return true;
            else { this.setError(response); return false; }
        }
    }
}
