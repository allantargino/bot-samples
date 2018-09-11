using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using QnAMakerDialog;
using QnAMakerDialog.Models;

namespace bot_sample.Dialogs
{
    [Serializable]
    public class QnADialog : QnAMakerDialog<object>
    {
        public QnADialog(string baseUri, string knowledgeBaseId, string endpointKey)
        {
            this.BaseUri = baseUri;
            this.KnowledgeBaseId = knowledgeBaseId;
            this.EndpointKey = endpointKey;
        }

        public override Task StartAsync(IDialogContext context)
        {
            return base.StartAsync(context);
        }

        public override Task DefaultMatchHandler(IDialogContext context, string originalQueryText, QnAMakerResult result)
        {
            return base.DefaultMatchHandler(context, originalQueryText, result);
        }

        public override Task NoMatchHandler(IDialogContext context, string originalQueryText)
        {
            return base.NoMatchHandler(context, originalQueryText);
        }
    }
}