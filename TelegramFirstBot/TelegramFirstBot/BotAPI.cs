using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TelegramFirstBot.Models;

namespace TelegramFirstBot
{
    public class BotAPI
    {
        public string Key { get; set; }

        public BotAPI(string ApiKey)
        {
            Key = ApiKey;
        }

        public UpdateResult GetUpdates(int maxUpdateId)
        {
            var url = String.Format("https://api.telegram.org/bot{0}/getUpdates?offset={1}", Key, maxUpdateId);
            var request = (HttpWebRequest)WebRequest.Create(url);

            // обёртка
            // это можно делать при использовании больших объектов или потоков,
            // чтобы сразу же вызывать дял них деструктор
            // и не хранить в памяти
            using (var response = (HttpWebResponse)request.GetResponseAsync().Result)
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var data = reader.ReadToEnd();

                return JsonConvert.DeserializeObject<UpdateResult>(data);
                
            }

        }

        public void SendMessage(Chat TargetChat, string Message)
        {
            var url = String.Format("https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}",
                Key, TargetChat.ChatId, Message);

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.GetResponseAsync();
        }
    }
}
