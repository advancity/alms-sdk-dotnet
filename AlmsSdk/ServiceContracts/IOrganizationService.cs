using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlmsSdk.Domain;
using RestSharp;

namespace AlmsSdk.ServiceContracts
{
    public interface IOrganizationService : IService
    {
        bool Create(Organization organization);
        string OrganizationId { get; set; }
    }
}
