using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmsSdk.Domain
{
    public enum UserType : int
    {
        User = 0,
        SuperAdmin = 1, // for future use
        Admin = 2,
        Teacher = 4,
        Student = 8,
        Parent = 16,
        ProgramAdmin = 32,
        ProgramUser = 64,
        Guest = 128 // for future use
    }
}