using ApiTestingFrameworkXunit.Common.Utilities;
using ApiTestingFrameworkXunit.Models;
using ApiTestingFrameworkXunit.Resources;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using Xunit.Priority;

namespace ApiTestingFrameworkXunit.Test
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class PracticeTests
    {
        private readonly ITestOutputHelper output;
        private Common.Interfaces.IHttpClientBuilder _clientBuilder;
        const string BaseUrl = "https://qa2012-services2.onlifehealth.com/engagementhub/api";
        public static JourneyContext journeyContext = new JourneyContext();
        //public static JourneyContextRoot journeyContextRoot = new JourneyContextRoot();
        public static MarketingCampaign marketingCampaign = new MarketingCampaign();
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public static HttpClient httpClient;
        public static JsonSerializer serializer = new JsonSerializer();
        public JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
        
        public PracticeTests(ITestOutputHelper output)
        {
            this.output = output;
            //Arrange
            var services = Common.HostBuilder.ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();
            _clientBuilder = serviceProvider.GetService<Common.Interfaces.IHttpClientBuilder>();
            httpClient = _clientBuilder.CreateBasicClient("JourneyClient", BaseUrl);
            
            serializer.Formatting = Formatting.Indented;
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializerSettings.Formatting = Formatting.Indented;
            serializerSettings.NullValueHandling = NullValueHandling.Ignore;
        }

        [Fact, Priority(1)]
        public async void PostNewJourneyContext()
        {
            //Arrange
            //Create a simple JourneyContext object with a generated Name and Description
            output.WriteLine($"Beginning state of context: {journeyContext}");
            output.WriteLine($"Serialized state: {JsonConvert.SerializeObject(journeyContext)}");
            HttpContent content = new StringContent(JsonConvert.SerializeObject(journeyContext), Encoding.UTF8, "application/json");
            //Act
            var response = await httpClient.PostAsync(BaseUrl + Constants.GetPostJourneyContexts, content);
            //Set the returned value as the new JourneyContextId
            journeyContext.JourneyContextId = response.Content.ReadAsStringAsync().Result;
            output.WriteLine($"After setting contextId : {JsonConvert.SerializeObject(journeyContext)}");
            //Assert 
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            //Log Response
            Logger.Debug("Created new Context:: " + JsonConvert.SerializeObject(journeyContext, serializerSettings));
        }
        [Fact, Priority(2)]
        public async void GetJourneyContextById()
        {
            //Arrange
            //Act
            var response = await httpClient.SendAsync(ApiUtilities.BuildRequestMessage(HttpMethod.Get, ApiUtilities.BuildUriWithPathParameters(BaseUrl + Constants.GetPutJourneyContextByContextId, journeyContext.JourneyContextId.ToString())));
            JourneyContext tempContext = JsonConvert.DeserializeObject<JourneyContext>(response.Content.ReadAsStringAsync().Result);
            journeyContext.JourneyContextGuid = tempContext.JourneyContextGuid;
            output.WriteLine($"After setting Guid : {JsonConvert.SerializeObject(journeyContext, serializerSettings)}");

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(journeyContext, tempContext);
            //Log Response
            Logger.Debug($"Returned Journey Context By ID: {tempContext}");
        }

        [Fact, Priority(3)]
        public async void GetAllJourneyContexts()
        {
            //Arrange
            //Act
            var response = await httpClient.GetAsync(BaseUrl + Constants.GetPostJourneyContexts);
            //JourneyContextRoot tempContextRoot = JsonConvert.DeserializeObject<JourneyContextRoot>(response.Content.ReadAsStringAsync().Result);
            //Store the item containing the same name as journeyContext
            //JourneyContext tempContext = tempContextRoot.JourneyContextItems.Find(item => item.Name == journeyContext.Name);
            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
           // Assert.Equal(journeyContext, tempContext);
            //Log Test Data
            output.WriteLine($"Write without serialization: {journeyContext}");
            output.WriteLine($"Write with serialization: {JsonConvert.SerializeObject(journeyContext, serializerSettings)}");
        }

        [Fact, Priority(1)]
        public async void PostNewMarketingCampaign()
        {
            //Arrange
            //Create a simple MarketingCampaign object with a generated Name and Description
            output.WriteLine($"Beginning state of context: {marketingCampaign}");
            output.WriteLine($"Serialized state: {JsonConvert.SerializeObject(marketingCampaign)}");
            HttpContent content = new StringContent(JsonConvert.SerializeObject(marketingCampaign), Encoding.UTF8, "application/json");
            //Act
            var response = await httpClient.PostAsync(BaseUrl + Constants.GetPostMarketingCampaign, content);
            //Set the returned value as the new MarketingCampaignId
            journeyContext.JourneyContextId = response.Content.ReadAsStringAsync().Result;
            output.WriteLine($"After setting contextId : {JsonConvert.SerializeObject(journeyContext)}");
            //Assert 
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            //Log Response
            Logger.Debug("Created new Context:: " + JsonConvert.SerializeObject(journeyContext, serializerSettings));
        }
        [Fact, Priority(6)]
        public async void GetAllMarketingCampaigns()
        {
            //Arrange
            //Act
            var response = await httpClient.GetAsync(BaseUrl + Constants.GetPostJourneyContexts);
            List<MarketingCampaign> tempCampaignList = JsonConvert.DeserializeObject<List<MarketingCampaign>>(response.Content.ReadAsStringAsync().Result);
            //Store the item containing the same name as journeyContext
            MarketingCampaign tempCampaign= tempCampaignList.Find(item => item.Name == marketingCampaign.Name);
            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(marketingCampaign, tempCampaign);
            //Log Test Data
            output.WriteLine($"Write without serialization: {journeyContext}");
            output.WriteLine($"Write with serialization: {JsonConvert.SerializeObject(journeyContext, serializerSettings)}");
        }
    }
}
