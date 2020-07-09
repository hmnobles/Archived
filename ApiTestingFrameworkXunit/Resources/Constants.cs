using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestingFrameworkXunit.Resources
{
    public static class Constants
    {
        #region Journeys

        public static string EndpointRoute = "https://services2.onlifehealth.com/engagementhub/api";
        public static string GetAllJourneyCategories = "/engagementstreams/journeycategory";
        public static string GetAllJourneyCards = "/engagementstreams/journeycategory/journeycardinfo";
        public static string GetAllActorActionsDataTypes = "/engagementstreams/actoractionstatusdatatype";
        public static string GetAllJourneyTemplates = "/engagementstreams/journeytemplate";
        public static string GetJourneyTemplatesByCategoryId =
            "/engagementstreams/journeycategory/{JourneyCategoryId}/journeytemplate";
        public static string GetPostJourneyRules = "/engagementstreams/journeyrule";
        public static string GetAllJourneyRulesByContextId = "/engagementstreams/journeyrule/context/{JourneyContextId}";
        public static string GetPutDeleteJourneyTemplateByTemplateId = "/engagementstreams/journeytemplate/{JourneyTemplateId}"; 
        public static string GetPutDeleteJourneyByJourneyId = "/engagementstreams/journey/{JourneyId}";
        public static string GetJourneysByGroupId = "/engagementstreams/group/{GroupId}/journey";
        public static string GetInactiveJourneysByGroupId = "/engagementstreams/group/{GroupId}/journey/inactive";
        public static string PutUpdateJourneyPriorityByJourneyConfigurationId = "/engagementstreams/cardtemplate/journeys/{journeyConfigurationId}/reprioritize";
        public static string GetJourneyRuleByJourneyTemplateId = "/engagementstreams/journeytemplate/{journeyTemplateId}/journeyrule";
        public static string GetJourneysByCardTemplateId = "/engagementstreams/cardtemplate/{cardTemplateId}/journeytemplates";
        public static string DeleteCardTemplateByJourneyAndCardTemplateIds = "/engagementstreams/journeytemplate/{journeyTemplateId}/cardtemplate/{cardTemplateId}";
        public static string GetPutJourneyRuleByJourneyRuleId = "/engagementstreams/journeyrule/{journeyRuleId}";
        public static string GetPostJourneyConfigurations = "/engagementstreams/journeyconfiguration";
        public static string GetPutJourneyConfigurationByConfigurationId = "/engagementstreams/journeyconfiguration/{journeyConfigurationId}";
        public static string GetGroupsByGroupName = "/groups/searchbyname/{groupName}";
        public static string GetActiveGroupsByGroupName = "/groups/searchbynamevalidsc/{groupName}";
        public static string GetPostJourneyContexts = "/engagementstreams/journeycontext";
        public static string GetPutJourneyContextByContextId = "/engagementstreams/journeycontext/{journeyContextId}";
        public static string GetActiveJourneysByConfigurationId = "/engagementstreams/journeyconfiguration/{journeyConfigurationId}/journey/activeOnly=true";
        public static string GetInactiveJourneysByConfigurationId = "/engagementstreams/journeyconfiguration/{journeyConfigurationId}/journey/inactive";
        public static string PostCopyOfJourneyConfigurationDefinition = "/engagementstreams/journeyConfigurationDefinitionCopy";
        public static string GetAllActionCategories = "/actions/category";
        public static string GetJourneyConfigurationsByContextId = "/journeyconfiguration/journeycontext/{journeyContextId}";
        public static string GetPostOptionsJourneyConfigurationHistoryByConfigurationId = "journeyconfiguration/{journeyConfigurationId}/history";
        public static string GetJourneyConfigurationHistoryByConfigurationHistoryId = "journeyconfiguration/history/{journeyConfigurationHistoryId}/export";
        public static string GetCurrentJourneyConfigurationByConfigurationId = "journeyconfiguration/{journeyConfigurationId}/export";
        public static string PostRollbackJourneyConfigurationByConfigurationHistoryId = "journeyconfiguration/{journeyConfigurationId}/rollback/{journeyConfigurationHistoryId}";
        public static string PostDeepCopyOfJourneyConfiguration = "/engagementstreams/journeyconfiguration/{originalJourneyConfigurationId}/context/{targetContextId}/deepcopy";

        public static string GetPostMarketingCampaign = "/engagementstreams/marketingcampaign";
        #endregion
    }
}
