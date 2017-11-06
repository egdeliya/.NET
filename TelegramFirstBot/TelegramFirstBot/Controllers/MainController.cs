using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using TelegramFirstBot.Data;
using TelegramFirstBot.Models;

namespace TelegramFirstBot.Controllers
{
    class MainController: ControllerBase
    {
        [MessageMask("hello", RegexOptions.IgnoreCase)]
        public void Hello()
        {
            
            //Console.WriteLine("Hello, {0}!", Update.Message.FromUser.FirstName);

            var user = Db.Users.FirstOrDefault(x => x.Id == Update.Message.FromUser.UserId);

            if (user != null)
            {
                var msg = string.Format("Hello, {0}!", Update.Message.FromUser.FirstName);
                API.SendMessage(Update.Message.Chat, msg);
            }
            else
            {
                var msg = string.Format("Привет, {0}! Напиши мне своё расписание", Update.Message.FromUser.FirstName);
                API.SendMessage(Update.Message.Chat, msg);
            }
        }

        [MessageMask(@"что у меня (\d+)", RegexOptions.IgnoreCase)]
        [Description("Показать пары")]
        public void PrintDay([Description("День")]int Day)
        {
            var user = Db.Users.FirstOrDefault(x => x.Id == Update.Message.FromUser.UserId);

            if (user == null)
            {
                API.SendMessage(Update.Message.Chat, "Я тебя не знаю");
                return;
            }

            if (user.Schedule == null)
            {
                API.SendMessage(Update.Message.Chat, "Я не знаю");
                return;
            }

            if (user.Schedule.Days[Day-1].Lessons.Any())
            {
                foreach (var lesson in user.Schedule.Days[Day].Lessons)
                {
                    API.SendMessage(Update.Message.Chat, $"{lesson.Value.Name} кабинет {lesson.Value.Cabinet}");
                }
            }
            else
            {
                API.SendMessage(Update.Message.Chat, "выходной");
            }


        }

        [MessageMask(@"запомни (\d+)\s+(\d+)\s+(\w+)\s+(\d+)", RegexOptions.IgnoreCase)]
        [Description("Запомнить пары")]
        public void Remember([Description("День")]int Day, 
                            [Description("Номер пары")]int Num,
                            [Description("Название пары")]string LessonName,
                            [Description("Кабинет")]int Cabinet)
        {

            var user = Db.Users.FirstOrDefault(x => x.Id == Update.Message.FromUser.UserId);

            if (user == null)
            {
                user = new TelegramUser()
                {
                    Id = Update.Message.FromUser.UserId,
                    Name = Update.Message.FromUser.FirstName
                };
                Db.Users.Add(user);
            }

            var schedule = user.Schedule;

            if (schedule == null)
            {
                schedule = new Schedule();
                user.Schedule = schedule;
                Db.Schedules.Add(schedule);
            }

            if (Day < 1 || Day > 7)
            {
                var msg = string.Format("В неделе 1 дней!!");
                API.SendMessage(Update.Message.Chat, msg);
            }

            var day = schedule.Days[Day - 1];
            var lesson = new Lesson()
            {
                Name = LessonName,
                Cabinet = Cabinet
            };

            if (day.Lessons.ContainsKey(Num))
            {
                day.Lessons[Num] = lesson;

            }
            else
            {
                day.Lessons.Add(Num, lesson);
            }

            Db.Save();

            API.SendMessage(Update.Message.Chat, "Запомнил");


        }

        //[MessageMask(@"\d+")]
        //public void Test()
        //{
        //    //Console.WriteLine("Congratulations, {0}, test passed", Update.Message.FromUser.FirstName);
        //    var msg = $"Congratulations, {Update.Message.FromUser.FirstName}, test passed";
        //    API.SendMessage(Update.Message.Chat, msg);
        //}

        //[MessageMask("YouAreBot")]
        //public void YouAreBot()
        //{
        //    //Console.WriteLine("Oh my god...");
        //    API.SendMessage(Update.Message.Chat, "Oh my god...");
        //}
    }
}
