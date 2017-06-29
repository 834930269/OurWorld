using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public static class UserManager
    {   
        /// <summary>
        /// 注册校验 记录userid
        /// </summary>
        /// <returns></returns>
        public static int Regist(string username,string pwd,string nickname)
        {
            int userid= UserServer.User_Regist(username,pwd,nickname);
            if (userid == -1)
            {
                //用户名存在
                return -1;
            }
            else
            {
                //注册成功
                return userid;
            }
        }


        /// <summary>
        /// 登录校验 记录user信息
        /// </summary>
        /// <returns></returns>
        public static bool Login(string username,string pwd,out User qb)
        {
            User user = UserServer.GetUserByLoginId(username);
            if (user == null)
            {
                //用户名不存在
                qb = null;
                return false;
            }
            if (user.LoginPwd == pwd)
            {
                qb = user;
                return true;
            }
            else
            {
                //密码错误
                qb = null;
                return false;
            }
        }
    }
}
