using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlmsSdk.Domain
{
    public class Enrollment
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid ActivityGuid { get; set; }
        public string ActivityName { get; set; }
        public string CourseName { get; set; }
        public string ActivityType { get; set; }
        public Guid TrackingGuid { get; set; }
        public string ScoreStatus { get; set; }
        public int Progress { get; set; }
        public int UploadCount { get; set; }
        public DateTime? FirstAttemptDate { get; set; }
        public DateTime? LastAttemptDate { get; set; }
        public int AttemptCount { get; set; }
        public DateTime? CompetionDate { get; set; }
        public int? TotalSeconds { get; set; }
        public int DownloadCount { get; set; }
        public int ClassId { get; set; }
        public int UserId { get; set; }
        public int OrganizationId { get; set; }
    }
}
