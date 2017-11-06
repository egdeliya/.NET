using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramFirstBot.Data;
using TelegramFirstBot.Models;

namespace TelegramFirstBot.Controllers
{
    public abstract class ControllerBase
    {
        protected Update Update { get; private set; }
        protected BotAPI API { get; private set; }

        protected DbContext Db { get; private set; }

        public void Bind(Update update, BotAPI api, DbContext db)
        {
            Db = db;
            Update = update;
            API = api;
        }
    }
}
