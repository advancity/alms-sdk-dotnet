using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlmsSdk.ServiceContracts
{
    using Domain;
    using RestSharp;

    public interface IMasterCourseService : IService
    {
        MasterCourse Get(Guid masterCourseGuid);
        IEnumerable<MasterCourse> Search(string keyword, bool isActive, int offset = 0, int limit = 100);
        Guid Create(MasterCourse masterCourse);
        bool Delete(Guid masterCourseGuid);
        bool Update(MasterCourse masterCourse);
    }
}
