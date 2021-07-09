using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SstuEpam.Shops.Entities
{
    public class User
    {
        public long Id { get; }
        public string Surname { get; }
        public string Name { get; }
        public string Patronymic { get; }
        public string Email { get; }
        public string Password { get; }
        public string Role { get; }

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
