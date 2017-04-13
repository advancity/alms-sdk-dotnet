using AlmsSdk.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmsSdk.Service
{
    using Services;
    using ServiceContracts;

    public class ServiceFactory
    {
        public AuthConfig AuthConfig { get; set; }
        public string BaseApiURI { get; set; }
        public ServiceFactory()
        {
            AuthConfig = new AuthConfig();
            AuthConfig.ApiAccessKey = ConfigurationManager.AppSettings["ALMSApiAccessKey"];
            AuthConfig.ApiSecretKey = ConfigurationManager.AppSettings["ALMSApiSecretKey"];
            BaseApiURI = ConfigurationManager.AppSettings["ALMSBaseApiURI"];
        }
        public IUserService CreateUserService()
        {
            UserService userService = new UserService(AuthConfig, BaseApiURI);
            return userService;
        }

        public ICourseService CreateCourseService()
        {
            CourseService courseService = new CourseService(AuthConfig, BaseApiURI);
            return courseService;
        }

        public IMasterCourseService CreateMasterCourseService()
        {
            MasterCourseService masterCourseService = new MasterCourseService(AuthConfig, BaseApiURI);
            return masterCourseService;
        }

        public IOrganizationalUnitService CreateOrganizationalUnitService()
        {
            OrganizationalUnitService programService = new OrganizationalUnitService(AuthConfig, BaseApiURI);
            return programService;
        }

        public IClassService CreateClassService()
        {
            ClassService classService = new ClassService(AuthConfig, BaseApiURI);
            return classService;
        }

        public IGroupService CreateGroupService()
        {
            GroupService groupService = new GroupService(AuthConfig, BaseApiURI);
            return groupService;
        }

        public IOrganizationService CreateOrganizationService()
        {
            OrganizationService organizationService = new OrganizationService(AuthConfig, BaseApiURI);
            return organizationService;
        }
        public ITermService CreateTermService()
        {
            TermService termService = new TermService(AuthConfig, BaseApiURI);
            return termService;
        }
        public IEnrollmentService CreateEnrollmentService()
        {
            EnrollmentService enrollmentService = new EnrollmentService(AuthConfig, BaseApiURI);
            return enrollmentService;
        }
    }
}
