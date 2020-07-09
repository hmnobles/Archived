using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ApiTestingFrameworkXunit.Common.Interfaces
{
    public interface IHttpClientBuilder
    {
        HttpClient CreateBasicClient(string clientTypeName, string basepath);
        HttpClient CreateBasicClientWithContent(string clientTypeName, string basepath);
        HttpClient CreateClientWithBasicAuthentication(string clientTypeName, string basepath, string username, string password);
        HttpClient CreateClientWithOauthAuthentication(string clientTypeName, string basepath);

    }
}
