using ApiTestingFrameworkXunit.Resources;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ApiTestingFrameworkXunit.Models
{
    public class JourneyConfiguration
    {
        [JsonProperty("JourneyConfigurationId")]
        public string JourneyConfigurationId { get; set; }

        [JsonProperty("JourneyConfigurationGuid")]
        public string JourneyConfigurationGuid { get; set; }

        [JsonProperty("JourneyContextId")]
        public string JourneyContextId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("JourneyConfigurationGroupMap")]
        public List<JourneyConfigurationGroupMap> JourneyConfigurationGroupMap { get; set; }

        public static JsonSerializer Serializer { get; set; }


        public JourneyConfiguration()
        {
            Serializer = new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };
        }

        public JourneyConfiguration(bool generated)
        {
            Serializer = new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };
            Name = $"AutobotTestConfig_{Faker.Name.Last()}";
            Description = $"Config Description {Faker.Company.BS()}";
        }

        public JourneyConfiguration(string journeyConfigurationId, string journeyConfigurationGuid, string journeyContextId, string name, string description, List<JourneyConfigurationGroupMap> journeyConfigurationGroupMap)
        {
            Serializer = new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };
            JourneyConfigurationId = journeyConfigurationId ?? throw new ArgumentNullException(nameof(journeyConfigurationId));
            JourneyConfigurationGuid = journeyConfigurationGuid ?? throw new ArgumentNullException(nameof(journeyConfigurationGuid));
            JourneyContextId = journeyContextId ?? throw new ArgumentNullException(nameof(journeyContextId));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            JourneyConfigurationGroupMap = journeyConfigurationGroupMap ?? throw new ArgumentNullException(nameof(journeyConfigurationGroupMap));
        }

        public JourneyConfiguration CopyConfiguration(JourneyConfiguration j)
        {
            JourneyConfiguration temp = new JourneyConfiguration();
            temp.Name = j.Name;
            temp.Description = j.Description;
            temp.JourneyConfigurationId = j.JourneyConfigurationId;
            temp.JourneyConfigurationGuid = j.JourneyConfigurationGuid;
            temp.JourneyContextId = j.JourneyContextId;
            temp.JourneyConfigurationGroupMap = j.JourneyConfigurationGroupMap;
            return temp;
        }

        public static string CreateJObjectAsString(JourneyConfiguration j)
        {
            JObject i = (JObject)JToken.FromObject(j, Serializer);
            return i.ToString();
        }

        public JourneyConfiguration GetJourneyConfigurationFromSingleResponse(HttpResponseMessage r)
        {
            JObject i = JObject.Parse(r.Content.ReadAsStringAsync().Result);
            JToken j = i["JourneyConfiguration"];
            JourneyConfiguration returnedObject = (JourneyConfiguration)j.ToObject(typeof(JourneyConfiguration), Serializer);
            //(JourneyConfiguration)i.ToObject(typeof(JourneyConfiguration));
            return returnedObject;
        }

        public JourneyConfiguration FindInJarray(HttpResponseMessage response, string name)
        {
            
            JourneyConfiguration c = new JourneyConfiguration();
            JourneyConfiguration returnedConfiguration = new JourneyConfiguration();
            string results = response.Content.ReadAsStringAsync().Result;

            JArray configurations = JArray.Parse(results);
            JToken newObj = configurations.SelectToken("$.[?(@.Name=='" + name + "')]");
            returnedConfiguration = (JourneyConfiguration)newObj.ToObject(typeof(JourneyConfiguration));
            return returnedConfiguration;
        }

        public static JourneyConfiguration POSTNewJourneyConfiguration(HttpClient client)
        {
            JourneyConfiguration temp = new JourneyConfiguration(true);
            //Call method CreateJObjectAsString to pass to create request content
            HttpContent content = new StringContent(CreateJObjectAsString(temp), Encoding.UTF8, "application/json");

            //Act
            var response = client.PostAsync(client.BaseAddress + Constants.GetPostJourneyContexts, content);
            JObject i = JObject.Parse(response.Result.Content.ReadAsStringAsync().Result);
            JToken j = i["JourneyConfiguration"];
            temp = (JourneyConfiguration)j.ToObject(typeof(JourneyConfiguration), Serializer);
            return temp;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(JourneyConfigurationId, JourneyConfigurationGuid, JourneyContextId, Name, Description, JourneyConfigurationGroupMap);
        }

        public override string ToString()
        {
            return $"Name: {Name}, Description: {Description}, JourneyConfigurationId: {JourneyConfigurationId}, JourneyConfigurationGuid: {JourneyConfigurationGuid}, ContextId: {JourneyContextId}";
        }

        public override bool Equals(object obj)
        {
            return obj is JourneyConfiguration configuration &&
                   JourneyConfigurationId == configuration.JourneyConfigurationId &&
                   JourneyConfigurationGuid == configuration.JourneyConfigurationGuid &&
                   JourneyContextId == configuration.JourneyContextId &&
                   Name == configuration.Name &&
                   Description == configuration.Description &&
                   EqualityComparer<List<JourneyConfigurationGroupMap>>.Default.Equals(JourneyConfigurationGroupMap, configuration.JourneyConfigurationGroupMap);
        }
    }
}
