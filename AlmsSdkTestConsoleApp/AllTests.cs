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
using AlmsSdk.ServiceContracts;
using AlmsSdk.Service;

namespace AlmsSdkTestConsoleApp
{
    class AllTests
    {
        static Guid programGuid;
        static void Main(string[] args)
        {
            /* The following methods tests SDK methods and writes to the console output.
             * Before running this application, please check app.config to set ALSM API credentials and ALMS base url.
             */

            string loginToken = GetLoginToken();
            bool success = ExpireLoginToken();


            Guid masterCourseGuid = Guid.Empty, courseGuid = Guid.Empty, classGuid = Guid.Empty;

            string username = "sample_user_" + DateTime.Now.Ticks.ToString();
            programGuid = CreateProgram();

            CreateUser(username);
            GetUser(username);
            SearchUsers(username);
            UpdateUser(username);

            if (programGuid != Guid.Empty)
            {
                GetProgram(programGuid);
                SearchProgram("created by API");
                UpdateProgram(programGuid);

                masterCourseGuid = CreateMasterCourse(programGuid);
                if (masterCourseGuid != Guid.Empty)
                {
                    GetMasterCourse(masterCourseGuid);
                    SearchMasterCourses("Test Master Course");
                    UpdateMasterCourse(masterCourseGuid);


                    courseGuid = CreateCourse(masterCourseGuid);
                    if (courseGuid != Guid.Empty)
                    {
                        GetCourse(courseGuid);
                        SearchCourses("test course");
                        UpdateCourse(courseGuid);

                        classGuid = CreateClass(courseGuid, programGuid);
                        if (classGuid != Guid.Empty)
                        {
                            EnrollUsers(classGuid, username);
                        }

                    }
                }
            }



            DeleteUser(username);
            if (courseGuid != Guid.Empty) DeleteCourse(courseGuid);
            if (masterCourseGuid != Guid.Empty) DeleteMasterCourse(masterCourseGuid);
            if (programGuid != Guid.Empty) DeleteProgram(programGuid);



            Console.ReadLine();
        }

        #region sample user operations

        static string GetLoginToken() 
        {
            ServiceFactory factory = new ServiceFactory();
            IUserService uService = factory.CreateUserService();

            var username = "api_test_user";

            return uService.GetLoginToken(username);
        }

        static bool ExpireLoginToken()
        {
            ServiceFactory factory = new ServiceFactory();
            IUserService uService = factory.CreateUserService();

            var username = "api_test_user";

            return uService.ExpireLoginToken(username);
        }

        static void CreateUser(string username)
        {
            ServiceFactory factory = new ServiceFactory();
            IUserService uService = factory.CreateUserService();

            var user = new User();
            // the following are required fields.
            user.UserName = username;
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
            user.ProgramGuids = programGuid.ToString();

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
                printError(uService.LastError);
            }
            else
            {
                Console.WriteLine(string.Format("User {0} was created.", user.UserName));
            }
        }

        static void GetUser(string username)
        {
            ServiceFactory factory = new ServiceFactory();
            IUserService uService = factory.CreateUserService();

            User user = uService.Get(username);

            if (uService.LastError != null)
            {
                printError(uService.LastError);
            }
            else
            {
                string name = user.FirstName + " " + user.LastName;
                Console.WriteLine(string.Format("Name of user {0} is {1}.", user.UserName, name));
            }
        }

        static void SearchUsers(string keyword)
        {
            ServiceFactory factory = new ServiceFactory();
            IUserService uService = factory.CreateUserService();

            IEnumerable<User> users = uService.Search(keyword); // get users who contain User_ in their names, surnames, email addresses or usernames.

            if (uService.LastError != null)
            {
                printError(uService.LastError);
            }
            else
            {
                Console.WriteLine(string.Format("Found {0} users.", users.Count()));
            }
        }

