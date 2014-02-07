using AlmsSdk.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlmsSdk.Domain
{
    public class Course
    {
        public Guid CourseGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CourseViewType CourseDefaultView { get; set; }
        public ICollection<string> CourseAdmins { get; set; }
        public bool CourseAllowSelfEnrollment { get; set; }
        public int? TermId { get; set; }
        public string Abbreviation { get; set; }
        public string ExternalKey { get; set; }
        public Guid MasterCourseGuid { get; set; }
    }
}
