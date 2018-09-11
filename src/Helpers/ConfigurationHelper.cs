using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace bot_sample.Helpers
{
    public static class ConfigurationHelper
    {
        public static double LuisMinimumScore
            => double.Parse(ConfigurationManager.AppSettings["LuisMinimumScore"]);

        public static string LuisBaseUri
            => ConfigurationManager.AppSettings["LuisBaseUri"];

        public static string LuisKnowledgeBaseId
            => ConfigurationManager.AppSettings["LuisKnowledgeBaseId"];

        public static string LuisEndpointKey
            => ConfigurationManager.AppSettings["LuisEndpointKey"];
    }
}