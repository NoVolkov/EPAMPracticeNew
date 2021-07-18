using SstuEpam.Shops.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SstuEpam.Shops.PL.AspPL.Models
{
    public class UserModel
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public UserModel() { }
        public UserModel(User u)
        {
            Surname = u.Surname;
            Name = u.Name;
            Patronymic = u.Patronymic;
            Email = u.Email;
            Role = u.Role;
        }
    }
}