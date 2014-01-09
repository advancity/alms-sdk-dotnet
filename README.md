ALMS SDK.Net
===============
ALMS SDK.Net is a set of services to develop software on top of ALMS Web API. <a href="http://www.alms.com.tr" target="_blank">ALMS</a> is a learning management system which is being developed by <a href="http://www.advancity.com.tr" target="_blank">Advancity</a>.

You will find a solution which consists of two projects: the main SDK project and a console application which is for testing purposes.

ALMS SDK uses ALMS Web API to carry out operations. ALMS Web API is a RESTful web service. Currently, the API only supports 5 user management operations:
- Get
- Post (Create)
- Put (Update)
- Delete
- Search


<h3>How To Use</h3>

To use ALMS SDK in your project, you need to reference AlmsSdk.dll. It's located under alms-sdk-dotnet\AlmsSdk\bin\Debug

Also, you need to include the following configuration data in your web.config or app.config file:
  
    <add key="ALMSApiAccessKey" value="your-api-access-key"/>
    <add key="ALMSApiSecretKey" value="your-api-secret-key"/>
    <add key="ALMSBaseApiURI" value="your-alms-base-url"/>
    
A sample get operation in C# is as follows:
            
    ServiceFactory factory = new ServiceFactory();
    IUserService uService = factory.CreateUserService();
    
    var user = uService.Get("sample_user"); // get user data by username
    
    if (uService.LastError != null)
    {
        Console.WriteLine("ErrorCode: " + uService.LastError.ErrorCode);
        Console.WriteLine("ErrorMessage: " + uService.LastError.ErrorMessage);
    }
    else
    {
        string userName = user.UserName;
    }
