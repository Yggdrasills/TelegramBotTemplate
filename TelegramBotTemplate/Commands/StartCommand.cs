using System.Threading.Tasks;

using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBotTemplate.Commands
{
    public class StartCommand : ICommand
    {
        private const string Command = "/start";

        private readonly TelegramBotClient _botClient;

        public StartCommand(TelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        public bool Contains(Update update)
        {
            return update.Type == UpdateType.Message &&
                   update.Message?.Text == Command;
        }

        public async Task ExecuteAsync(Update update)
        {
            await _botClient.SendTextMessageAsync(update.Message.Chat.Id, "Hello there.", ParseMode.Html);
        }
    }
}