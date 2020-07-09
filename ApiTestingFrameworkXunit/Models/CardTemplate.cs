using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestingFrameworkXunit.Models
{
    public class CardTemplate
    {
        [JsonProperty("CardTemplateId")]
        public string CardTemplateId { get; set; }

        [JsonProperty("CardTemplateGuid")]
        public string CardTemplateGuid { get; set; }

        [JsonProperty("JourneyContextId")]
        public string JourneyContextId { get; set; }

        [JsonProperty("CardName")]
        public string CardName { get; set; }

        [JsonProperty("CardDescription")]
        public string CardDescription { get; set; }

        [JsonProperty("CardTemplateType")]
        public string CardTemplateType { get; set; }

        [JsonProperty("CardType")]
        public int CardType { get; set; }

        [JsonProperty("CardStyle")]
        public string CardStyle { get; set; }

        [JsonProperty("ContentCategory")]
        public string ContentCategory { get; set; }

        [JsonProperty("ContentSourceGuid")]
        public string ContentSourceGuid { get; set; }

        [JsonProperty("ValidStartDate")]
        public string ValidStartDate { get; set; }

        [JsonProperty("ExpirationDate")]
        public string ExpirationDate { get; set; }

        [JsonProperty("ExpiresInDays")]
        public string ExpiresInDays { get; set; }

        [JsonProperty("ExpiresInViews")]
        public string ExpiresInViews { get; set; }

        [JsonProperty("ExpiresFromSource")]
        public bool ExpiresFromSource { get; set; }

        [JsonProperty("CallToAction")]
        public string CallToAction { get; set; }

        [JsonProperty("IncentiveActionCategoryId")]
        public string IncentiveActionCategoryId { get; set; }

        [JsonProperty("RemoveAfterCallToActionTimes")]
        public string RemoveAfterCallToActionTimes { get; set; }

        [JsonProperty("IsGenerated")]
        public bool IsGenerated { get; set; }

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }

        [JsonProperty("GroupId")]
        public string GroupId { get; set; }

        [JsonProperty("PlatformSupport")]
        public string PlatformSupport { get; set; }

        [JsonProperty("InsertedByActorId")]
        public string InsertedByActorId { get; set; }

        [JsonProperty("UpdatedByActorId")]
        public string UpdatedByActorId { get; set; }

        [JsonProperty("InsertedDate")]
        public string InsertedDate { get; set; }

        [JsonProperty("UpdatedDate")]
        public string UpdatedDate { get; set; }

        [JsonProperty("DueDate")]
        public string DueDate { get; set; }

        [JsonProperty("Components")]
        public List<Component> Components { get; set; }

        [JsonProperty("DisplayPriority")]
        public string DisplayPriority { get; set; }

        [JsonProperty("ClosingActionIds")]
        public List<string> ClosingActionIds { get; set; }

        [JsonProperty("TagFilter")]
        public string TagFilter { get; set; }

        [JsonProperty("RowUpdatedBy")]
        public string RowUpdatedBy { get; set; }

        [JsonProperty("RowInsertedBy")]
        public string RowInsertedBy { get; set; }
    }
}
