using SstuEpam.Shops.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SstuEpam.Shops.PL.AspPL.Models
{
    public class StoreModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string Rating { get; set; }
        public List<CommentModel> comments;
        public StoreModel() { }
        public StoreModel(Store s)
        {
            Id = s.Id;
            Name = s.Name;
            Address = s.Address;
            Website = s.Website;
            Rating = s.Rating;
        }

        public StoreModel(string name, string address, string website, string rating)
        {
            Name = name;
            Address = address;
            Website = website;
            Rating = rating;
        }
    }
}