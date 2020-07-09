using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestingFrameworkXunit.Models
{
    public class Group
    {
        [JsonProperty("GroupId")]
        public int GroupId { get; set; }

        [JsonProperty("GroupName")]
        public string GroupName { get; set; }
    }
}
