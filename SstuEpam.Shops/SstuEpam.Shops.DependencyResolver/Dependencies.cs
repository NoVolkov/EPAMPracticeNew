using SstuEpam.Shops.BLL.BLL;
using SstuEpam.Shops.BLL.Interfaces;
using SstuEpam.Shops.DAL.Interfaces;
using SstuEpam.Shops.DAL.SqlDAL;
using SstuEpam.Shops.DAL.SqlDAL.ADO;
using System;

namespace SstuEpam.Shops.DependencyResolver
{
    public class Dependencies
    {
        #region DAO
        public IStoresDAO GetStoresDAO { get; }
        public IUsersDAO GetUsersDAO { get; }
        public ICommentsDAO GetCommentsDAO { get; }
        #endregion
        #region BLL
        public IUsersBLL GetUsersBLL { get; }
        public IStoresBLL GetStoresBLL { get; }
        public ICommentsBLL GetCommentsBLL { get; }
        #endregion
        private static Lazy<Dependencies> _instance = new Lazy<Dependencies>(() => new Dependencies());

        public static Dependencies Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        private Dependencies()
        {
            GetStoresDAO = new StoresSqlDAO();
            GetUsersDAO = new UsersSqlDAO();
            GetCommentsDAO = new CommentSqlDAO();

            GetUsersBLL = new UsersLogic(GetUsersDAO);
            GetStoresBLL = new StoresLogic(GetStoresDAO);
            GetCommentsBLL = new CommentLogic(GetCommentsDAO);


        }
    }
}
