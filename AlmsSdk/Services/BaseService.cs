using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlmsSdk.Services
{
    using Domain;
    using ServiceContracts;
    using RestSharp;

    internal class BaseService : IService
    {
        public BaseService(AuthConfig authConfig, string baseApiURI)
        {
            config = authConfig;
            client = new RestClient(baseApiURI);
        }

        public AuthConfig config { get; set; }
        public RestClient client { get; set; }
        public Error LastError { get; set; }
    }
}
