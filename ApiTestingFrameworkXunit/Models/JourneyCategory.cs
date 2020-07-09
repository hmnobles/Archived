using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestingFrameworkXunit.Models
{
    public class JourneyCategory
    {
        [JsonProperty("JourneyCategoryId")]
        public string JourneyCategoryId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("IsClinical")]
        public bool IsClinical { get; set; }

        [JsonProperty("RequiresJourneyStartCard")]
        public bool RequiresJourneyStartCard { get; set; }

        [JsonProperty("Priority")]
        public string Priority { get; set; }

        [JsonProperty("Journeys")]
        public List<object> Journeys { get; set; }
    }
}
