using SstuEpam.Shops.DAL.Interfaces;
using SstuEpam.Shops.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SstuEpam.Shops.BLL.Interfaces
{
    public interface IUsersBLL
    {
        IUsersDAO UsersDAO { get; set; }
        void AddUser(User user);
        void RemoveUser(string email);
        User GetUserByEmail(string email);
        List<User> GetUsers();
        User EditUser(string email, User newUser);

    }
}
