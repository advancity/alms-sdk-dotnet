using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlmsSdk.Domain
{
    public class Term
    {
        public Term()
        {
        }
        public Guid TermGuid { get; set; }
        public string Name { get; set; }
        public string TermType { get; set; }
    }
}
