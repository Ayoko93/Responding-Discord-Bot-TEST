using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.TestBot.Core.Commands
{
    public class PingCommand:ModuleBase<SocketCommandContext>
    {
        [Command("ping"), Summary("See if the bot is available.")]
        public async Task Execute()
        {
            await ReplyAsync("Pong!");
        }

    }
}
