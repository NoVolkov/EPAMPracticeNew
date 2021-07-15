using SstuEpam.Shops.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SstuEpam.Shops.DAL.Interfaces
{
    public interface IUsersDAO
    {
        void AddUser(User user);
        void RemoveUser(string email);
        User SearchUserByEmail(string email);
        User SearchUserById(long id);
        List<User> SearchUsersByFIO(string surname, string name = null, string patronymic = null);
        User EditUser(string email);
    }
}

