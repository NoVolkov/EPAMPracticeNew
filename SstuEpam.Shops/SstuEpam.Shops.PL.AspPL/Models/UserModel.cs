using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SstuEpam.Shops.PL.AspPL.Models
{
    public class UserModel : Entities.User
    {
        public UserModel(long id, string surname, string name, string patronymic, string email, string password, string role) 
            : base(id,surname,name,patronymic,email,password,role)
        {

        }
        
    }
}