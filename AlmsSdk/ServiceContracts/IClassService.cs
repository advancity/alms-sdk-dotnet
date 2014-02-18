using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlmsSdk.Domain;
using RestSharp;

namespace AlmsSdk.ServiceContracts
{
    public interface IClassService 
    {
        //Course Get(string CourseTrackingGuid);
        //IEnumerable<Course> Search(string name, string activeStatus);
        bool Create(Class Class);
        bool AddTeachers(string ClassGuid, List<string> Teachers);
        bool RemoveTeachers(string ClassGuid, List<string> Teachers);
        //bool Delete(string CourseTrackingGuid);
        //bool Update(Course Course);
        AuthConfig config { get; set; }
        RestClient client { get; set; }
        Error LastError { get; set; }
    }
}
