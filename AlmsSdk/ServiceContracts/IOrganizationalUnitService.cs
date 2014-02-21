using AlmsSdk.Domain;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlmsSdk.ServiceContracts
{
    public interface IOrganizationalUnitService : IService
    {
        Guid Create(OrganizationalUnit organizationalUnit);
        OrganizationalUnit Get(Guid organizationalUnitGuid);
        IEnumerable<OrganizationalUnit> Search(string keyword, bool isProgram = false, bool isActive = true);
        bool Update(OrganizationalUnit organizationalUnit);
        bool Delete(Guid organizationalUnitGuid);
    }
}
