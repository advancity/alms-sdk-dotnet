using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlmsSdk.Domain
{
    public class Organization
    {
        public Organization()
        {
            AllowAdvertisement = false;
            Culture = "tr-TR";
        }

        public Guid OrganizationGuid { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        //public int Port { get; set; }
        public string Culture { get; set; }
        public bool? AllowAdvertisement { get; set; }

        /*Adminstrator User Informations*/
        public string AdministratorUsername { get; set; }
        public string AdministratorPassword { get; set; }
        public string AdministratorEmail { get; set; }
        public string AdministratorFirstname { get; set; }
        public string AdministratorLastname { get; set; }
        public string AdministratorGender { get; set; }
    }
}
