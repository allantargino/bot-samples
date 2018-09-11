using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace bot_sample.Dialogs
{
    [Serializable]
    public class OtherDialog : IDialog<string>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync($"You entered on Other dialog. Welcome!");

            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            var message = activity.Text;

            await context.PostAsync($"You sent {message}, now I'm finishing this dialog.");

            context.Done(message);
        }

    }
}