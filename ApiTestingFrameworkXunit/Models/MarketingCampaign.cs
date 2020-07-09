using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestingFrameworkXunit.Models
{
    public class MarketingCampaign:Model
    {
        [JsonProperty("MarketingCampaignId")]
        public string MarketingCampaignId { get; set; }

        [JsonProperty("MarketingCampaignGuid")]
        public string MarketingCampaignGuid { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("JourneyContext")]
        public JourneyContext JourneyContext { get; set; }

        [JsonProperty("MarketingCampaignCardList")]
        public List<MarketingCampaignCard> MarketingCampaignCardList { get; set; }

        [JsonProperty("RowInsertedBy")]
        public string RowInsertedBy { get; set; }

        [JsonProperty("RowInsertedDate")]
        public string RowInsertedDate { get; set; }

        [JsonProperty("RowUpdatedBy")]
        public string RowUpdatedBy { get; set; }

        [JsonProperty("RowUpdatedDate")]
        public string RowUpdatedDate { get; set; }

        [JsonProperty("TotalRecords")]
        public int TotalRecords { get; set; }

        public MarketingCampaign()
        { }

        public MarketingCampaign(Boolean generate)
        {
            Name = $"AutobotMarketingCampaign_{Faker.Name.Last()}";
            MarketingCampaignGuid = null;
        }

    }
}
