using ApiTestingFrameworkXunit.Common.Utilities;
using ApiTestingFrameworkXunit.Models;
using ApiTestingFrameworkXunit.Resources;
using Common.Logging;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Xunit.Priority;

namespace ApiTestingFrameworkXunit.Test
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]

    public class JourneyTests
    {
        private readonly ITestOutputHelper output;
        private Common.Interfaces.IHttpClientBuilder _clientBuilder;
        const string BaseUrl = "https://qa2012-services2.onlifehealth.com/engagementhub/api";
        public static JourneyContext journeyContext = new JourneyContext(true);
        public static int JourneyContextCount;
        public static JourneyConfiguration journeyConfiguration = new JourneyConfiguration(true);
        public static JourneyCategory journeyCategory;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public static HttpClient httpClient;
        public static JsonSerializer serializer;
        public JourneyTests(ITestOutputHelper output)
        {
            this.output = output;
            //Arrange
            var services = Common.HostBuilder.ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();
            _clientBuilder = serviceProvider.GetService<Common.Interfaces.IHttpClientBuilder>();
            httpClient = _clientBuilder.CreateBasicClient("JourneyClient", BaseUrl);
            serializer = new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };
        }

        [Fact, Priority(1)]
        public async void PostNewJourneyContext()
        {
            //Arrange
            //Call method CreateJObjectAsString to pass to create request content
            HttpContent content = new StringContent(journeyContext.CreateJObjectAsString(journeyContext), Encoding.UTF8, "application/json");

            //Act
            var response = await httpClient.PostAsync(BaseUrl + Constants.GetPostJourneyContexts, content);
            journeyContext.JourneyContextId = response.Content.ReadAsStringAsync().Result;

            //Assert 
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //Log Response
            output.WriteLine(journeyContext.ToString());

        }

        [Fact, Priority(2)]
        public async void GetAllJourneyContexts()
        {
            //Arrange
            //If tests are not run in sequence, journeyContext will be null. Send a Post request to add a new, valid JourneyContext
            if (journeyContext.JourneyContextId == null)
            {
                journeyContext = JourneyContext.POSTNewJourneyContext(httpClient);
            }
            //Act
            var response = await httpClient.GetAsync(BaseUrl + Constants.GetPostJourneyContexts);
            JObject responseObject = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            journeyContext = journeyContext.FindInJarray(responseObject, journeyContext.Name);

            output.WriteLine(journeyContext.ToString());
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact, Priority(3)]
        public async void GetJourneyContextById()
        {
            //Arrange
            //If tests are not run in sequence, journeyContext will be null. Send a Post request to add a new, valid JourneyContext
            if (journeyContext.JourneyContextId == null)
            {
                journeyContext = JourneyContext.POSTNewJourneyContext(httpClient);
            }
            //Act
            var response = await httpClient.SendAsync(ApiUtilities.BuildRequestMessage(HttpMethod.Get, ApiUtilities.BuildUriWithPathParameters(BaseUrl + Constants.GetPutJourneyContextByContextId, journeyContext.JourneyContextId.ToString())));
            JourneyContext returnedObject = journeyContext.GetJourneyContextFromSingleResponse(response);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(journeyContext.JourneyContextId, returnedObject.JourneyContextId);

            //Log Response
            output.WriteLine($"Returned Journey Context By ID: {returnedObject}");
        }

        [Fact, Priority(4)]
        public async void GetAllJourneyContextsInvalidUrl()
        {
            //Act
            var response = await httpClient.GetAsync(BaseUrl + "/invalidPath");
            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            //Log Response
            Logger.Debug(response.Content.ReadAsStringAsync().Result);
        }

        [Fact, Priority(5)]
        public async Task PostNewJourneyConfiguration()
        {
            //Arrange
            //If tests are not run in sequence, journeyContext will be null. Send a Post request to add a new, valid JourneyContext
            if (journeyContext.JourneyContextId == null)
            {
                journeyContext = JourneyContext.POSTNewJourneyContext(httpClient);
            }
            journeyConfiguration.JourneyContextId = journeyContext.JourneyContextId;
            HttpContent content = new StringContent(JourneyConfiguration.CreateJObjectAsString(journeyConfiguration), Encoding.UTF8, "application/json");

            //Act
            var response = await httpClient.PostAsync(BaseUrl + Constants.GetPostJourneyConfigurations, content);
            journeyConfiguration = journeyConfiguration.GetJourneyConfigurationFromSingleResponse(response);

            //Assert 
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //Log Response
            output.WriteLine(journeyConfiguration.ToString());
        }

        [Fact(Skip ="Broken"), Priority(6)]
        public async void GetAllJourneyConfigurations()
        {
            //Act
            //If tests are not run in sequence, journeyConfiguration will be null. Send a Post request to add a new, valid JourneyConfiguration
            if (journeyConfiguration.JourneyContextId == null)
            {
                journeyConfiguration = JourneyConfiguration.POSTNewJourneyConfiguration(httpClient);
            }
            var response = await httpClient.GetAsync(BaseUrl + Constants.GetPostJourneyConfigurations);
            //string results = response.Content.ReadAsStringAsync().Result;

            //JArray configurations = JArray.Parse(results);
            //JToken newObj = configurations.SelectToken("$.[?(@.Name=='" + journeyConfiguration.Name + "')]");
            //journeyConfiguration = (JourneyConfiguration)newObj.ToObject(typeof(JourneyConfiguration));
            journeyConfiguration = journeyConfiguration.FindInJarray(response, journeyConfiguration.Name);
            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            //Log Response
            Logger.Debug($"Selected JourneyConfiguration: {journeyConfiguration}");
        }

        [Fact, Priority(7)]

        public async void GetJourneyConfigurationById()
        {
            //Act
            var response = await httpClient.SendAsync(ApiUtilities.BuildRequestMessage(HttpMethod.Get, ApiUtilities.BuildUriWithPathParameters(BaseUrl + Constants.GetPutJourneyConfigurationByConfigurationId, journeyConfiguration.JourneyConfigurationId.ToString())));
            JourneyConfiguration deserializedResponse = JsonConvert.DeserializeObject<JourneyConfiguration>(response.Content.ReadAsStringAsync().Result);
            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(journeyConfiguration.ToString(), deserializedResponse.ToString(), true, true, true);
            //Log Response
            Logger.Debug($"Returned Journey Configuration By ID: {deserializedResponse}");
        }

        [Fact]
        public async void GetAllJourneyCategories()
        {
            //Act
            var response = await httpClient.GetAsync(BaseUrl + Constants.GetAllJourneyCategories);
            List<JourneyCategory> deserializedResponse = JsonConvert.DeserializeObject<List<JourneyCategory>>(response.Content.ReadAsStringAsync().Result);
            int index = Faker.RandomNumber.Next(deserializedResponse.Count);
            journeyCategory = deserializedResponse[index];
            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            //Log Response
            Logger.Debug($"Selected Journey Category: {journeyCategory}");
        }


        //[Fact(Skip = "Broken")]
        //public async void GetAllJourneyTemplates()
        //{
        //    //Act
        //    var response = await httpClient.GetAsync(BaseUrl + Constants.GetAllJourneyTemplates);
        //    List<JourneyTemplate> deserializedResponse = JsonConvert.DeserializeObject<List<JourneyTemplate>>(response.Content.ReadAsStringAsync().Result);
        //    int index = Faker.RandomNumber.Next(deserializedResponse.Count);
        //    journeyTemplate = deserializedResponse[index];
        //    //Assert
        //    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        //    //Log Response
        //    Logger.Debug($"Selected Journey Template: {journeyTemplate}");

        //}

        //[Fact(Skip = "Dependency Broken")]

        //public async void GetJourneyTemplateById()
        //{
        //    //Act
        //    var response = await httpClient.SendAsync(ApiUtilities.BuildRequestMessage(HttpMethod.Get, ApiUtilities.BuildUriWithPathParameters(BaseUrl + Constants.GetPutDeleteJourneyTemplateByTemplateId, journeyTemplate.JourneyTemplateId.ToString())));
        //    JourneyTemplate deserializedResponse = JsonConvert.DeserializeObject<JourneyTemplate>(response.Content.ReadAsStringAsync().Result);
        //    //Assert
        //    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        //    Assert.Equal(journeyTemplate, deserializedResponse);
        //    //Log Response
        //    Logger.Debug($"Selected Journey Template: {journeyTemplate}");
        //}
    }
}






