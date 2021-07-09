using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SstuEpam.Shops.Entities
{
    public class Store
    {
        public long Id { get; }
        public string Name { get; }
        public string Rating { get; } // от 0 до 5
        public string Address { get; }
        public string Website { get; }

        public Store(long id, string name, string rating, string address, string website)
        {
            Id = id;
            Name = name;
            Rating = rating;
            Address = address;
            Website = website;
        }
    }
}
