using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SstuEpam.Shops.Entities
{
    public class Comment
    {
        public long Id_store { get; }
        public long Id_user { get; }
        public string Text { get; }
        public int Rating { get; }

        public Comment(long id_store, long id_user, string text, int rating)
        {
            Id_store = id_store;
            Id_user = id_user;
            Text = text;
            Rating = rating;
        }
    }
}
