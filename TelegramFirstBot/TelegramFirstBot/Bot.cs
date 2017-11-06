using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TelegramFirstBot.Controllers;
using TelegramFirstBot.Data;
using TelegramFirstBot.Models;

namespace TelegramFirstBot
{
    class Bot
    {
        public BotAPI API { get; set; }

        public bool IsEnable { get; set; }

        public DbContext Db{ get; set; }

        public Bot(string ApiKey)
        {
            API = new BotAPI(ApiKey);
            Db = DbContext.Load();
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

                if (FindAction(update, type))
                    return;
            }

            API.SendMessage(update.Message.Chat, PrintHelp());
        }

        public string PrintHelp()
        {
            var sb = new StringBuilder();

            foreach (var type in typeof(Controllers.ControllerBase).Assembly.GetTypes())
            {
                if (type.BaseType != typeof(Controllers.ControllerBase))
                    continue;

                sb.AppendLine(PrintHelpController(type));
            }

            return sb.ToString();
        }

        public string PrintHelpController(Type controller)
        {
            var sb = new StringBuilder();

            // находим все методы,который содержат атрибут maskAttrib
            foreach (var method in controller.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                var maskAttrib = method.GetCustomAttribute<MessageMaskAttribute>();
                var descAttrib = method.GetCustomAttribute<DescriptionAttribute>();

                if (maskAttrib != null && descAttrib != null)
                {
                    var msg = descAttrib.Desc + " ";
                    var regx = new Regex(@"\([^\)]+\)");
                    var indexCounter = 0;

                    var pattern = regx.Replace(maskAttrib.Pattenrn, m => ReplaceParam(m, method, indexCounter++));
                    pattern = pattern.Replace("\\s", " ");
                    sb.AppendLine(msg + ":\t" + pattern);
                }
            }
            return sb.ToString();
        }

        private string ReplaceParam(Match match, MethodInfo method, int index)
        {
            var param = method.GetParameters()[index];

            var descAttr = param.GetCustomAttribute<DescriptionAttribute>();
            return $"[{descAttr.Desc}]";
        }

        private bool FindAction(Update update, Type type)
        {
            // находим все методы,который содержат атрибут maskAttrib
            foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                var maskAttrib = method.GetCustomAttribute<MessageMaskAttribute>();

                if (maskAttrib != null)
                {
                    var match = maskAttrib.Mask.Match(update.Message.Text);

                    if (match.Success)
                    {
                        InvokeAction(update, type, match, method);
                        return true;
                    }
                }
            }
            return false;
        }

        private void InvokeAction(Update update, Type type, Match match, MethodInfo method)
        {
            // создаёт из типа объект этого типа
            var controller = (ControllerBase) Activator.CreateInstance(type);
            controller.Bind(update, API, Db);

            // 
            var param = new List<object>();

            for (int i = 1; i < match.Groups.Count; i++)
            {
                var t = method.GetParameters()[i - 1].ParameterType;
                var val = Convert.ChangeType(match.Groups[i].Value, t);
                param.Add(val);
            }

            method.Invoke(controller, param.ToArray());
            return;
        }
    }
}
