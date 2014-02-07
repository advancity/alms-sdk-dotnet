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
        MasterCourse Get(Guid MasterCourseGuid);
        IEnumerable<MasterCourse> Search(string name, bool isActive);
        bool Create(MasterCourse MasterCourse);
        bool Delete(string MasterCourseId);
        bool Update(MasterCourse MasterCourse);
        AuthConfig config { get; set; }
        RestClient client { get; set; }
        Error LastError { get; set; }
    }
}
