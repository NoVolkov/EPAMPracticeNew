using SstuEpam.Shops.DAL.Interfaces;
using SstuEpam.Shops.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SstuEpam.Shops.DAL.SqlDAL.ADO
{
    public class UsersSqlDAO : DAO, IUsersDAO
    {
        public void AddUser(User user)
        {
            using (SqlConnection con = new SqlConnection(strConToMSSQLDB()))
            {
                SqlCommand com = new SqlCommand("AddUser", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter[] prms = new SqlParameter[6];
                prms[0] = new SqlParameter("@Surname", System.Data.SqlDbType.NVarChar, 50);
                prms[0].Value = user.Surname;
                prms[1] = new SqlParameter("@Name", System.Data.SqlDbType.NVarChar, 50);
                prms[1].Value = user.Name;
                prms[2] = new SqlParameter("@Patronymic", System.Data.SqlDbType.NVarChar, 50);
                prms[2].Value = user.Patronymic;
                prms[3] = new SqlParameter("@Email", System.Data.SqlDbType.NVarChar, 50);
                prms[3].Value = user.Email;
                prms[4] = new SqlParameter("@Password", System.Data.SqlDbType.NChar, 64);
                prms[4].Value = user.Password;
                prms[5] = new SqlParameter("@Role", System.Data.SqlDbType.NVarChar, 50);
                prms[5].Value = user.Role;
                com.Parameters.AddRange(prms);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
        }

        public User EditUser(string email)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(string email)
        {
            using (SqlConnection con = new SqlConnection(strConToMSSQLDB()))
            {
                SqlCommand com = new SqlCommand("DelUser", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter prm = new SqlParameter("@Email", System.Data.SqlDbType.NVarChar, 50);
                prm.Value = email;
                com.Parameters.Add(prm);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
        }

        public User SearchUserByEmail(string email)
        {
            User u = null;
            using (SqlConnection con = new SqlConnection(strConToMSSQLDB()))
            {
                SqlCommand com = new SqlCommand("SelUser", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter prm = new SqlParameter("@Email", System.Data.SqlDbType.NVarChar, 50);
                prm.Value = email;
                com.Parameters.Add(prm);
                con.Open();
                SqlDataReader r = com.ExecuteReader();
                while (r.Read())
                {
                    u = new User(
                        (long)r["id"],
                        (string)r["surname"],
                        (string)r["name"],
                        (string)r["patronymic"],
                        (string)r["email"],
                        (string)r["password"],
                        (string)r["role"]
                        );
                }
                con.Close();
            }
            return u;
        }

        public User SearchUserById(long id)
        {
            User u = null;
            using (SqlConnection con = new SqlConnection(strConToMSSQLDB()))
            {
                SqlCommand com = new SqlCommand("SelUserById", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter prm = new SqlParameter("@Id", System.Data.SqlDbType.BigInt);
                prm.Value = id;
                com.Parameters.Add(prm);
                con.Open();
                SqlDataReader r = com.ExecuteReader();
                while (r.Read())
                {
                    u = new User(
                        (long)r["id"],
                        (string)r["surname"],
                        (string)r["name"],
                        (string)r["patronymic"],
                        (string)r["email"],
                        (string)r["password"],
                        (string)r["role"]
                        );
                }
                con.Close();
            }
            return u;
        }

        //процедура с необязательными параметрами?? - сомневаюсь
        //несколько процедур с перебором всех возможных вариантов параметров - такое себе
        //сделать спец таблицу, по которой можно производить поиск - надо подумать
        public List<User> SearchUsersByFIO(string surname, string name = null, string patronymic = null)
        {
            throw new NotImplementedException();
        }
    }
}
