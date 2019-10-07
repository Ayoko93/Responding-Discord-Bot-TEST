using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.TestBot.Core.Commands
{
    public class HelpCommand:ModuleBase<SocketCommandContext>
    {
        [Command("help"), Alias("get-help", "?", "get-commands"), Summary("Shows all commands")]
        public async Task Execute()
        {
            string message = "Every command begins with an exclamation mark (!). For Example to see if the bot is available use the command: !ping\n\n";
                
                message += "Command: !ping\n" + 
                "Description: See if the bot is available\n" +
                "Alias: <None>";

            await ReplyAsync(message);
        }
    }
}
