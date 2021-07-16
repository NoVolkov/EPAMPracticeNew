using SstuEpam.Shops.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SstuEpam.Shops.DAL.Interfaces
{
    public interface ICommentsDAO
    {
        void AddComment(Comment commment);
        List<Comment> FindAllCommentsByStore(Store store);
        int QuantityCommentsByIdStore(long idStore);
    }
}
