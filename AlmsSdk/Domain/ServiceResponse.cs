using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdvancitySDK.Domain
{
    public class ServiceResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public DateTime ResponseDatetimeUtc { get; set; }
        public string TimeElapsed { get; set; }
        public Error Error { get; set; }
    }
}
