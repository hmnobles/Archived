using ApiTestingFrameworkXunit.Resources;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ApiTestingFrameworkXunit.Models
{
    public class JourneyContext
    {

        [JsonProperty("JourneyContextId")]
        public string JourneyContextId { get; set; }

        [JsonProperty("JourneyContextGuid")]
        public string JourneyContextGuid { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        public JsonSerializer Serializer { get; set; }

        //public int TotalRecords { get; set; }


        public JourneyContext(JourneyContext o)
        {
            {
                Serializer = new JsonSerializer
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    Formatting = Formatting.Indented
                };
            }
            Name = o.Name;
            Description = o.Description;
            JourneyContextId = o.JourneyContextId;
            JourneyContextGuid = o.JourneyContextGuid;
        }
        public JourneyContext()
        {
            Serializer = new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };
        }


        public JourneyContext(bool generate)
        {
            Serializer = new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };
            Name = $"AutobotTestContext_{Faker.Name.Last()}";
            Description = $"Test Description {Faker.Company.BS()}";
        }

        public JourneyContext(string journeyContextId, string journeyContextGuid, string name, string description)
        {
            JourneyContextId = journeyContextId;
            JourneyContextGuid = journeyContextGuid;
            Name = name;
            Description = description;
        }

        public JourneyContext CopyContext(JourneyContext j)
        {
            JourneyContext temp = new JourneyContext();
            temp.Name = j.Name;
            temp.Description = j.Description;
            temp.JourneyContextGuid = j.JourneyContextGuid;
            temp.JourneyContextId = j.JourneyContextId;
            return temp;
        }

        public string CreateJObjectAsString(JourneyContext j)
        {
            JObject i = (JObject)JToken.FromObject(j, Serializer);
            return i.ToString();
        }

        public JourneyContext GetJourneyContextFromSingleResponse(HttpResponseMessage r)
        {
            JObject i = JObject.Parse(r.Content.ReadAsStringAsync().Result);
            JourneyContext returnedObject = (JourneyContext)(i.ToObject(typeof(JourneyContext)));
            return returnedObject;
        }

        public JourneyContext FindInJarray(JObject responseObject, string name)
        {
            JourneyContext c = new JourneyContext();
            JourneyContext returnedContext = new JourneyContext();
            JArray contexts = (JArray)responseObject["JourneyContextItems"];

            for (int i = 0; i < contexts.Count; i++)
            {
                c = (JourneyContext)contexts[i].ToObject(typeof(JourneyContext));
                if (c.Name.ToString() == name)
                {
                    returnedContext = c;
                    break;
                }
            }
            return returnedContext;
        }

        public static JourneyContext POSTNewJourneyContext(HttpClient client)
        {
            JourneyContext temp = new JourneyContext(true);
            HttpContent content = new StringContent(temp.CreateJObjectAsString(temp), Encoding.UTF8, "application/json");

            //Act
            var response = client.PostAsync(client.BaseAddress + Constants.GetPostJourneyContexts, content);
            temp.JourneyContextId = response.Result.Content.ReadAsStringAsync().Result;
            return temp;
        }

        public override bool Equals(object obj)
        {
            return obj is JourneyContext context &&
                   JourneyContextId == context.JourneyContextId &&
                   JourneyContextGuid == context.JourneyContextGuid &&
                   Name == context.Name &&
                   Description == context.Description;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(JourneyContextId, JourneyContextGuid, Name, Description);
        }

        public override string ToString()
        {
            return $"Name: {Name}, Description: {Description}, ContextId: {JourneyContextId}, ContextGuid: {JourneyContextGuid}";
        }
    }
}
