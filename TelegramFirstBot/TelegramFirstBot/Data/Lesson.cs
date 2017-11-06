using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramFirstBot.Data
{
    [Serializable]
    public class Lesson
    {
        public string Name { get; set; }
        public int Cabinet { get; set; }

    }
}
