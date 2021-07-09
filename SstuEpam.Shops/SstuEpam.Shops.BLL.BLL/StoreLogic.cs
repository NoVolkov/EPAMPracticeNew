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
    public class StoresLogic : IStoresBLL
    {
        public IStoresDAO StoresDAO { get; set; }

        public StoresLogic(IStoresDAO dao)
        {
            StoresDAO = dao;
        }
        //проверку на существование данной записи
        //??возвращать значения ошибок
        public void AddStore(Store store)
        {
            StoresDAO.AddStore(store);
        }

        public void EditStore(long id, Store newStore)
        {
            StoresDAO.EditStore(id, newStore);
        }

        public Store GetStoreByName(string wordForSearch)
        {
            return StoresDAO.SearchStoreByName(wordForSearch);
        }

        public List<Store> GetStores()
        {
            return StoresDAO.FindAllStores();
        }

        public void RemoveStore(long id)
        {
            StoresDAO.RemoveStore(id);
        }
    }
}
