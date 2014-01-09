using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlmsSdk.Domain;

namespace AlmsSdk.Services
{
    public interface IUserService
    {
        User Get(string Username);
        IEnumerable<User> Search(string Keyword);
        bool Create(User User); 
        bool Delete(string Username); 
        bool Update(User User); 
        Error LastError { get; }
    }
}
