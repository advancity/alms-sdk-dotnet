using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlmsSdk.Domain
{
    public class ServerInfo
    {
        public string ServerName { get; set; }
        public string Ip { get; set; }
        public string Cpu { get; set; }
        public string Memory { get; set; }
        public string Disks { get; set; }
    }
}
