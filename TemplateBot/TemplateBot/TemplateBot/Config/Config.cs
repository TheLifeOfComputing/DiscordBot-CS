using System.IO;
using Newtonsoft.Json;

namespace TemplateBot.Config
{
    class Config
    {
        protected const string configFolder = "../../../Config";
        protected const string configFile = "config.json";
        protected const string path = configFolder + "/" + configFile;

        public static BotConfig bot;

        static Config()
        {
            if (!File.Exists(path))
            {
                bot = new BotConfig();
                string json = JsonConvert.SerializeObject(bot, Formatting.Indented);
                File.WriteAllText(path, json);
            }
            else
            {
                string json = File.ReadAllText(path);
                bot = JsonConvert.DeserializeObject<BotConfig>(json);
            }
        }
    }

    public struct BotConfig
    {
        public string token;
        public string cmdPrefix;
    }
}
