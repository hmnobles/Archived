using ApiTestingFrameworkXunit.Common.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ApiTestingFrameworkXunit.Common
{
    public static class HostBuilder
    {
        public static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection()
            .AddHttpClient()
            .AddSingleton(typeof(Interfaces.IHttpClientBuilder), typeof(HttpClientBuilder))
            .AddLogging()
            .AddSingleton<ILoggerManager, LoggerManager>();

            return services;
        }
    }
}
