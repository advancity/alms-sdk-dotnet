using AlmsSdk.Domain;
using AlmsSdk.Services;
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
    using AlmsSdk.ServiceContracts;
    using AlmsSdk.Factory;
    
    class CourseTest
    {
        static void Main(string[] args)
        {
            /* The following methods tests SDK methods and writes to the console output.
             * Before running this application, please check app.config to set ALSM API credentials and ALMS base url.
             */
            //CreateProgram();
            //GetProgram();
            //SearchProgram();
            //UpdateProgram();
            //DeleteProgram();
            
            //CreateMasterCourse();
            //GetMasterCourse();
            //SearchMasterCourses();
            //UpdateMasterCourse();
            //DeleteMasterCourse();
            
            //CreateCourse();
            //GetCourse();
            //SearchCourses();
            //UpdateCourse();
            //DeleteCourse();

            //CreateUser();
            //GetUser();
            //SearchUsers();
            //UpdateUser();
            //DeleteUser();

            Console.ReadLine();
            //Console.In.Read();
        }

        #region sample user operations

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

        static void GetUser()
        {
            ServiceFactory factory = new ServiceFactory();
            IUserService uService = factory.CreateUserService();

            User user = uService.Get("User_emre"); // get user data by username

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

        #endregion

        #region sample course operations

        static void GetCourse()
        {
            ServiceFactory factory = new ServiceFactory();
            ICourseService cService = factory.CreateCourseService();

            Course course = cService.Get("e728a04a-3d2c-486f-a9bb-5f32ba338fc2"); // get user data by username

            if (cService.LastError != null)
            {
                Console.WriteLine("ErrorCode: " + cService.LastError.ErrorCode);
                Console.WriteLine("ErrorMessage: " + cService.LastError.ErrorMessage);
            }
            else
            {
                string name = course.Name;
                Console.WriteLine(string.Format("Name of course is {0}.", name));
            }
        }

        static void SearchCourses()
        {
            ServiceFactory factory = new ServiceFactory();
            ICourseService cService = factory.CreateCourseService();

            IEnumerable<Course> courses = cService.Search("Emre", "active"); // get users who contain User_ in their names, surnames, email addresses or usernames.

            if (cService.LastError != null)
            {
                Console.WriteLine("ErrorCode: " + cService.LastError.ErrorCode);
                Console.WriteLine("ErrorMessage: " + cService.LastError.ErrorMessage);
            }
            else
            {
                Console.WriteLine(string.Format("Found {0} users.", courses.Count()));
            }
        }

        static void UpdateCourse()
        {
            ServiceFactory factory = new ServiceFactory();
            ICourseService cService = factory.CreateCourseService();

            var course = new Course() {
                CourseGuid = Guid.Parse("e728a04a-3d2c-486f-a9bb-5f32ba338fc2"),
                Name = "Emre Kurs " + DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss")
            };

            bool success = cService.Update(course);

            if (!success)
            {
                Console.WriteLine("ErrorCode: " + cService.LastError.ErrorCode);
                Console.WriteLine("ErrorMessage: " + cService.LastError.ErrorMessage);
            }
            else
            {
                Console.WriteLine(string.Format("Course {0} was updated.", course.Name));
            }
        }

        static void DeleteCourse()
        {
            ServiceFactory factory = new ServiceFactory();
            ICourseService cService = factory.CreateCourseService();
            string CourseTrackingGuid = "e728a04a-3d2c-486f-a9bb-5f32ba338fc2";
            bool success = cService.Delete(CourseTrackingGuid);

            if (!success)
            {
                Console.WriteLine("ErrorCode: " + cService.LastError.ErrorCode);
                Console.WriteLine("ErrorMessage: " + cService.LastError.ErrorMessage);
            }
            else
            {
                Console.WriteLine(string.Format("Course {0} was deleted.", CourseTrackingGuid));
            }
        }

        static void CreateCourse()
        {
            ServiceFactory factory = new ServiceFactory();
            ICourseService cService = factory.CreateCourseService();

            var course = new Course()
            {
                Name = "Emrenin yeni kursu" + DateTime.Now.Ticks.ToString(),
                Description = "Description",
                CourseDefaultView = AlmsSdk.Domain.Enums.CourseViewType.Card,
                CourseAllowSelfEnrollment = false,
                Abbreviation = "EYK",
                MasterCourseGuid = Guid.Parse("948440d4-4803-44ff-a579-ded8d254aab8")
            };

            bool success = cService.Create(course);

            if (!success)
            {
                Console.WriteLine("ErrorCode: " + cService.LastError.ErrorCode);
                Console.WriteLine("ErrorMessage: " + cService.LastError.ErrorMessage);
            }
            else
            {
                Console.WriteLine(string.Format("Course {0} was deleted.", course.CourseGuid));
            }
        }

        #endregion

        #region sample master course operations

        static void UpdateMasterCourse()
        {
            ServiceFactory factory = new ServiceFactory();
            IMasterCourseService mcService = factory.CreateMasterCourseService();

            var masterCourse = new MasterCourse();
            // the following are required fields.
            masterCourse.MasterCourseGuid = "0af26721-bfdf-44c6-a832-25fd827b219f";
            masterCourse.Name = "Hasan New Master Course";
            masterCourse.Programs = null;//Programlarda değişiklik istenmiyorsa bu değer null geçilmeli.

            // the following are optional fields.
            masterCourse.Description = "Description";
            masterCourse.ShortDescription = "ShortDescription";
            masterCourse.Categories = new List<string>();
            masterCourse.Audiences = new List<string>();
            
            bool success = mcService.Update(masterCourse);

            if (!success)
            {
                Console.WriteLine("ErrorCode: " + mcService.LastError.ErrorCode);
                Console.WriteLine("ErrorMessage: " + mcService.LastError.ErrorMessage);
            }
            else
            {
                Console.WriteLine(string.Format("User {0} was created.", masterCourse.Name));
            }
        }

        static void GetMasterCourse()
        {
            ServiceFactory factory = new ServiceFactory();
            IMasterCourseService mcService = factory.CreateMasterCourseService();

            MasterCourse masterCourse = mcService.Get(Guid.Parse("948440d4-4803-44ff-a579-ded8d254aab8")); // get master course data by masterCourseGuid

            if (mcService.LastError != null)
            {
                Console.WriteLine("ErrorCode: " + mcService.LastError.ErrorCode);
                Console.WriteLine("ErrorMessage: " + mcService.LastError.ErrorMessage);
            }
            else
            {
                string name = masterCourse.Name;
                Console.WriteLine(string.Format("Name of master course is {0}.", masterCourse.Name));
            }
        }

        static void SearchMasterCourses()
        {
            ServiceFactory factory = new ServiceFactory();
            IMasterCourseService mcService = factory.CreateMasterCourseService();

            IEnumerable<MasterCourse> masterCourses = mcService.Search("sample", true); // get master course data by masterCourseGuid

            if (mcService.LastError != null)
            {
                Console.WriteLine("ErrorCode: " + mcService.LastError.ErrorCode);
                Console.WriteLine("ErrorMessage: " + mcService.LastError.ErrorMessage);
            }
            else
            {
                Console.WriteLine(string.Format("Master courses count is {0}.", masterCourses.Count()));
            }
        }

        static void CreateMasterCourse()
        {
            ServiceFactory factory = new ServiceFactory();
            IMasterCourseService mcService = factory.CreateMasterCourseService();

            var masterCourse = new MasterCourse();
            // the following are required fields.
            masterCourse.MasterCourseGuid = Guid.Empty.ToString();
            masterCourse.Name = "New Sample Master Course";
            masterCourse.Programs.Add(new OrganizationalUnit { OrganizationalUnitGuid = "9bf976fb-4800-47e0-a696-8456558d37cd" });

            // the following are optional fields.
            masterCourse.Description = "description";
            masterCourse.ShortDescription = "ShortDescription";
            masterCourse.Categories = new List<string>();
            masterCourse.Audiences = new List<string>();

            bool success = mcService.Create(masterCourse);

            if (!success)
            {
                Console.WriteLine("ErrorCode: " + mcService.LastError.ErrorCode);
                Console.WriteLine("ErrorMessage: " + mcService.LastError.ErrorMessage);
            }
            else
            {
                Console.WriteLine(string.Format("Master course {0} was created.", masterCourse.Name));
            }
        }

        static void DeleteMasterCourse()
        {
            ServiceFactory factory = new ServiceFactory();
            IMasterCourseService mcService = factory.CreateMasterCourseService();
            string masterCourseGuid = "948440d4-4803-44ff-a579-ded8d254aab8";
            bool success = mcService.Delete(masterCourseGuid);

            if (!success)
            {
                Console.WriteLine("ErrorCode: " + mcService.LastError.ErrorCode);
                Console.WriteLine("ErrorMessage: " + mcService.LastError.ErrorMessage);
            }
            else
            {
                Console.WriteLine(string.Format("Master Course {0} was deleted.", masterCourseGuid));
            }
        }

        #endregion

        #region sample program operations

        static void CreateProgram() 
        {
            ServiceFactory factory = new ServiceFactory();
            IOrganizationalUnitService ouService = factory.CreateOrganizationalUnitService();

            var program = new OrganizationalUnit();
            // the following are required fields.
            program.Name = "Sample Program Created By API";
            program.Abbreviation = "SPCBA";
            program.IsProgram = true;

            // the following are optional fields.
            
            bool success = ouService.Create(program);

            if (!success)
            {
                Console.WriteLine("ErrorCode: " + ouService.LastError.ErrorCode);
                Console.WriteLine("ErrorMessage: " + ouService.LastError.ErrorMessage);
            }
            else
            {
                Console.WriteLine(string.Format("User {0} was created.", program.Name));
            }
        }

        static void GetProgram() 
        {
            ServiceFactory factory = new ServiceFactory();
            IOrganizationalUnitService ouService = factory.CreateOrganizationalUnitService();

            OrganizationalUnit organizationalUnitList = ouService.Get("AEA29A06-63E8-4685-BBE2-D9AFCF161BE0");

            if (ouService.LastError != null)
            {
                Console.WriteLine("ErrorCode: " + ouService.LastError.ErrorCode);
                Console.WriteLine("ErrorMessage: " + ouService.LastError.ErrorMessage);
            }
            else
            {
                Console.WriteLine(string.Format("Name of organizational unit is {0}.", organizationalUnitList.Name));
            }
        }

        static void SearchProgram() 
        {
            ServiceFactory factory = new ServiceFactory();
            IOrganizationalUnitService ouService = factory.CreateOrganizationalUnitService();

            IEnumerable<OrganizationalUnit> organizationalUnitList = ouService.Search("pr", true); // get users who contain User_ in their names, surnames, email addresses or usernames.

            if (ouService.LastError != null)
            {
                Console.WriteLine("ErrorCode: " + ouService.LastError.ErrorCode);
                Console.WriteLine("ErrorMessage: " + ouService.LastError.ErrorMessage);
            }
            else
            {
                Console.WriteLine(string.Format("Found {0} users.", organizationalUnitList.Count()));
            }
        }

        static void UpdateProgram() 
        {
            ServiceFactory factory = new ServiceFactory();
            IOrganizationalUnitService ouService = factory.CreateOrganizationalUnitService();

            var oUnit = new OrganizationalUnit();
            // the following are required fields.
            oUnit.OrganizationalUnitGuid = "AEA29A06-63E8-4685-BBE2-D9AFCF161BE0";
            oUnit.Name = "Updated Organization Unit";

            // the following are optional.

            bool success = ouService.Update(oUnit);

            if (!success)
            {
                Console.WriteLine("ErrorCode: " + ouService.LastError.ErrorCode);
                Console.WriteLine("ErrorMessage: " + ouService.LastError.ErrorMessage);
            }
            else
            {
                Console.WriteLine(string.Format("User {0} was updated.", oUnit.Name));
            }
        }

        static void DeleteProgram() 
        {
            ServiceFactory factory = new ServiceFactory();
            IOrganizationalUnitService ouService = factory.CreateOrganizationalUnitService();

            string organizationalUnitGuid = "AEA29A06-63E8-4685-BBE2-D9AFCF161BE0";
            bool success = ouService.Delete(organizationalUnitGuid);

            if (!success)
            {
                Console.WriteLine("ErrorCode: " + ouService.LastError.ErrorCode);
                Console.WriteLine("ErrorMessage: " + ouService.LastError.ErrorMessage);
            }
            else
            {
                Console.WriteLine(string.Format("Organizational Unit [{0}] was deleted.", organizationalUnitGuid));
            }
        }

        #endregion
    }
}