        static void UpdateUser(string username, string programGuid = "")
        {
            ServiceFactory factory = new ServiceFactory();
            IUserService uService = factory.CreateUserService();

            var user = new User();
            // the following are required fields.
            user.UserName = username;
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
            user.ProgramGuids = "";

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
                printError(uService.LastError);
            }
            else
            {
                Console.WriteLine(string.Format("User {0} was updated.", user.UserName));
            }
        }

        static void DeleteUser(string username)
        {
            ServiceFactory factory = new ServiceFactory();
            IUserService uService = factory.CreateUserService();
            bool success = uService.Delete(username);

            if (!success)
            {
                printError(uService.LastError);
            }
            else
            {
                Console.WriteLine(string.Format("User {0} was deleted.", username));
            }
        }

        static void EnrollUsers(Guid classGuid, params string[] usernames)
        {
            ServiceFactory factory = new ServiceFactory();
            IUserService uService = factory.CreateUserService();

            bool success = uService.Enroll(classGuid, usernames);

            if (!success)
            {
                printError(uService.LastError);
            }
            else
            {
                Console.WriteLine("All users enrolled.");
            }
        }

        #endregion

        #region sample course operations

        static void GetCourse(Guid courseGuid)
        {
            ServiceFactory factory = new ServiceFactory();
            ICourseService cService = factory.CreateCourseService();

            Course course = cService.Get(courseGuid);

            if (cService.LastError != null)
            {
                printError(cService.LastError);
            }
            else
            {
                string name = course.Name;
                Console.WriteLine(string.Format("Name of course is {0}.", name));
            }
        }

        static void SearchCourses(string keyword)
        {
            ServiceFactory factory = new ServiceFactory();
            ICourseService cService = factory.CreateCourseService();

            IEnumerable<Course> courses = cService.Search(keyword, true);

            if (cService.LastError != null)
            {
                printError(cService.LastError);
            }
            else
            {
                Console.WriteLine(string.Format("Found {0} courses.", courses.Count()));
            }
        }

        static void UpdateCourse(Guid courseGuid)
        {
            ServiceFactory factory = new ServiceFactory();
            ICourseService cService = factory.CreateCourseService();

            var course = new Course()
            {
                CourseGuid = courseGuid,
                Name = "Test Course Modified " + DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss")
            };

            bool success = cService.Update(course);

            if (!success)
            {
                printError(cService.LastError);
            }
            else
            {
                Console.WriteLine(string.Format("Name of course {0} was updated to {1}.", courseGuid, course.Name));
            }
        }

        static void DeleteCourse(Guid courseGuid)
        {
            ServiceFactory factory = new ServiceFactory();
            ICourseService cService = factory.CreateCourseService();
            bool success = cService.Delete(courseGuid);
            if (!success)
            {
                printError(cService.LastError);
            }
            else
            {
                Console.WriteLine(string.Format("Course {0} was deleted.", courseGuid));
            }
        }

        static Guid CreateCourse(Guid masterCourseGuid)
        {
            ServiceFactory factory = new ServiceFactory();
            ICourseService cService = factory.CreateCourseService();

            var course = new Course()
            {
                Name = "Test Course",
                Description = "Test course description",
                CourseDefaultView = AlmsSdk.Domain.Enums.CourseViewType.Card,
                CourseAllowSelfEnrollment = false,
                Abbreviation = "TTC",
                MasterCourseGuid = masterCourseGuid
            };

            Guid courseGuid = cService.Create(course);

            if (courseGuid == Guid.Empty)
            {
                printError(cService.LastError);
            }
            else
            {
                Console.WriteLine(string.Format("Course {0} was created.", courseGuid));
            }
            return courseGuid;
        }

        static void AddTeacherToCourse()
        {
            ServiceFactory factory = new ServiceFactory();
            ICourseService cService = factory.CreateCourseService();

            string courseGuid = "1bd0d136-14d8-4ece-886e-b2614fbc8953";

            List<string> teacherList = new List<string>() 
            {
                "user_10",
                "user_11"
            };

            bool success = cService.AddTeachers(courseGuid, teacherList);

            if (!success)
            {
                printError(cService.LastError);
            }
            else
            {
                Console.WriteLine(string.Format("Teachers are added specified class {0}.", courseGuid));
            }
        }

        static void RemoveTeacherToCourse()
        {
            ServiceFactory factory = new ServiceFactory();
            ICourseService cService = factory.CreateCourseService();

            string courseGuid = "1bd0d136-14d8-4ece-886e-b2614fbc8953";

            List<string> teacherList = new List<string>() 
            {
                "user_10",
                "user_11"
            };

            bool success = cService.RemoveTeachers(courseGuid, teacherList);

            if (!success)
            {
                printError(cService.LastError);
            }
            else
            {
                Console.WriteLine(string.Format("Teachers are added specified class {0}.", courseGuid));
            }
        }

        #endregion

        #region sample master course operations

        static void UpdateMasterCourse(Guid masterCourseGuid)
        {
            ServiceFactory factory = new ServiceFactory();
            IMasterCourseService mcService = factory.CreateMasterCourseService();

            var masterCourse = new MasterCourse();
            // the following are required fields.
            masterCourse.MasterCourseGuid = masterCourseGuid;
            masterCourse.Name = "Test Master Course - Modified";
            masterCourse.Programs = null; //Programlarda değişiklik istenmiyorsa bu değer null geçilmeli.

            // the following are optional fields.
            masterCourse.Description = "Description";
            masterCourse.ShortDescription = "ShortDescription";
            masterCourse.Categories = new List<string>();
            masterCourse.Audiences = new List<string>();

            bool success = mcService.Update(masterCourse);

            if (!success)
            {
                printError(mcService.LastError);
            }
            else
            {
                Console.WriteLine(string.Format("Name of master course {0} was updated to {1}.", masterCourse.MasterCourseGuid, masterCourse.Name));
            }
        }

        static void GetMasterCourse(Guid masterCourseGuid)
        {
            ServiceFactory factory = new ServiceFactory();
            IMasterCourseService mcService = factory.CreateMasterCourseService();

            MasterCourse masterCourse = mcService.Get(masterCourseGuid); // get master course data by masterCourseGuid

            if (mcService.LastError != null)
            {
                printError(mcService.LastError);
            }
            else
            {
                string name = masterCourse.Name;
                Console.WriteLine(string.Format("Name of master course is {0}.", masterCourse.Name));
            }
        }

        static void SearchMasterCourses(string keyword)
        {
            ServiceFactory factory = new ServiceFactory();
            IMasterCourseService mcService = factory.CreateMasterCourseService();

            IEnumerable<MasterCourse> masterCourses = mcService.Search(keyword, true); // get master course data by masterCourseGuid

            if (mcService.LastError != null)
            {
                printError(mcService.LastError);
            }
            else
            {
                Console.WriteLine(string.Format("Master course count is {0}.", masterCourses.Count()));
            }
        }

        static Guid CreateMasterCourse(Guid organizationalUnitGuid)
        {
            ServiceFactory factory = new ServiceFactory();
            IMasterCourseService mcService = factory.CreateMasterCourseService();

            var masterCourse = new MasterCourse();
            // the following are required fields.
            masterCourse.MasterCourseGuid = Guid.Empty;
            masterCourse.Name = "Test Master Course";
            masterCourse.Programs.Add(organizationalUnitGuid);

            // the following are optional fields.
            masterCourse.Description = "master course description";
            masterCourse.ShortDescription = "ShortDescription";
            masterCourse.Categories = new List<string>();
            masterCourse.Audiences = new List<string>();

            var masterCourseGuid = mcService.Create(masterCourse);

            if (masterCourseGuid == Guid.Empty)
            {
                printError(mcService.LastError);
            }
            else
            {
                Console.WriteLine(string.Format("Master course {0} was created.", masterCourse.Name));
            }
            return masterCourseGuid;
        }

        static void DeleteMasterCourse(Guid masterCourseGuid)
        {
            ServiceFactory factory = new ServiceFactory();
            IMasterCourseService mcService = factory.CreateMasterCourseService();
            bool success = mcService.Delete(masterCourseGuid);

            if (!success)
            {
                printError(mcService.LastError);
            }
            else
            {
                Console.WriteLine(string.Format("Master course {0} was deleted.", masterCourseGuid));
            }
        }

        #endregion

        #region sample program operations

        static Guid CreateProgram()
        {
            ServiceFactory factory = new ServiceFactory();
            IOrganizationalUnitService ouService = factory.CreateOrganizationalUnitService();

            var program = new OrganizationalUnit();
            // the following are required fields.
            program.Name = "A sample program created by API";
            program.Abbreviation = "TPCBA";
            program.IsProgram = true;

            // the following are optional fields.
            Guid guid = ouService.Create(program);
            bool success = guid != Guid.Empty;

            if (!success)
            {
                Console.WriteLine("ErrorCode: " + ouService.LastError.ErrorCode);
                Console.WriteLine("ErrorMessage: " + ouService.LastError.ErrorCodeString);
                return Guid.Empty;
            }
            else
            {
                Console.WriteLine(string.Format("Program {0} was created.", program.Name));
                return guid;
            }
        }

        static void GetProgram(Guid organizationalUnitGuid)
        {
            ServiceFactory factory = new ServiceFactory();
            IOrganizationalUnitService ouService = factory.CreateOrganizationalUnitService();

            OrganizationalUnit organizationalUnit = ouService.Get(organizationalUnitGuid);

            if (ouService.LastError != null)
            {
                Console.WriteLine("ErrorCode: " + ouService.LastError.ErrorCode);
                Console.WriteLine("ErrorMessage: " + ouService.LastError.ErrorCodeString);
            }
            else
            {
                Console.WriteLine(string.Format("Name of organizational unit is {0}.", organizationalUnit.Name));
            }
        }

        static void SearchProgram(string keyword)
        {
            ServiceFactory factory = new ServiceFactory();
            IOrganizationalUnitService ouService = factory.CreateOrganizationalUnitService();

            IEnumerable<OrganizationalUnit> organizationalUnitList = ouService.Search(keyword, true);

            if (ouService.LastError != null)
            {
                Console.WriteLine("ErrorCode: " + ouService.LastError.ErrorCode);
                Console.WriteLine("ErrorMessage: " + ouService.LastError.ErrorCodeString);
            }
            else
            {
                Console.WriteLine(string.Format("Found {0} programs.", organizationalUnitList.Count()));
            }
        }

        static void UpdateProgram(Guid organizationalUnitGuid)
        {
            ServiceFactory factory = new ServiceFactory();
            IOrganizationalUnitService ouService = factory.CreateOrganizationalUnitService();

            var oUnit = new OrganizationalUnit();
            // the following are required fields.
            oUnit.OrganizationalUnitGuid = new Guid(organizationalUnitGuid.ToString());
            oUnit.Name = "Updated Organization Unit";

            // the following are optional.

            bool success = ouService.Update(oUnit);

            if (!success)
            {
                Console.WriteLine("ErrorCode: " + ouService.LastError.ErrorCode);
                Console.WriteLine("ErrorMessage: " + ouService.LastError.ErrorCodeString);
            }
            else
            {
                Console.WriteLine(string.Format("User {0} was updated.", oUnit.Name));
            }
        }

        static void DeleteProgram(Guid organizationalUnitGuid)
        {
            ServiceFactory factory = new ServiceFactory();
            IOrganizationalUnitService ouService = factory.CreateOrganizationalUnitService();

            bool success = ouService.Delete(organizationalUnitGuid);

            if (!success)
            {
                Console.WriteLine("ErrorCode: " + ouService.LastError.ErrorCode);
                Console.WriteLine("ErrorMessage: " + ouService.LastError.ErrorCodeString);
            }
            else
            {
                Console.WriteLine(string.Format("Organizational Unit [{0}] was deleted.", organizationalUnitGuid));
            }
        }

        #endregion

        #region sample class operations

        static Guid CreateClass(Guid courseGuid, Guid programGuid)
        {
            ServiceFactory factory = new ServiceFactory();
            IClassService cService = factory.CreateClassService();

            var _class = new Class();
            // the following are required fields.
            _class.Name = "This is test class";
            _class.CourseGuid = courseGuid;
            _class.ProgramGuid = programGuid;

            // the following are optional fields.
            _class.StartDate = null;
            _class.EndDate = null;

            Guid classGuid = cService.Create(_class);

            if (classGuid == Guid.Empty)
            {
                printError(cService.LastError);
            }
            else
            {
                Console.WriteLine(string.Format("Class {0} was created.", _class.Name));
            }
            return classGuid;
        }

        static void AddTeacherToClass()
        {
            ServiceFactory factory = new ServiceFactory();
            IClassService cService = factory.CreateClassService();

            string classGuid = "d3a65d5b-2045-47db-a326-ab787a2fe371";

            List<string> teacherList = new List<string>() 
            {
                "user_10",
                "user_11"
            };

            bool success = cService.AddTeachers(classGuid, teacherList);

            if (!success)
            {
                printError(cService.LastError);
            }
            else
            {
                Console.WriteLine(string.Format("Teachers are added specified class {0}.", classGuid));
            }
        }

        static void RemoveTeacherFromClass()
        {
            ServiceFactory factory = new ServiceFactory();
            IClassService cService = factory.CreateClassService();

            string classGuid = "d3a65d5b-2045-47db-a326-ab787a2fe371";

            List<string> teacherList = new List<string>() 
            {
                "user_10",
                "user_11"
            };

            bool success = cService.RemoveTeachers(classGuid, teacherList);

            if (!success)
            {
                printError(cService.LastError);
            }
            else
            {
                Console.WriteLine(string.Format("Teachers are added specified class {0}.", classGuid));
            }
        }

        #endregion

        private static void printError(Error error)
        {
            if (error == null) return;
            Console.WriteLine("ErrorCode: " + error.ErrorCode);
            Console.WriteLine("ErrorCodeString: " + error.ErrorCodeString);
            Console.WriteLine("Message: " + error.Message);
        }

    }
}
