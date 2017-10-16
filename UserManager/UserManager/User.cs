using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager
{
    public enum UserType
    {
        User, 
        Moderator,
        Admin
    }
    public class User
    {
        public String Name { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public UserType Type{ get; set; }

        public static User[] GetUserts()
        {
            return new User[]
            {
                new User() {Name = "Ivan", Phone = "123123", Email = "ivan@mail.ru", Type = UserType.Moderator},
                new User() {Name = "Lala", Phone = "049203", Email = "lala@mail.ru", Type = UserType.User},
                new User() {Name = "Namd", Phone = "345983049", Email = "namd@mail.ru", Type = UserType.Admin},
                new User() {Name = "Mega", Phone = "11111", Email = "mega@mail.ru", Type = UserType.Moderator}
            };
        }

        public override string ToString()
        {
            return "I am" + Name;
        }
    }
}
