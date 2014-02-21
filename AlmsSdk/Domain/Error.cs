using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmsSdk.Domain
{
    public class Error
    {
        public int ErrorCode { get; set; }
        public string ErrorCodeString { get; set; }
        public string Message { get; set; }
    }
}
