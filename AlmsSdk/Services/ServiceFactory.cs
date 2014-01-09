using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmsSdk.Services
{
    public class ServiceFactory
    {
        public AuthConfig AuthConfig { get; set; }
        public string BaseApiURI { get; set; }
        public ServiceFactory()
        {
            AuthConfig = new AuthConfig();
            AuthConfig.ApiAccessKey = ConfigurationManager.AppSettings["ALMSApiAccessKey"];
            AuthConfig.ApiSecretKey = ConfigurationManager.AppSettings["ALMSApiSecretKey"];
            BaseApiURI = ConfigurationManager.AppSettings["ALMSBaseApiURI"];
        }
        public IUserService CreateUserService()
        {
            UserService userService = new UserService(AuthConfig, BaseApiURI);
            return userService;
        }
    }
}
