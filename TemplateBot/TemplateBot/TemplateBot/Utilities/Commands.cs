using System.Threading.Tasks;
using Discord.Commands;
using System;

namespace TemplateBot.Utilities
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        //\tb talk
        [Command("talk")]
        public async Task Talk()
        {
            await Context.Channel.SendMessageAsync("Hello, how may I help you? Use #r to reply back");
            Console.WriteLine("Wait for message...\n\n");
        }
    }
}
