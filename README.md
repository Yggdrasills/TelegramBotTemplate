Template for Telegram Bot
===
A simple template for creating a telegram bot via Сommand pattern.

Repository uses [Telegram.Bot](https://www.nuget.org/packages/Telegram.Bot) 
and 
[Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/13.0.2-beta2) libraries


Getting started
---

1. Fill Settings section in appsettings.json:
    - Enter telegram bot token: `"Token": "put_token_here"`
    - Enter application url: `"ApplicationUrl": "https://example.com/{0}"`. Don't forget "`\{0}`" at the end to define the path to the controller

2. Add more UpdateTypes and Commands to `Bot.cs` to expand functionality.

3. Program for opening external access to the port to test this template - [Ngrok](https://ngrok.com/download)
   1. Open tunel with `ngrok http 80` or another port defined in `launchSettings.json`
   2. Set `ApplicationUrl` in `appsettings.json`
   3. Run program

