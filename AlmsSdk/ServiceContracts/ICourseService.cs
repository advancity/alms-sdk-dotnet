using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlmsSdk.Domain;
using RestSharp;

namespace AlmsSdk.ServiceContracts
{
    public interface ICourseService : IService
    {
        Course Get(Guid courseGuid);
        IEnumerable<Course> Search(string keyword, bool isActive, int offset = 0, int limit = 100);
        Guid Create(Course course);
        bool Delete(Guid courseGuid);
        bool Update(Course course);
        bool AddTeachers(string CourseGuid, List<string> Teachers);
        bool RemoveTeachers(string CourseGuid, List<string> Teachers);
    }
}
