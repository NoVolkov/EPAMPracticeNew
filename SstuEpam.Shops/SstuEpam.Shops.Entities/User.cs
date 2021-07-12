using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SstuEpam.Shops.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public User(long id, string surname, string name, string patronymic, string email, string password, string role)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Email = email;
            Password = password;
            Role = role;
        }
        public override string ToString()
        {
            return Id + " " + Surname + " " + Name + " " + Patronymic + " " + Password + " " + Role;
        }
    }
}
