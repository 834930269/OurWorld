using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
namespace DAL
{
    public static class CommentsServer
    {

        /// <summary>
        /// 通过文章id添加新回复
        /// </summary>
        /// <param name="title"></param>
        /// <param name="huifu"></param>
        /// <param name="aid"></param>
        /// <returns></returns>
        public static bool AddNewComment(string title, string huifu, int blogid,int id)
        {
            //id=0,为游客
            string sql = "INSERT comment(id,huifu,Publictime,blogid,title)"+
                " VALUES("+id+",'"+huifu+"','"+Now_User.GetNowTime()+"',"+blogid+",'"+title+"')";
            sql += " ; SELECT @@IDENTITY";
            int result = SSMS.GetScalar(sql);
            if (result > 0) return true;
            else return false;
        }

        /// <summary>
        /// 通过aid获得评论列表
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        public static List<comments> GetCommentByAid(int aid)
        {
            string sqlAll = "SELECT * FROM comment WHERE blogid = "+aid;
            return GetCommentsBySql(sqlAll);
        }

        /// <summary>
        /// 通过sql获得评论列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private static List<comments> GetCommentsBySql(string sql)
        {
            List<comments> list = new List<comments>();
            DataTable table = SSMS.GetDataSet(sql);
            foreach (DataRow row in table.Rows)
            {
                comments comment = new comments();
                comment.Title = (string)row["title"];//标题
                comment.Id = (int)row["id"];//用户id
                comment.CId = (int)row["cid"];//评论id
                comment.BlogId = (int)row["blogid"];//文章id
                comment.Huifu = (string)row["huifu"];//回复内容
                comment.PubDate = (DateTime)row["Publictime"];//回复时间
                comment.Article = ArticleServer.GetArticleById((int)row["blogid"]); //通过文章id获取文章
                list.Add(comment);
            }
            return list;
        }

        /// <summary>
        /// 通过用户id获得评论列表
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        public static List<comments> GetCommentByUid(int id)
        {
            string sqlAll = "SELECT * FROM comment WHERE id = " + id;
            return GetCommentsBySql(sqlAll);
        }

        /// <summary>
        /// 通过评论id删除评论
        /// </summary>
        /// <param name="Cid"></param>
        /// <returns></returns>
        public static bool DelCommentByCid(int Cid)
        {
            string sql = "DELETE comment WHERE cid=" + Cid;
            if (SSMS.ExecuteCommand(sql) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 通过评论id修改评论
        /// </summary>
        /// <param name="title"></param>
        /// <param name="huifu"></param>
        /// <param name="Cid"></param>
        /// <returns></returns>
        public static bool UpdateCommentByCid(string title, string huifu, int Cid)
        {
            string Publictime = Now_User.GetNowTime();
            int uid = Now_User.now_user_id;
            string sql = "UPDATE comment SET " +
                        "title=" + "'" + title + "'," +
                        "huifu=" + "'" + huifu + "'," +
                        "Publictime=" + "'" + Publictime + "' " + " WHERE cid=" + Cid;
            int result = SSMS.ExecuteCommand(sql);
            if (result > 0) return true;
            else return false;
        }
    }
}
