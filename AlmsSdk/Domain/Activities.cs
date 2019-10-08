using AlmsSdk.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmsSdk.Domain
{
   public class Activities
    {
        public Guid ActivityGuid { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Description { get; set; }
        public bool isActive { get; set; }
        public string CustomProperty1 { get; set; }
        public ActivityType Type { get; set; }
        public string ExternalKey { get; set; }
        public int? Duration { get; set; }

    }
}
