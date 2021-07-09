using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SstuEpam.Shops.DAL.Interfaces
{
    public abstract class DAO
    {
        private string dbSource = "tcp:localhost,49721";
        private string dbName = "db_EpamPractice";
        private string dbUser = "USER";
        private string dbUserPassword = "123456";
        public string strConToMSSQLDB()
        {
            return new StringBuilder(@"Data Source=*\SOURCEDB*\; Initial Catalog=*\NAMEDB*\; Persist Security Info=True; User ID=*\USERNAME*\; Password=*\USERPASSWORD*\")
                .Replace("*\\SOURCEDB*\\", dbSource)
                .Replace("*\\NAMEDB*\\", dbName)
                .Replace("*\\USERNAME*\\", dbUser)
                .Replace("*\\USERPASSWORD*\\", dbUserPassword)
                .ToString();
        }
    }
}
