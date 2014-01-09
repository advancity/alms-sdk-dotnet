using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmsSdk.Functions
{
    class Utilities
    {
        protected internal static string GenerateNonce(AuthConfig config, DateTime httpRequestUTCDate)
        {
            string content = config.ApiAccessKey + " " + httpRequestUTCDate.ToString(CultureInfo.CurrentCulture.DateTimeFormat.RFC1123Pattern);

            byte[] keyByte = System.Text.Encoding.UTF8.GetBytes(config.ApiSecretKey);
            var hmacsha256 = new System.Security.Cryptography.HMACSHA256(keyByte);

            byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(content);
            byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);

            string sbinary = "";
            for (int i = 0; i < hashmessage.Length; i++) sbinary += hashmessage[i].ToString("X2"); // hex format
            return sbinary;
        }
    }
}
