using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlmsSdk.Domain;
using RestSharp;

namespace AlmsSdk.ServiceContracts
{
    public interface ICourseService 
    {
        Course Get(string CourseTrackingGuid);
        IEnumerable<Course> Search(string name, string activeStatus);
        bool Create(Course Course);
        bool Delete(string CourseTrackingGuid);
        bool Update(Course Course);
        bool AddTeachers(string CourseGuid, List<string> Teachers);
        bool RemoveTeachers(string CourseGuid, List<string> Teachers);
        AuthConfig config { get; set; }
        RestClient client { get; set; }
        Error LastError { get; set; }
    }
}
