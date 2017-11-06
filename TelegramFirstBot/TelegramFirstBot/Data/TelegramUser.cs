using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramFirstBot.Data
{
    [Serializable]
    public class TelegramUser
    {
        public string Name { get; set; }
        public Schedule Schedule { get; set; }

        public int Id{ get; set; }
    }
}
