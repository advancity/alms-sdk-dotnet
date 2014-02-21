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
        IEnumerable<User> Search(string keyword, bool isActive = true);
        bool Create(User user); 
        bool Delete(string username);
        bool Update(User user);
        bool Enroll(Guid classGuid, params string[] usernames);
    }
}
