using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.TestBot.Core.Commands
{
    public class HelloWorldCommand : ModuleBase<SocketCommandContext>
    {
        [Command("hello"), Alias("hello-world", "helloworld"), Summary("Hello World Command")]
        public async Task Execute()
        {
            await ReplyAsync("Hi!");
        }
    }
}
