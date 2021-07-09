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
    public class CommentSqlDAO : DAO, ICommentsDAO
    {
        public void AddComment(Comment commment)
        {
            using (SqlConnection con = new SqlConnection(strConToMSSQLDB()))
            {
                SqlCommand com = new SqlCommand("AddComment", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter[] prms = new SqlParameter[4];
                prms[0] = new SqlParameter("@Id_store", System.Data.SqlDbType.BigInt);
                prms[0].Value = commment.Id_store;
                prms[1] = new SqlParameter("@Id_user", System.Data.SqlDbType.BigInt);
                prms[1].Value = commment.Id_user;
                prms[2] = new SqlParameter("@Text", System.Data.SqlDbType.BigInt);
                prms[2].Value = commment.Text;
                prms[3] = new SqlParameter("@Rating", System.Data.SqlDbType.BigInt);
                prms[3].Value = commment.Rating;
                com.Parameters.AddRange(prms);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
        }

        public List<Comment> FindAllCommentsByStore(Store store)
        {
            List<Comment> list = new List<Comment>();
            using (SqlConnection con = new SqlConnection(strConToMSSQLDB()))
            {
                SqlCommand com = new SqlCommand("SelComment", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter prm = new SqlParameter("Id", System.Data.SqlDbType.BigInt);
                prm.Value = store.Id;
                com.Parameters.Add(prm);
                con.Open();
                SqlDataReader r = com.ExecuteReader();
                while (r.Read())
                {
                    Comment c = new Comment(
                        (long)r["id_store"],
                        (long)r["id_user"],
                        (string)r["text"],
                        (int)r["rating"]
                        );
                    list.Add(c);
                }
                con.Close();
            }
            return list;
        }
    }
}
