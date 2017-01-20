using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlmsSdk.Domain;
using RestSharp;

namespace AlmsSdk.ServiceContracts
{
    public interface IUserService : IService
    {
        User Get(string username);
        IEnumerable<User> Search(string keyword, bool isActive = true, int offset = 0, int limit = 100);
        bool Create(User user); 
        bool Delete(string username);
        bool Update(User user, Guid? OrganizationGuid = null);
        bool Enroll(Guid classGuid, params string[] usernames);
        bool Disenroll(Guid classGuid, params string[] usernames);
        string GetLoginToken(string username);
        bool ExpireLoginToken(string username);
        bool ChangeActiveStatus(List<string> guildList, bool activeStatus);
        IEnumerable<Enrollment> GetEnrollment(string userName, string activityId);
        IEnumerable<Enrollment> GetEnrollmentByClassId(string userName, string classId);
    }
}
