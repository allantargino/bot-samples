﻿using Microsoft.Bot.Builder.Dialogs.Internals;
using Microsoft.Bot.Builder.Internals.Fibers;
using Microsoft.Bot.Builder.Scorables.Internals;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace bot_sample.Scorables
{
    public abstract class CommandScorable : ScorableBase<IActivity, bool, double>
    {
        protected readonly IBotToUser BotToUser;
        protected readonly IDialogTask task;

        public CommandScorable(IBotToUser botToUser, IDialogTask task)
        {
            SetField.NotNull(out this.BotToUser, nameof(botToUser), botToUser);
            SetField.NotNull(out this.task, nameof(task), task);
        }

        public abstract bool SetState(IMessageActivity item);

        protected override Task DoneAsync(IActivity item, bool state, CancellationToken token)
        {
            return Task.CompletedTask;
        }

        protected override double GetScore(IActivity item, bool state)
        {
            return state ? 1 : 0;
        }

        protected override bool HasScore(IActivity item, bool state)
        {
            return state;
        }

        protected override Task<bool> PrepareAsync(IActivity item, CancellationToken token)
        {
            var message = item.AsMessageActivity();

            if (message == null)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(this.SetState(message));
        }
    }
}