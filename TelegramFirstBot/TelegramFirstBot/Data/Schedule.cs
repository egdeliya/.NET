using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace TelegramFirstBot.Data
{
    [Serializable]
    public class Schedule
    {
        public List<Day> Days { get; set; }

        public Schedule()
        {
            Days = new List<Day>();

            for (int i = 0; i < 7; i++)
            {
                Days.Add(new Day());
            }
        }
    }
}
