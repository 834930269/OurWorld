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
    public static class FriendLinkServer
    {
        /// <summary>
        /// 获取全部友链
        /// </summary>
        /// <returns></returns>
        public static List<FriendLink> GetAllLinkList()
        {
            string sql = "SELECT * FROM FriendLink order by fltime DESC";
            return GetLinkBySql(sql);
        }

        /// <summary>
        /// 获取友链通过sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private static List<FriendLink> GetLinkBySql(string sql)
        {
            List<FriendLink> list = new List<FriendLink>();
            DataTable table = SSMS.GetDataSet(sql);
            foreach (DataRow row in table.Rows)
            {
                FriendLink friendlink = new FriendLink();

                friendlink.Lid = (int)row["lid"];
                friendlink.Ltitle = (string)row["ltitle"];
                friendlink.Lhref = (string)row["lhref"];
                friendlink.FLtime = (DateTime)row["fltime"];
                friendlink.Luid = (int)row["luid"];
                list.Add(friendlink);
            }
            return list;
        }

        /// <summary>
        /// 通过用户uid添加新友链
        /// </summary>
        /// <returns></returns>
        public static bool AddNewFLink(string title, string href,int uid)
        {
            //id=0,为游客
            string sql = "INSERT FriendLink(ltitle,lhref,fltime,luid)" +
                " VALUES('" + title + "','" + href + "','" + Now_User.GetNowTime() + "'," + uid + ")";
            sql += " ; SELECT @@IDENTITY";
            int result = SSMS.GetScalar(sql);
            if (result > 0) return true;
            else return false;
        }

        /// <summary>
        /// 通过友链id删除友链
        /// </summary>
        /// <param name="lid"></param>
        /// <returns></returns>
        public static bool DeleteLinkById(int lid)
        {
            string sql = "DELETE FriendLink WHERE lid=" + lid.ToString();
            if (SSMS.ExecuteCommand(sql) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
