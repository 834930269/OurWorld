using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
namespace BLL
{
    public static class FriendLinkManager
    {
        /// <summary>
        /// 获取全部友链
        /// </summary>
        /// <returns></returns>
        public static List<FriendLink> GetAllLinkList()
        {
            return FriendLinkServer.GetAllLinkList();
        }

        /// <summary>
        /// 通过uid添加新友链,uid=0为游客
        /// </summary>
        /// <param name="title"></param>
        /// <param name="href"></param>
        /// <returns></returns>
        public static bool AddNewFLink(string title,string href)
        {
            int uid;
            if (Now_User.now_user == "") uid = 0;
            else uid = Now_User.now_user_id;
            return FriendLinkServer.AddNewFLink(title,href,uid);
        }

        /// <summary>
        /// 通过lid删除友链
        /// </summary>
        /// <param name="lid"></param>
        /// <returns></returns>

        public static bool DeleteLinkById(int lid)
        {
            return FriendLinkServer.DeleteLinkById(lid);
        }
    }
}
