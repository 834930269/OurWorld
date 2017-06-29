using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
namespace BLL
{
    public static class ArticleManager
    {
        /// <summary>
        /// 通过文章id获得文章
        /// </summary>
        public static Article GetArticleById(int id)
        {
            return ArticleServer.GetArticleById(id);
        }
        /// <summary>
        /// 获取全部文章
        /// </summary>
        /// <returns></returns>
        public static List<Article> GetAllArticles()
        {
            return ArticleServer.GetAllArticles();
        }
        /// <summary>
        /// 通过用户id获取全部文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Article> GetAllArticlesByUserId(int id)
        {
            return ArticleServer.GetUserAllArticles(id);
        }
        /// <summary>
        /// 发布新文章
        /// </summary>
        /// <returns></returns>
        public static bool PublishNowPost(string content, string title, string type)
        {
            return ArticleServer.AddNewArticle(content,title,type);
        }

        /// <summary>
        /// 通过文章id删除文章
        /// </summary>
        /// <param name="nID"></param>
        /// <returns></returns>
        public static bool DelArticleById(int nID)
        {
            return ArticleServer.DeleteArticleById(nID);
        }

        /// <summary>
        /// 通过文章id更新文章
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="aname"></param>
        /// <param name="nid"></param>
        /// <returns></returns>
        public static bool UpdateArticleById(string title,string content,string aname,int nid)
        {
            return ArticleServer.RePubArticleById(title,content,aname,nid);
        }
    }
}
