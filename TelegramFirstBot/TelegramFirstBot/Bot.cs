using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TelegramFirstBot.Controllers;
using TelegramFirstBot.Models;

namespace TelegramFirstBot
{
    class Bot
    {
        public BotAPI API { get; set; }

        public bool IsEnable { get; set; }

        public Bot(string ApiKey)
        {
            API = new BotAPI(ApiKey);
        }

        public void Begin()
        {
            IsEnable = true;
            var maxUpdateId = 0;

            while (IsEnable)
            {
                var result = API.GetUpdates(maxUpdateId);

                if (result.Result.Count == 0)
                {
                    continue;
                }

                maxUpdateId = result.Result.Select(x => x.UpdateId).Max() + 1;

                foreach (var update in result.Result)
                {
                    ProcessUpdate(update);
                }
                
                Task.Delay(200).Wait();
            }
        }

        private void ProcessUpdate(Update update)
        {
            Console.WriteLine($"{update.Message.FromUser.FirstName}: {update.Message.Text}");

            // смотрим, есть ли подходящие методы
            // в зависимости от текста поста вызываем нужные методы
            foreach (var type in typeof(Controllers.ControllerBase).Assembly.GetTypes())
            {
                if (type.BaseType != typeof(Controllers.ControllerBase))
                    continue;

                foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    var maskAttrib = method.GetCustomAttribute<MessageMaskAttribute>();


                    if (maskAttrib != null && maskAttrib.Mask.IsMatch(update.Message.Text))
                    {
                        // создаёт из типа объект этого типа
                        var controller = (ControllerBase)Activator.CreateInstance(type);
                        controller.Bind(update, API);

                        method.Invoke(controller, new object[] {});
                        return;
                    }
                }
            }
        }
    }
}
