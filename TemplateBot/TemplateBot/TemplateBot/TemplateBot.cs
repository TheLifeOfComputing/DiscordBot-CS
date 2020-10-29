using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using TemplateBot.Utilities;

namespace TemplateBot
{
    class TemplateBot
    {
        DiscordSocketClient dscClient;
        CommandHandler commandHandler;
        //MainASync is launched after this line is ran.
        public static void Main(string[] args)
            => new TemplateBot().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            //we want to exit program if Token is null
            if (Config.Config.bot.token == "" || Config.Config.bot.token == null) return;

            dscClient = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose
            });

            dscClient.Log += Log;

            await dscClient.LoginAsync(TokenType.Bot, Config.Config.bot.token);
            await dscClient.StartAsync();

            commandHandler = new CommandHandler();

            await commandHandler.InitialiseAsync(dscClient);
            await Task.Delay(-1);
        }

        private async Task Log(LogMessage msg)
        {
            //Converts msg to a string
            Console.WriteLine(msg.ToString());
        }
    }
}