using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestingFrameworkXunit.Models
{
    public class MarketingCampaignCardList
    {
        [JsonProperty("MarketingCampaignCardId")]
        public string MarketingCampaignCardId { get; set; }

        [JsonProperty("MarketingCampaignId")]
        public string MarketingCampaignId { get; set; }

        [JsonProperty("CardTemplate")]
        public CardTemplate CardTemplate { get; set; }

        [JsonProperty("StartDate")]
        public string StartDate { get; set; }

        [JsonProperty("EndDate")]
        public string EndDate { get; set; }

        [JsonProperty("SortOrder")]
        public string SortOrder { get; set; }
    }
}
