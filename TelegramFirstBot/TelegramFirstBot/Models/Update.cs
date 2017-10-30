﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TelegramFirstBot.Models
{
    public class Update
    {
        [JsonProperty("update_id")]
        public int UpdateId{ get; set; }

        [JsonProperty("message")]
        public Message Message { get; set; }
    }

}
