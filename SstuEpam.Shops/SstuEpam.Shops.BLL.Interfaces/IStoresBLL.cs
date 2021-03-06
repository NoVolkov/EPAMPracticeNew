using SstuEpam.Shops.DAL.Interfaces;
using SstuEpam.Shops.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SstuEpam.Shops.BLL.Interfaces
{
    public interface IStoresBLL
    {
        IStoresDAO StoresDAO { get; set; }
        void AddStore(Store store);
        void RemoveStore(long id);
        Store GetStoreByName(string wordForSearch);
        Store GetStoreById(long id);
        List<Store> GetStores();
        void EditStore(long id, Store newStore);
        void EditRatingStore(long idStore, int rating);
    }
}
