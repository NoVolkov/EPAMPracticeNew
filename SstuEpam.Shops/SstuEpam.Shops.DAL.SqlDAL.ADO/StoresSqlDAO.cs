using SstuEpam.Shops.DAL.Interfaces;
using SstuEpam.Shops.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SstuEpam.Shops.DAL.SqlDAL
{
    public class StoresSqlDAO : DAO, IStoresDAO
    {
        public void AddStore(Store store)
        {
            using (SqlConnection con = new SqlConnection(strConToMSSQLDB()))
            {
                SqlCommand com = new SqlCommand("AddStore", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter[] prms = new SqlParameter[3];
                prms[0] = new SqlParameter("@Name", System.Data.SqlDbType.NVarChar, 50);
                prms[0].Value = store.Name;
                prms[1] = new SqlParameter("@Address", System.Data.SqlDbType.NVarChar, 50);
                prms[1].Value = store.Address;
                prms[2] = new SqlParameter("@Website", System.Data.SqlDbType.NVarChar, 50);
                prms[2].Value = store.Website;
                com.Parameters.AddRange(prms);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
        }//+

        public void EditStore(long id, Store newStore)
        {
            using (SqlConnection con = new SqlConnection(strConToMSSQLDB()))
            {
                SqlCommand com = new SqlCommand("UpdComment", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter[] prms = new SqlParameter[4];
                prms[0] = new SqlParameter("@Name", System.Data.SqlDbType.NVarChar, 50);
                prms[0].Value = newStore.Name;
                prms[1] = new SqlParameter("@Rating", System.Data.SqlDbType.Char, 1);
                prms[1].Value = newStore.Rating;
                prms[2] = new SqlParameter("@Address", System.Data.SqlDbType.NVarChar, 50);
                prms[2].Value = newStore.Address;
                prms[3] = new SqlParameter("@Website", System.Data.SqlDbType.NVarChar, 50);
                prms[3].Value = newStore.Website;
                com.Parameters.AddRange(prms);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
        }

        public List<Store> FindAllStores()
        {
            List<Store> list = new List<Store>();
            using (SqlConnection con = new SqlConnection(strConToMSSQLDB()))
            {
                SqlCommand com = new SqlCommand("SelStores", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader r = com.ExecuteReader();
                while (r.Read())
                {
                    Store s = new Store(
                        (long)r["id"],
                        (string)r["name"],
                        (string)r["rating"],
                        (string)r["address"],
                        (string)r["website"]
                        );
                    list.Add(s);
                }
                con.Close();
            }
            return list;
        }//+

        public void RemoveStore(long id)
        {
            using (SqlConnection con = new SqlConnection(strConToMSSQLDB()))
            {
                SqlCommand com = new SqlCommand("DelStore", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter prm = new SqlParameter("id", System.Data.SqlDbType.BigInt);
                prm.Value = id;
                com.Parameters.Add(prm);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
        }//+

        public Store SearchStoreByName(string wordForSearch)
        {
            throw new NotImplementedException();
        }
    }
}
