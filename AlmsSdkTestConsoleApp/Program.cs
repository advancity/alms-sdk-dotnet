using AlmsSdk.Domain;
using AlmsSdk.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AlmsSdkTestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /* The following methods tests SDK methods and writes to the console output.
             * Before running this application, please check app.config to set ALSM API credentials and ALMS base url.
             */
            CreateUser();
            GetUser();
            SearchUsers();
            UpdateUser();
            DeleteUser();

            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.In.Read();
        }

        #region sample user operations
        
        static void GetUser() 
        {
            ServiceFactory factory = new ServiceFactory();
            IUserService uService = factory.CreateUserService();

            User user = uService.Get("sample_user"); // get user data by username

            if (uService.LastError != null)
            {
                Console.WriteLine("ErrorCode: " + uService.LastError.ErrorCode);
                Console.WriteLine("ErrorMessage: " + uService.LastError.ErrorMessage);
            }
            else
            {
                string name = user.FirstName + " " + user.LastName;
                Console.WriteLine(string.Format("Name of user {0} is {1}.", user.UserName, name));
            }
        }

        static void SearchUsers()
        {
            ServiceFactory factory = new ServiceFactory();
            IUserService uService = factory.CreateUserService();

            IEnumerable<User> users = uService.Search("User_"); // get users who contain User_ in their names, surnames, email addresses or usernames.

            if (uService.LastError != null)
            {
                Console.WriteLine("ErrorCode: " + uService.LastError.ErrorCode);
                Console.WriteLine("ErrorMessage: " + uService.LastError.ErrorMessage);
            }
            else
            {
                Console.WriteLine(string.Format("Found {0} users.", users.Count()));
            }
        }

        static void UpdateUser()
        {
            ServiceFactory factory = new ServiceFactory();
            IUserService uService = factory.CreateUserService();

            var user = new User();
            // the following are required fields.
            user.UserName = "sample_user";
            user.Password = "MyPassword!";
            user.FirstName = "Sample";
            user.LastName = "User";
            user.Email = "sample_user@alms.com.tr";
            user.Types = UserType.User.GetHashCode();

            // the following are optional.
            user.MobilePhone = "+905327775544";
            user.Comment = "This user is created by Alms API.";
            user.Culture = "tr-TR";
            user.HomeTown = "My hometown";
            user.City = "Istanbul";
            user.Country = "Türkiye";
            user.Occupation = "Software Engineer";
            user.Gender = "Male"; // OR Female
            // website url is optional but if you set it, it must be a valid URL.
            user.WebsiteURL = "http://www.alms.com.tr";
            user.CitizenshipIdentifier = "2433452456";
            user.Title = "Dr.";
            user.BirthDate = DateTime.Now.AddYears(-35);

            user.CustomProperty1 = "Custom prop 1";
            user.CustomProperty2 = "Custom prop 2";
            user.CustomProperty3 = "Custom prop 3";
            user.CustomProperty4 = "Custom prop 4";
            user.CustomProperty5 = "Custom prop 5";
            user.CustomProperty6 = "Custom prop 6";
            user.CustomProperty7 = "Custom prop 7";
            user.CustomProperty8 = "Custom prop 8";
            user.CustomProperty9 = "Custom prop 9";
            user.CustomProperty10 = "Custom prop 10";
            user.CustomProperty11 = "Custom prop 11";
            user.CustomProperty12 = "Custom prop 12";
            user.CustomProperty13 = "Custom prop 13";
            user.CustomProperty14 = "Custom prop 14";
            user.CustomProperty15 = "Custom prop 15";
            user.CustomProperty16 = "Custom prop 16";
            user.CustomProperty17 = "Custom prop 17";
            user.CustomProperty18 = "Custom prop 18";
            user.CustomProperty19 = "Custom prop 19";
            user.CustomProperty20 = "Custom prop 20";

            bool success = uService.Update(user);

            if (!success)
            {
                Console.WriteLine("ErrorCode: " + uService.LastError.ErrorCode);
                Console.WriteLine("ErrorMessage: " + uService.LastError.ErrorMessage);
            }
            else
            {
                Console.WriteLine(string.Format("User {0} was updated.", user.UserName));
            }
        }

        static void DeleteUser()
        {
            ServiceFactory factory = new ServiceFactory();
            IUserService uService = factory.CreateUserService();
            string username = "sample_user";
            bool success = uService.Delete(username);

            if (!success)
            {
                Console.WriteLine("ErrorCode: " + uService.LastError.ErrorCode);
                Console.WriteLine("ErrorMessage: " + uService.LastError.ErrorMessage);
            }
            else
            {
                Console.WriteLine(string.Format("User {0} was deleted.", username));
            }
        }

        static void CreateUser()
        {
            ServiceFactory factory = new ServiceFactory();
            IUserService uService = factory.CreateUserService();

            var user = new User();
            // the following are required fields.
            user.UserName = "sample_user";
            user.Password = "MyPassword!";
            user.FirstName = "Sample";
            user.LastName = "UCser";
            user.Email = "sample_user@alms.com.tr";
            user.Types = UserType.User.GetHashCode();

            // the following are optional fields.
            user.MobilePhone = "+905327775544";
            user.Comment = "This user is created by Alms API.";
            user.Culture = "tr-TR";
            user.HomeTown = "My hometown";
            user.City = "Istanbul";
            user.Country = "Türkiye";
            user.Occupation = "Software Engineer";
            user.Gender = "Male"; // OR Female
            // website url is optional but if you set it, it must be a valid URL.
            user.WebsiteURL = "http://www.alms.com.tr";
            user.CitizenshipIdentifier = "2433452456";
            user.Title = "Dr.";
            user.BirthDate = DateTime.Now.AddYears(-35);

            user.CustomProperty1 = "Custom prop 1";
            user.CustomProperty2 = "Custom prop 2";
            user.CustomProperty3 = "Custom prop 3";
            user.CustomProperty4 = "Custom prop 4";
            user.CustomProperty5 = "Custom prop 5";
            user.CustomProperty6 = "Custom prop 6";
            user.CustomProperty7 = "Custom prop 7";
            user.CustomProperty8 = "Custom prop 8";
            user.CustomProperty9 = "Custom prop 9";
            user.CustomProperty10 = "Custom prop 10";
            user.CustomProperty11 = "Custom prop 11";
            user.CustomProperty12 = "Custom prop 12";
            user.CustomProperty13 = "Custom prop 13";
            user.CustomProperty14 = "Custom prop 14";
            user.CustomProperty15 = "Custom prop 15";
            user.CustomProperty16 = "Custom prop 16";
            user.CustomProperty17 = "Custom prop 17";
            user.CustomProperty18 = "Custom prop 18";
            user.CustomProperty19 = "Custom prop 19";
            user.CustomProperty20 = "Custom prop 20";
            bool success = uService.Create(user);

            if (!success)
            {
                Console.WriteLine("ErrorCode: " + uService.LastError.ErrorCode);
                Console.WriteLine("ErrorMessage: " + uService.LastError.ErrorMessage);
            }
            else
            {
                Console.WriteLine(string.Format("User {0} was created.", user.UserName));
            }
        }

        #endregion
    }
}
