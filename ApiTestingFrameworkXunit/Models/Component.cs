using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestingFrameworkXunit.Models
{
    public class Component
    {
        [JsonProperty("CardTemplateId")]
        public string CardTemplateId { get; set; }

        [JsonProperty("CardTemplateGuid")]
        public string CardTemplateGuid { get; set; }

        [JsonProperty("CardComponent")]
        public Component CardComponent { get; set; }

        [JsonProperty("CardComponentType")]
        public string CardComponentType { get; set; }

        [JsonProperty("CardLanguage")]
        public string CardLanguage { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }
    }
}
