using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmsSdk
{
    public class AuthConfig
    {
        public string ApiAccessKey { get; set; }
        public string ApiSecretKey { get; set; }

        public static AuthConfig GetConfig()
        {
            if (File.Exists("config.json"))
            {
                string configJson = File.ReadAllText("config.json");
                var config = JsonConvert.DeserializeObject<AuthConfig>(configJson);

                return config;
            }
            else
            {
                var config = new AuthConfig() { ApiAccessKey = "ApiAccessKey", ApiSecretKey = "ApiSecretKey" };
                string configStr = JsonConvert.SerializeObject(config);
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\config.json", configStr);
                return config;
            }
        }
    }
}
