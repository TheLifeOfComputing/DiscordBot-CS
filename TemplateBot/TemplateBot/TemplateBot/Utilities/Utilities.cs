using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TemplateBot.Utilities
{
    class Utilities
    {
        private static Dictionary<string, string> alerts;

        static Utilities()
        {
            string json = File.ReadAllText("systemLang/alerts.json");

            var data = JsonConvert.DeserializeObject<dynamic>(json);

            alerts = data.ToObject<Dictionary<string, string>>();
        }

        public static string GetAlert(string key)
        {
            if (alerts.ContainsKey(key))
                return key;

            return "";
        }
    }
}
