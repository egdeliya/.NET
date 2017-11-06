using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TelegramFirstBot.Data
{
    [Serializable]
    public class DbContext
    {
        private const string DbFile = "database.dat";
        public List<TelegramUser> Users{ get; set; }
        public List<Lesson> Lessons{ get; set; }
        public List<Schedule> Schedules{ get; set; }

        public DbContext()
        {
            Users = new List<TelegramUser>();
            Lessons = new List<Lesson>();
            Schedules = new List<Schedule>();
        }

        public void Save()
        {
            var bf = new BinaryFormatter();
            using (var fs = File.OpenWrite(DbFile))
            {
                bf.Serialize(fs, this);
            }
        }

        public static DbContext Load()
        {
            if (!File.Exists(DbFile))
                return new DbContext();

            var bf = new BinaryFormatter();
            using (var fs = File.OpenRead(DbFile))
            {
                return (DbContext)bf.Deserialize(fs);
            }

        }


    }
}
