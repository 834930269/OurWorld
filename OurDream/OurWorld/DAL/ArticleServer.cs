using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public static class ArticleServer
    {
        //SSMS类->和处理直接与数据库相连的公共方法有关的类.

        /// <summary>
        /// 通过文章id获得文章
        /// </summary>
        public static Article GetArticleById(int id)
        {
            string sql = "SELECT * FROM news WHERE nID = " + id.ToString();
            int authorId;
            SqlDataReader reader = SSMS.GetReader(sql);
            if (reader.Read())
            {
                Article article = new Article();
                article.NID = (int)reader["nID"];
                article.NTitle = (string)reader["ntitle"];
                article.NContent = (string)reader["ncontent"];
                article.NDate = (DateTime)reader["ndate"];
                authorId = (int)reader["id"];
                article.Nkey = (string)reader["nkey"];
                article.Aname = (string)reader["aname"];
                reader.Close();
                article.Author = UserServer.GetUserById(authorId);
                return article;
            }
            else
            {
                reader.Close();
                return null;
            }
        }

        /// <summary>
        /// 获取用户全部文章
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static List<Article> GetUserAllArticles(int userId)
        {
            string sqlAll = "SELECT * FROM news where id=" + userId.ToString();

            return GetArticlesBySql(sqlAll);
        }

        /// <summary>
        /// 获取全部文章
        /// </summary>
        /// <returns></returns>
        public static List<Article> GetAllArticles()
        {
            string sqlAll = "SELECT * FROM news order by ndate DESC";
            return GetArticlesBySql(sqlAll);
        }

        /// <summary>
        /// 通过sql获取
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        private static List<Article> GetArticlesBySql(string sql)
        {
            List<Article> list = new List<Article>();
            DataTable table = SSMS.GetDataSet(sql);
            foreach (DataRow row in table.Rows)
            {
                Article article = new Article();

                article.NID = (int)row["nID"];
                article.NTitle = (string)row["ntitle"];
                article.NContent = (string)row["ncontent"];
                article.NDate = (DateTime)row["ndate"];
                article.Nkey = (string)row["nkey"];
                article.Aname = (string)row["aname"];
                article.Author = UserServer.GetUserById((int)row["id"]); //FK
                list.Add(article);
            }
            return list;
        }

        /// <summary>
        /// 添加新文章(当前用户id和用户名已知)
        /// </summary>
        /// <returns></returns>
        public static bool AddNewArticle(string content,string title,string type)
        {
            if (type == "") type = "未分类";
            string zhaiyao = content.Length > 50 ? content.Substring(0, 50) : content;
            string pubtime = Now_User.GetNowTime();
            string sql = "INSERT news(id,ntitle,nkey,ncontent,ndate,aname) "+
            "VALUES('" + Now_User.now_user_id + "','" + title + "','" + zhaiyao + "','" + content + "','" + pubtime + "','" + type + "')";
            sql += " ; SELECT @@IDENTITY";
            int newid = SSMS.GetScalar(sql);
            if (newid > 0) return true;
            else return false;
        }

        /// <summary>
        /// 通过文章id删除文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteArticleById(int nid)
        {
            string sql = "DELETE news WHERE nID="+nid.ToString();
            if (SSMS.ExecuteCommand(sql)>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 通过文章id修改文章
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="aname"></param>
        /// <returns></returns>
        public static bool RePubArticleById(string title,string content,string aname,int nid){
            string zhaiyao = content.Length > 50 ? content.Substring(0, 50) : content;//摘要
            string pubtime = Now_User.GetNowTime();
            if(aname=="")aname="未分类";
            string sql = "UPDATE news SET " +
                        "ntitle=" + "'" + title + "'," +
                        "ncontent=" + "'" + content + "'," +
                        "nkey=" + "'" + zhaiyao + "'," +
                        "aname=" + "'" + aname + "'," +
                        "ndate=" + "'" + pubtime + "' " +" WHERE nid=" + nid;
            int result=SSMS.ExecuteCommand(sql);
            if (result > 0) return true;
            else return false;
        }
    }
}
