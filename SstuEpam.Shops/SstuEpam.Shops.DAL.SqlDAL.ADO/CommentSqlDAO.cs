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
                prms[2] = new SqlParameter("@Text", System.Data.SqlDbType.NVarChar,200);
                prms[2].Value = commment.Text;
                prms[3] = new SqlParameter("@Rating", System.Data.SqlDbType.Int);
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
                SqlCommand com = new SqlCommand("SelComments", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter prm = new SqlParameter("Id_store", System.Data.SqlDbType.BigInt);
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

        public int QuantityCommentsByIdStore(long idStore)
        {
            int r=0;
            using (SqlConnection con = new SqlConnection(strConToMSSQLDB()))
            {
                SqlCommand com = new SqlCommand("QuantityComments", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter[] prms = new SqlParameter[2];
                prms[0] = new SqlParameter("Id_Store", System.Data.SqlDbType.BigInt);
                prms[0].Value =idStore;
                prms[1] = new SqlParameter { ParameterName = "@Quantity", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output };
                com.Parameters.AddRange(prms);
                con.Open();
                com.ExecuteNonQuery();
                r = (int)com.Parameters["@Quantity"].Value;
               
                con.Close();
            }
            return r;
        }
    }
}
