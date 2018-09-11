using Microsoft.Bot.Builder.Dialogs.Internals;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace bot_sample.Scorables
{
    public class Reset : CommandScorable
    {
        public Reset(IBotToUser botToUser, IDialogTask task) : base(botToUser, task)
        {
        }

        public override bool SetState(IMessageActivity message)
        {
            var text = message.Text.ToLowerInvariant();
            if (text == "voltar" || text == "cancelar" || text == "tchau" || text == "sair")
                return true;
            return false;
        }

        protected override async Task PostAsync(IActivity item, bool state, CancellationToken token)
        {
            if (item is Activity activity)
            {
                var message = BotToUser.MakeMessage();
                message.Text = "Restarting the experience!";
                await BotToUser.PostAsync(message, token);
                task.Reset();
            }
        }
    }
}