using System;
using System.Reflection;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace TemplateBot.Utilities
{
    class CommandHandler
    {
        DiscordSocketClient dscClient;
        CommandService chService;

        public async Task InitialiseAsync(DiscordSocketClient client)
        {
            dscClient = client;
            chService = new CommandService();

            await chService.AddModulesAsync(Assembly.GetEntryAssembly(), null);
            dscClient.MessageReceived += HandleCommandAsync;
        }

        private async Task HandleCommandAsync(SocketMessage sm)
        {
            var msg = sm as SocketUserMessage;

            if (msg == null) return;

            var context = new SocketCommandContext(dscClient, msg);

            int argPos = 0;

            //namespace.class.object.variable
            if (msg.HasStringPrefix(Config.Config.bot.cmdPrefix, ref argPos) || msg.HasMentionPrefix(dscClient.CurrentUser, ref argPos))
            {
                var result = await chService.ExecuteAsync(context, argPos, null);

                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                    Console.WriteLine(result.ErrorReason);
            }
        }
    }
}
