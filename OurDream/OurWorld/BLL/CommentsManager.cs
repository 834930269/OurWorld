using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
namespace BLL
{
    public static class CommentsManager
    {
        /// <summary>
        /// 通过url传过来的参数aid得到评论列表
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        public static List<comments> GetCommentByAid(int aid)
        {
            return CommentsServer.GetCommentByAid(aid);
        }

        /// <summary>
        /// 通过博文id添加评论
        /// </summary>
        /// <param name="title"></param>
        /// <param name="huifu"></param>
        /// <param name="blogid"></param>
        /// <returns></returns>
        public static bool SetCommentByAid(string title,string huifu,int blogid)
        {
            int id;
            if (Now_User.now_user == "") id = 0;
            else id = Now_User.now_user_id;
            //id=0为游客
            return CommentsServer.AddNewComment(title,huifu,blogid,id);
        }

        /// <summary>
        /// 通过now_user_id得到评论列表
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static List<comments> GetCommentByUid(int aid)
        {
            return CommentsServer.GetCommentByUid(aid);
        }

        /// <summary>
        /// 通过评论id删除评论
        /// </summary>
        /// <param name="Cid"></param>
        /// <returns></returns>
        public static bool DelCommentByCid(int Cid)
        {
            return CommentsServer.DelCommentByCid(Cid);
        }

        /// <summary>
        /// 通过评论id更新评论
        /// </summary>
        /// <param name="title"></param>
        /// <param name="huifu"></param>
        /// <param name="cid"></param>
        /// <returns></returns>
        public static bool UpdateCommentByCid(string title, string huifu, int cid)
        {
            return CommentsServer.UpdateCommentByCid(title,huifu,cid);
        }
    }
}
