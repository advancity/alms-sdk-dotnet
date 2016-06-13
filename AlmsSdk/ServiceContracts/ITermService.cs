using AlmsSdk.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlmsSdk.ServiceContracts
{
    public interface ITermService : IService
    {
        Term Get(Guid termGuid );
        IEnumerable<TermWeek> GetTermWeek(Guid termGuid);
        IEnumerable<Term> SerachTerm(string keyword);
    }
}
