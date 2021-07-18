using SstuEpam.Shops.BLL.Interfaces;
using SstuEpam.Shops.DAL.Interfaces;
using SstuEpam.Shops.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SstuEpam.Shops.BLL.BLL
{
    public class UsersLogic : IUsersBLL
    {
        public IUsersDAO UsersDAO { get; set; }

        public UsersLogic(IUsersDAO dao)
        {
            UsersDAO = dao;
        }
        public void AddUser(User user)
        {
            UsersDAO.AddUser(user);
        }

        public User EditUser(string email, User newUser)
        {
            return UsersDAO.EditUser(email, newUser);
        }

        public User GetUserByEmail(string email)
        {
            return UsersDAO.SearchUserByEmail(email);
        }
        public User GetUserById(long id)
        {
            return UsersDAO.SearchUserById(id);
        }

        public List<User> GetUsers()
        {
            return UsersDAO.SearchUsersByFIO("");
        }

        public void RemoveUser(string email)
        {
            UsersDAO.RemoveUser(email);
        }
    }
}
