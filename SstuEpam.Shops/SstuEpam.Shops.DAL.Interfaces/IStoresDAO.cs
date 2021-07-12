using SstuEpam.Shops.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SstuEpam.Shops.DAL.Interfaces
{
    public interface IStoresDAO
    {
        void AddStore(Store store);
        void RemoveStore(long id);
        Store SearchStoreByName(string wordForSearch);
        Store SearchStoreById(long id);
        List<Store> FindAllStores();
        void EditStore(long id, Store newStore);
    }
}
