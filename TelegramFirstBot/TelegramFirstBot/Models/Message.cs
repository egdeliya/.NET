using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TelegramFirstBot.Models
{
    public class Message
    {
        [JsonProperty("message_id")]
        public int MessageId{ get; set; }

        [JsonProperty("text")]
        public string Text{ get; set; }

        [JsonProperty("from")]
        public User FromUser { get; set; }

        [JsonProperty("chat")]
        public Chat Chat { get; set; }
    }
}
