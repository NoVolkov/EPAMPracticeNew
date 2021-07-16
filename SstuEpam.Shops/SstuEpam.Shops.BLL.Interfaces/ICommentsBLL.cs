using SstuEpam.Shops.DAL.Interfaces;
using SstuEpam.Shops.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SstuEpam.Shops.BLL.Interfaces
{
    public interface ICommentsBLL
    {
        ICommentsDAO CommentsDAO { get; set; }
        void AddComment(Comment comment);
        List<Comment> GetCommentByStore(Store store);
        int GetQuantityCommentsByIdStore(long idStore);
    }
}
