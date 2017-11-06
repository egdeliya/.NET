using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TelegramFirstBot
{
    public class MessageMaskAttribute : Attribute
    {
        public Regex Mask { get; set; }

        public string Pattenrn{ get; set; }

        public MessageMaskAttribute(string pattern, RegexOptions RegexOptions = RegexOptions.None)
        {
            Mask = new Regex(pattern, RegexOptions);
            Pattenrn = pattern;
        }
    }

    public class DescriptionAttribute : Attribute
    {
        public string Desc{ get; set; }

        public DescriptionAttribute(string description)
        {
            Desc = description;
        }
    }

}
