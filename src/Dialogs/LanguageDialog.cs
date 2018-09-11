using bot_sample.Helpers;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace bot_sample.Dialogs
{
    [Serializable]
    [LuisModel("", "", LuisApiVersion.V2, "westus.api.cognitive.microsoft.com")]
    public class LanguageDialog : LuisDialog<object>
    {
        public LanguageDialog()
        {

        }

        private bool ValidateScore(LuisResult result)
        {
            double? value = result.TopScoringIntent.Score;
            double minimumScore = ConfigurationHelper.LuisMinimumScore;

            if (value * 100 < minimumScore)
                return false;
            else
                return true;
        }

        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Desculpe, não entendi o que você quis dizer com \"{result.Query}\".");

            context.Wait(MessageReceived);
        }

        [LuisIntent("Intent_Name")]
        public async Task IntentName(IDialogContext context, IAwaitable<IMessageActivity> message, LuisResult result)
        {
            if (ValidateScore(result))
            {
                context.Wait(MessageReceived);
            }
            else
            {
                await None(context, result);
            }
        }
    }
}