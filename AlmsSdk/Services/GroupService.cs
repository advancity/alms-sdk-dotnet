﻿using AlmsSdk.Functions;
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

    class GroupService : BaseService, IGroupService
    {
        #region Constants

        public DateTimeOffset RequestDate;

        #endregion

        #region Ctor

        public GroupService(AuthConfig authConfig, string baseApiURI)
            : base(authConfig, baseApiURI)
        {
        }

        public Dictionary<string, string> Data { get; set; }

        #endregion

        #region Methods

        public bool AddUsers(string groupGuid, string[] usernames)
        {
            IRestRequest request = new RestRequest(string.Format("/api/group/{0}/user", groupGuid), Method.POST);
            string postData = JsonConvert.SerializeObject(usernames);
            request.AddParameter("application/json; charset=utf-8", postData, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = Client.Post(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK) { Data = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content); return true; }
            else { this.setError(response); Data = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content); return false; }
        }

        public bool RemoveUsers(string groupGuid, string[] usernames)
        {
            IRestRequest request = new RestRequest(string.Format("/api/group/{0}/user", groupGuid), Method.DELETE);
            string postData = JsonConvert.SerializeObject(usernames);
            request.AddParameter("application/json; charset=utf-8", postData, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = Client.Delete(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK) { Data = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content); return true; }
            else { this.setError(response); Data = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content); return false; }
        }

        public string GetGroupListByProgram(string program = "")
        {
            IRestRequest request = new RestRequest(string.Format("/api/group/GetGroupList?programIds=" + program), Method.GET);

            request.RequestFormat = DataFormat.Json;

            IRestResponse response = Client.Get(request);

            return response.Content;
        }

        public string GetGroupListByUser(string uName)
        {
            IRestRequest request = new RestRequest(string.Format("/api/group/GetUserGroupList?userName=" + uName), Method.GET);
            //string postData = JsonConvert.SerializeObject(uName);
            //request.AddParameter("application/json; charset=utf-8", postData, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = Client.Get(request);
            return response.Content;
            //if (response.StatusCode == System.Net.HttpStatusCode.OK) { Data = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content); return null; }
            //else { this.setError(response); Data = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content); return null; }
        }

        #endregion
    }
}
