using AlmsSdk.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlmsSdk.ServiceContracts
{
    public interface IService
    {
        Error LastError { get; }
    }
}
