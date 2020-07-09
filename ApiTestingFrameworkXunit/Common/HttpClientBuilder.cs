using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using ApiTestingFrameworkXunit.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using IHttpClientBuilder = ApiTestingFrameworkXunit.Common.Interfaces.IHttpClientBuilder;

namespace ApiTestingFrameworkXunit.Common
{
    public class HttpClientBuilder : Interfaces.IHttpClientBuilder
    {
        public ServiceProvider ServiceProvider { get; private set; }
        private readonly IHttpClientFactory _clientFactory;
        public HttpClientBuilder(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public HttpClient CreateBasicClient(string clientTypeName, string basepath)
        {
            var client = _clientFactory.CreateClient(clientTypeName);
            client.BaseAddress = new Uri(basepath);
            return client;
        }

        public HttpClient CreateBasicClientWithContent(string clientTypeName, string basepath)
        {
            var client = _clientFactory.CreateClient(clientTypeName);
            client.BaseAddress = new Uri(basepath);
            //client.
            client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            return client;
        }

        public HttpClient CreateClientWithBasicAuthentication(string clientTypeName, string basepath, string username, string password)
        {
            var client = _clientFactory.CreateClient(clientTypeName);
            client.BaseAddress = new Uri(basepath);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(
                        System.Text.ASCIIEncoding.ASCII.GetBytes(
                            $"{username}:{password}")));
            return client;
        }

        public HttpClient CreateClientWithOauthAuthentication(string clientTypeName, string basepath)
        {
            var client = _clientFactory.CreateClient(clientTypeName);
            client.BaseAddress = new Uri(basepath);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
    }
}
