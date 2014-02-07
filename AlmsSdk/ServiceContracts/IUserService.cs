using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlmsSdk.Domain;
using RestSharp;

namespace AlmsSdk.ServiceContracts
{
    public interface IUserService
    {
        User Get(string Username);
        IEnumerable<User> Search(string Keyword);
        bool Create(User User); 
        bool Delete(string Username); 
        bool Update(User User);
        AuthConfig config { get; set; }
        RestClient client { get; set; }
        Error LastError { get; set; }
    }
}
