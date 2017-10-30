using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TelegramFirstBot.Models
{
    public class Chat
    {
        [JsonProperty("id")]
        public int ChatId { get; set; }
        [JsonProperty("title")]
        public String Title{ get; set; }
    }
}
