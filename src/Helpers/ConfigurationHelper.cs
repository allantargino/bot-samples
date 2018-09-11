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
    }
}