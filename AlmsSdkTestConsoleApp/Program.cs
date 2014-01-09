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
            Save();
            Get();
            Search();
            Update();
            Delete();
        }

        #region Sample codes
        
        static void Get() 
        {
            ServiceFactory factory = new ServiceFactory();
            IUserService uService = factory.CreateUserService();

            var user = uService.Get("sample_user"); //Test_user kullanıcısını getir

            if (uService.LastError != null)
            {
                Console.WriteLine("ErrorCode: " + uService.LastError.ErrorCode);
                Console.WriteLine("ErrorMessage: " + uService.LastError.ErrorMessage);
            }
            else
            {
                //do something
            }
        }

        static void Search()
        {
            ServiceFactory factory = new ServiceFactory();
            IUserService uService = factory.CreateUserService();

            var user = uService.Search("User_"); //içinde "User_" geçenleri getir

            if (uService.LastError != null)
            {
                Console.WriteLine("ErrorCode: " + uService.LastError.ErrorCode);
                Console.WriteLine("ErrorMessage: " + uService.LastError.ErrorMessage);
            }
            else
            {
                //do something
            }
        }

        static void Update()
        {
            ServiceFactory factory = new ServiceFactory();
            IUserService uService = factory.CreateUserService();

            var user = new User();
            user.UserName = "sample_user";
            user.Password = "MyPassword!";
            user.FirstName = "Sample";
            user.LastName = "User";
            user.Email = "sample_user@alms.com.tr";
            user.Types = UserType.User.GetHashCode();

            // nullable
            user.MobilePhone = "+905327775544";
            user.Comment = "This user is created by Alms API.";
            user.Culture = "tr-TR";
            user.HomeTown = "My hometown";
            user.City = "Istanbul";
            user.Country = "Türkiye";
            user.Occupation = "Software Engineer";
            user.Gender = "Male"; // OR Female
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
                //do something
            }
        }

        static void Delete()
        {
            ServiceFactory factory = new ServiceFactory();
            IUserService uService = factory.CreateUserService();

            bool success = uService.Delete("sample_user");

            if (!success)
            {
                Console.WriteLine("ErrorCode: " + uService.LastError.ErrorCode);
                Console.WriteLine("ErrorMessage: " + uService.LastError.ErrorMessage);
            }
            else
            {
                //do something
            }
        }

        static void Save()
        {
            ServiceFactory factory = new ServiceFactory();
            IUserService uService = factory.CreateUserService();

            var user = new User();
            user.UserName = "sample_user";
            user.Password = "MyPassword!";
            user.FirstName = "Sample";
            user.LastName = "UCser";
            user.Email = "sample_user@alms.com.tr";
            user.Types = UserType.User.GetHashCode();

            // nullable
            user.MobilePhone = "+905327775544";
            user.Comment = "This user is created by Alms API.";
            user.Culture = "tr-TR";
            user.HomeTown = "My hometown";
            user.City = "Istanbul";
            user.Country = "Türkiye";
            user.Occupation = "Software Engineer";
            user.Gender = "Male"; // OR Female
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
            bool success = uService.Save(user);

            if (!success)
            {
                Console.WriteLine("ErrorCode: " + uService.LastError.ErrorCode);
                Console.WriteLine("ErrorMessage: " + uService.LastError.ErrorMessage);
            }
            else
            {
                //do something
            }
        }

        #endregion
    }
}
