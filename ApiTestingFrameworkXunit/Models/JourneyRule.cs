using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestingFrameworkXunit.Models
{
    public class JourneyRule
    {
        [JsonProperty("JourneyRuleId")]
        public string JourneyRuleId { get; set; }

        [JsonProperty("JourneyRuleGuid")]
        public string JourneyRuleGuid { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("JourneyCategoryId")]
        public string JourneyCategoryId { get; set; }

        [JsonProperty("IsMultipleAllowed")]
        public bool IsMultipleAllowed { get; set; }

        [JsonProperty("IsEditable")]
        public bool IsEditable { get; set; }

        [JsonProperty("TriggeringActions")]
        public List<object> TriggeringActions { get; set; }

        [JsonProperty("JourneyContextId")]
        public string JourneyContextId { get; set; }

        [JsonProperty("JourneyContextName")]
        public string JourneyContextName { get; set; }
    }
}
