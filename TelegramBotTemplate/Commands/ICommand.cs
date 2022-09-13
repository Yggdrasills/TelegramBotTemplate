using System.Threading.Tasks;

using Telegram.Bot.Types;

namespace TelegramBotTemplate.Commands
{
    public interface ICommand
    {
        bool Contains(Update update);

        Task ExecuteAsync(Update update);
    }
}