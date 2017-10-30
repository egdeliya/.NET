using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TelegramFirstBot.Models;

namespace TelegramFirstBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Settings setting;

            if (File.Exists("settings.json"))
            {
                var data = File.ReadAllText("settings.json");
                setting = JsonConvert.DeserializeObject<Settings>(data);
            }
            else
            {
                setting = new Settings();
            }


            var bot = new Bot(setting.Key);
            bot.Begin();
        }
    }
}
