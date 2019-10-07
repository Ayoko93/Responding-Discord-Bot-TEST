using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.TestBot.Core.Commands
{
    public class TestCommand : ModuleBase<SocketCommandContext>
    {
        // ~say hello -> hello
        [Command("say")]
        [Summary("Echoes a message.")]
        public async Task SayAsync([Remainder] [Summary("The text to echo")] string echo)
        {
            // ReplyAsync is a method on ModuleBase
            await ReplyAsync(echo);
        }

        // ~say hello -> hello
        [Command("square")]
        [Summary("Squares a number.")]
        public async Task SquareAsync([Summary("The number to square.")] int num)
        {
            // We can also access the channel from the Command Context.
            await Context.Channel.SendMessageAsync($"{num}^2 = {Math.Pow(num, 2)}");
        }

        [Command("userinfo")]
        [Summary("Returns info about the current user, or the user parameter, if one passed.")]
        [Alias("user", "whois")]
        public async Task UserInfoAsync([Summary("The (optional) user to get info for")] IUser user = null)
        {
            var userInfo = user ?? Context.Client.CurrentUser;
            await ReplyAsync($"{userInfo.Username}#{userInfo.Discriminator}");
        }

    }
}
