using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Telegram.Bot.Types;

using TelegramBotTemplate.Core;

namespace TelegramBotTemplate.Controllers
{
    [Route("update")]
    public class UpdateController : Controller
    {
        private readonly Bot _bot;

        public UpdateController(Bot bot)
        {
            _bot = bot;
        }

        [HttpGet]
        public string Get()
        {
            return "Works!";
        }

        [HttpPost]
        public async Task<OkResult> Update([FromBody] Update update)
        {
            try
            {
                foreach (var command in _bot.Commands)
                {
                    if (command.Contains(update))
                    {
                        await command.ExecuteAsync(update);

                        break;
                    }
                }
            }
            catch
            {
                // ignored
            }

            return Ok();
        }
    }
}