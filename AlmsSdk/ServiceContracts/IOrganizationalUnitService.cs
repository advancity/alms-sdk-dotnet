using AlmsSdk.Domain;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlmsSdk.ServiceContracts
{
    public interface IOrganizationalUnitService
    {
        bool Create(OrganizationalUnit OrganizationalUnit);
        OrganizationalUnit Get(string OrganizationalUnitGuid);
        IEnumerable<OrganizationalUnit> Search(string Keyword, bool IsProgram);
        bool Update(OrganizationalUnit OrganizationalUnit);
        bool Delete(string OrganizationalUnitGuid);
        AuthConfig config { get; set; }
        RestClient client { get; set; }
        Error LastError { get; set; }
    }
}
