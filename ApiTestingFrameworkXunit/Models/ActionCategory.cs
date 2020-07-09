using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestingFrameworkXunit.Models
{
    public class ActionCategory
    {
        [JsonProperty("ActionCategoryTypeId")]
        public string ActionCategoryTypeId { get; set; }

        [JsonProperty("ActionCategoryTypeName")]
        public string ActionCategoryTypeName { get; set; }

        [JsonProperty("ActionCategoryId")]
        public string ActionCategoryId { get; set; }
    }
}
