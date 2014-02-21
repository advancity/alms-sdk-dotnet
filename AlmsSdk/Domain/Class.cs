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
        }
        
        public Guid ClassGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? CourseGuid { get; set; }
        public Guid? ParentGuid { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid? ProgramGuid { get; set; }
        public Guid? GroupGuid { get; set; }
        public string ExternalKey { get; set; }
    }
}
