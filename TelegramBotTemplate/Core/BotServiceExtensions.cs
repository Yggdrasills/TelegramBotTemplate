using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using TelegramBotTemplate.Models;

namespace TelegramBotTemplate.Core
{
    public static class BotServiceExtensions
    {
        public static IMvcBuilder AddTelegramBot(this IMvcBuilder builder, IConfiguration configuration)
        {
            var appSettings = new Settings();

            configuration.GetSection(nameof(Settings)).Bind(appSettings);

            var bot = new Bot(appSettings.Token, appSettings.ApplicationUrl);

            bot.GetBotClientAsync().Wait();

            builder.Services.AddSingleton(bot);

            return builder;
        }
    }
}