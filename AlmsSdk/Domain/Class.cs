using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlmsSdk.Domain
{
    public class Class
    {
        public Class()
        {
            ClassGuid = CourseGuid = ParentGuid = ProgramGuid = GroupGuid = Guid.Empty.ToString();
        }
        
        public string ClassGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public string Organizationstring { get; set; }
        public string CourseGuid { get; set; }
        public string ParentGuid { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ProgramGuid { get; set; }
        public string GroupGuid { get; set; }
        public string ExternalKey { get; set; }
    }
}
