using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.TestBot.Core.Commands
{
    public class PurgeCommand:ModuleBase<SocketCommandContext>
    {
        [Command("delete-messages"), Alias("remove-messages"), Summary("Removes the last messages from the current channel. Example: !delete-messages 2")]
        public async Task Execute([Summary("The amount, how many messages you want to delete.")]int amount)
        {
            var currentChannel = Context.Channel;
            var messages = await currentChannel.GetMessagesAsync(amount).Flatten();
            await currentChannel.DeleteMessagesAsync(messages);
        }

    }
}
