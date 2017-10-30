using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TelegramFirstBot.Models;

namespace TelegramFirstBot.Controllers
{
    class MainController: ControllerBase
    {
        [MessageMask("hello", RegexOptions.IgnoreCase)]
        public void Hello()
        {
            var msg = string.Format("Hello, {0}!", Update.Message.FromUser.FirstName);
            API.SendMessage(Update.Message.Chat, msg);
            //Console.WriteLine("Hello, {0}!", Update.Message.FromUser.FirstName);
        }

        [MessageMask(@"\d+")]
        public void Test()
        {
            //Console.WriteLine("Congratulations, {0}, test passed", Update.Message.FromUser.FirstName);
            var msg = $"Congratulations, {Update.Message.FromUser.FirstName}, test passed";
            API.SendMessage(Update.Message.Chat, msg);
        }

        [MessageMask("YouAreBot")]
        public void YouAreBot()
        {
            //Console.WriteLine("Oh my god...");
            API.SendMessage(Update.Message.Chat, "Oh my god...");
        }
    }
}
