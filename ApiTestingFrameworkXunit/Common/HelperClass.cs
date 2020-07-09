using ApiTestingFrameworkXunit.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestingFrameworkXunit.Common
{
    public class HelperClass
    {
        private static HttpClient client;
        private static HttpRequestMessage requestMessage;
        private static ResponseObject restResponse;

        private static HttpClient CreateClientWithHeaders(Dictionary<string,string> httpHeaders)
        {
            HttpClient client = new HttpClient();
            if (null != httpHeaders)
            {
                foreach (string key in httpHeaders.Keys)
                {
                    client.DefaultRequestHeaders.Add(key, httpHeaders[key]);
                }
            }
                return client;
        }

        private static HttpRequestMessage CreateRequestMessage(string requestUrl, HttpMethod method, HttpContent content)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(method, requestUrl);
            if (!(method == HttpMethod.Get))
            {
                requestMessage.Content = content;
            }
            return requestMessage;
        }

        private static ResponseObject SendRequest(string requestUrl, HttpMethod method,
            HttpContent content, Dictionary<string,string> headers)
        {
            client = CreateClientWithHeaders(headers);
            requestMessage = CreateRequestMessage(requestUrl, method, content);
            try
            {
                Task<HttpResponseMessage> responseMessage = client.SendAsync(requestMessage);
                restResponse = new ResponseObject((int)responseMessage.Result.StatusCode,
                    responseMessage.Result.Content.ReadAsStringAsync().Result);
            }
            catch(Exception e)
            {

                restResponse = new ResponseObject(500, e.Message);
            }
            finally
            {
                requestMessage?.Dispose();
                client?.Dispose();
            }
            return restResponse;
        }

        public static ResponseObject PerformGetRequest(string requestUrl, Dictionary<string,string> headers)
        {
            return SendRequest(requestUrl, HttpMethod.Get, null, headers);
        }

        public static ResponseObject PerformPostRequest(string requestUrl, HttpContent content, Dictionary<string, string> headers)
        {
            return SendRequest(requestUrl, HttpMethod.Post, content, headers);
        }

        public static ResponseObject PerformPostRequest(string requestUrl, string content, string mediaType, Dictionary<string, string> headers)
        {
            HttpContent httpContent = new StringContent(content, Encoding.UTF8, mediaType);
            return PerformPostRequest(requestUrl,httpContent, headers);
        }
    }
}
