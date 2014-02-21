using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlmsSdk.Domain
{
    /// <summary>
    /// This class is to handle put and post responses which turn content as follows:
    /// {"id":"trackingguid or username"}
    /// </summary>
    class ApiObjectId
    {
        public string Id { get; set; }
    }
}
