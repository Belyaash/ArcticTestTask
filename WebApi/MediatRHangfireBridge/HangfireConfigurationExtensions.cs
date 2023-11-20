using Hangfire;
using MediatR;
using Newtonsoft.Json;

namespace WebApi.MediatRHangfireBridge
{
    public static class HangfireConfigurationExtensions
    {
        public static void UseMediatR(this IGlobalConfiguration configuration)
        {
            var jsonSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            configuration.UseSerializerSettings(jsonSettings);
        }
    }
}