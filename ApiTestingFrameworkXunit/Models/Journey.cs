using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestingFrameworkXunit.Models
{
    public class Journey
    {
        [JsonProperty("JourneyId")]
        public string JourneyId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("GroupId")]
        public string GroupId { get; set; }

        [JsonProperty("GroupGuid")]
        public string GroupGuid { get; set; }

        [JsonProperty("JourneyTemplateId")]
        public string JourneyTemplateId { get; set; }

        [JsonProperty("JourneyRule")]
        public List<JourneyRule> JourneyRule { get; set; }

        [JsonProperty("JourneyConfigurationId")]
        public string JourneyConfigurationId { get; set; }

        [JsonProperty("JourneyCategory")]
        public string JourneyCategory { get; set; }

        [JsonProperty("Priority")]
        public string Priority { get; set; }

        [JsonProperty("IsClinical")]
        public bool IsClinical { get; set; }

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }

        [JsonProperty("RequiresStartCard")]
        public bool RequiresStartCard { get; set; }

        [JsonProperty("ValidStartDate")]
        public string ValidStartDate { get; set; }

        [JsonProperty("ExpirationDate")]
        public string ExpirationDate { get; set; }

        [JsonProperty("UpdatingActorId")]
        public string UpdatingActorId { get; set; }

        //[JsonProperty("RuleName")]
        //public string RuleName { get; set; }

        //[JsonProperty("RuleDescription")]
        //public string RuleDescription { get; set; }

        //[JsonProperty("CanDelete")]
        //public bool CanDelete { get; set; }

        [JsonProperty("JourneyCards")]
        public List<JourneyCard> JourneyCards { get; set; }
    }
}
