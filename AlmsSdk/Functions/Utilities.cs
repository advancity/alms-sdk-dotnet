using AlmsSdk.Domain;
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
        protected internal static string GenerateNonce(AuthConfig config, DateTimeOffset httpRequestUTCDate)
        {
            CultureInfo ci = new CultureInfo("en-US");
            string content = config.ApiAccessKey + " " + httpRequestUTCDate.ToString(ci.DateTimeFormat.RFC1123Pattern);

            byte[] keyByte = System.Text.Encoding.UTF8.GetBytes(config.ApiSecretKey);
            var hmacsha256 = new System.Security.Cryptography.HMACSHA256(keyByte);

            byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(content);
            byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);

            string sbinary = "";
            for (int i = 0; i < hashmessage.Length; i++) sbinary += hashmessage[i].ToString("X2"); // hex format
            return sbinary;
        }

        protected internal static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        protected internal static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
