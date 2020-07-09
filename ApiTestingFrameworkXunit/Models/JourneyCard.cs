using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestingFrameworkXunit.Models
{
    public class JourneyCard
    {
        [JsonProperty("JourneyTemplateCardId")]
        public string JourneyTemplateCardId { get; set; }

        [JsonProperty("JourneyTemplateId")]
        public string JourneyTemplateId { get; set; }

        [JsonProperty("CardTemplateId")]
        public string CardTemplateId { get; set; }

        [JsonProperty("DisplayOrder")]
        public string DisplayOrder { get; set; }

        [JsonProperty("IsRequired")]
        public bool IsRequired { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("IconKey")]
        public string IconKey { get; set; }

        [JsonProperty("CardTemplateGuid")]
        public string CardTemplateGuid { get; set; }

        [JsonProperty("ImageUrl")]
        public string ImageUrl { get; set; }
    }
}
