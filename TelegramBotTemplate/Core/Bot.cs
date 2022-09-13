using System.Collections.Generic;
using System.Threading.Tasks;

using Telegram.Bot;
using Telegram.Bot.Types.Enums;

using TelegramBotTemplate.Commands;

namespace TelegramBotTemplate.Core
{
    public class Bot
    {
        private readonly string _token;
        private readonly string _applicationUrl;
        private readonly List<ICommand> _commands;

        private TelegramBotClient? _botClient;

        public IReadOnlyList<ICommand> Commands => _commands.AsReadOnly();

        public Bot(string token, string appUrl)
        {
            _token = token;
            _applicationUrl = appUrl;

            _commands = new List<ICommand>();
        }

        public async Task<ITelegramBotClient> GetBotClientAsync()
        {
            if (_botClient != null)
            {
                return _botClient;
            }

            _botClient = new TelegramBotClient(_token);

            SetUpCommandList(_botClient);

            string hook = string.Format(_applicationUrl, "update");

            var allowedUpdated = new List<UpdateType>()
            {
                UpdateType.Message,
                /*
                 * note: add more update types here
                 * 
                 * UpdateType.CallbackQuery,
                 * UpdateType.ChannelPost
                */
            };

            await _botClient.DeleteWebhookAsync();
            await _botClient.GetUpdatesAsync(offset: -1);
            await _botClient.SetWebhookAsync(hook, allowedUpdates: allowedUpdated);


            return _botClient;
        }

        private void SetUpCommandList(TelegramBotClient botClient)
        {
            _commands.Add(new StartCommand(botClient));
            // note: add more commands here
        }
    }
}