using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlmsSdk.Domain;
using RestSharp;

namespace AlmsSdk.ServiceContracts
{
    public interface IClassService : IService
    {
        Guid Create(Class Class);
        bool AddTeachers(string ClassGuid, List<string> Teachers);
        bool RemoveTeachers(string ClassGuid, List<string> Teachers);
    }
}
