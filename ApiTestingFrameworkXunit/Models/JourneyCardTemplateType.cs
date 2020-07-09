using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestingFrameworkXunit.Models
{
    public class JourneyCardTemplateType
    {
        [JsonProperty("CardTemplateTypeId")]
        public string CardTemplateTypeId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("IncentiveActionCategoryId")]
        public string IncentiveActionCategoryId { get; set; }

        [JsonProperty("ForAdminTool")]
        public bool ForAdminTool { get; set; }

        [JsonProperty("AllowedPlatforms")]
        public List<string> AllowedPlatforms { get; set; }

        [JsonProperty("ContentCategory")]
        public string ContentCategory { get; set; }

        [JsonProperty("CallToAction")]
        public string CallToAction { get; set; }

        [JsonProperty("RemoveAfterCallToActionTimes")]
        public string RemoveAfterCallToActionTimes { get; set; }

        [JsonProperty("CloseAfterActionIds")]
        public List<string> CloseAfterActionIds { get; set; } 
    }
}
