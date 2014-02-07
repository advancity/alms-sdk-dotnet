using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlmsSdk.Domain
{
    public class MasterCourse
    {
        public MasterCourse()
        {
            Programs = new List<OrganizationalUnit>();
        }

        public string MasterCourseGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string ApplicationCondition { get; set; }
        public List<string> Categories { get; set; }
        public string Credits { get; set; }
        public string ECTSCredits { get; set; }
        public string Practice { get; set; }
        public string Period { get; set; }
        public List<string> Audiences { get; set; }
        public List<OrganizationalUnit> Programs { get; set; } 
        public bool? AllowSelfEnrollment { get; set; }
        public string ExternalKey { get; set; }
    }
}
