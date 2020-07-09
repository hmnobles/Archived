using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestingFrameworkXunit.Models
{
    public class JourneyConfigurationGroupMap
    {
        [JsonProperty("JourneyConfigurationId")]
        public int JourneyConfigurationId { get; set; }

        [JsonProperty("GroupId")]
        public int GroupId { get; set; }

        [JsonProperty("GroupName")]
        public string GroupName { get; set; }

        [JsonProperty("StartDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty("EndDate")]
        public DateTime EndDate { get; set; }
    }
}
