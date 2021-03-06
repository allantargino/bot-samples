﻿using System;
using System.Threading.Tasks;
using bot_sample.Helpers;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace bot_sample.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            switch (activity.Text.ToLower())
            {
                case "other":
                    context.Call(new OtherDialog(), ResumeAfterOtherDialog);
                    break;
                case "luis":
                    context.Call(new LanguageDialog(), (ctx, rst) => {
                        context.Wait(MessageReceivedAsync);
                        return Task.CompletedTask;
                    });
                    break;
                case "qna":
                    var baseUri = ConfigurationHelper.LuisBaseUri;
                    var knowledgeBaseId = ConfigurationHelper.LuisKnowledgeBaseId;
                    var endpointKey = ConfigurationHelper.LuisEndpointKey;

                    context.Call(new QnADialog(baseUri, knowledgeBaseId, endpointKey), (ctx, rst) => {
                        context.Wait(MessageReceivedAsync);
                        return Task.CompletedTask;
                    });
                    break;
                default:
                    await context.PostAsync($"You sent {activity.Text} which was {activity.Text.Length} characters");
                    context.Wait(MessageReceivedAsync);
                    break;
            }
        }

        private async Task ResumeAfterOtherDialog(IDialogContext context, IAwaitable<string> result)
        {
            var resultFromDialog = await result;

            await context.PostAsync($"I received from the other dialog: {resultFromDialog}");

            await context.PostAsync($"Waiting for messages again.");

            context.Wait(MessageReceivedAsync);
        }
    }
}