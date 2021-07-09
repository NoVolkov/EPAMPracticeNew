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
    public class CommentLogic : ICommentsBLL
    {
        public ICommentsDAO CommentsDAO { get; set; }

        public CommentLogic(ICommentsDAO dao)
        {
            CommentsDAO = dao;
        }
        public void AddComment(Comment comment)
        {
            CommentsDAO.AddComment(comment);
        }

        public List<Comment> GetCommentByStore(Store store)
        {
            return CommentsDAO.FindAllCommentsByStore(store);
        }


    }
}
