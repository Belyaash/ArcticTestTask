using Hangfire;
using MediatR;
using Newtonsoft.Json;

namespace WebApi.MediatRHangfireBridge
{
    internal static class HangfireConfigurationExtensions
    {
        /// <summary>
        /// Creates bridge between MediatR and Hangfire that allows use Hangfire crons with IRequest"
        /// </summary>
        /// <param name="configuration"></param>
        internal static void UseMediatR(this IGlobalConfiguration configuration)
        {
            var jsonSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            configuration.UseSerializerSettings(jsonSettings);
        }
    }
}