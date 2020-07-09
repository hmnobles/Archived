using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestingFrameworkXunit.Models
{
    public class GroupSearchResults
    {
        [JsonProperty("TotalRecords")]
        public int TotalRecords { get; set; }

        [JsonProperty("Results")]
        public List<Group> Results { get; set; }
    }
}
