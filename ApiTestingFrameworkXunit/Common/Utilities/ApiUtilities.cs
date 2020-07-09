using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;

namespace ApiTestingFrameworkXunit.Common.Utilities
{
    public static  class ApiUtilities
    {

        public static HttpRequestMessage BuildRequestMessage(HttpMethod method, string uri)
        {
            var request = new HttpRequestMessage();
            request.Method = method;
            request.RequestUri = new Uri(uri);
            return request;
        }

        public static string BuildUriWithPathParameters(string baseUri, string parameter)
        {
            Regex reg = new Regex("{(.+?)}");
            string path = reg.Replace(baseUri, parameter);
            return path;
        }
    }
}
