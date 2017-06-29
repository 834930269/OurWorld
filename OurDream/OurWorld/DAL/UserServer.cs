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
    public static class UserServer
    {
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <returns></returns>
        public static int User_Regist(string username,string pwd,string nickname)
        {
            if (GetUserByLoginId(username) != null)
            {   //用户存在
                return -1;
            }
            else
            {
                string sql = "INSERT Users(LoginId,LoginPwd,Name,QQ,Mail) "+
                "VALUES('"+username+"','"+pwd+"','"+nickname+"','Default','Default')";
                sql += " ; SELECT @@IDENTITY";
                int newId = SSMS.GetScalar(sql);
                if (newId != 0) return newId;
                else return -1;
            }
        }
        /// <summary>
        /// 通过id获得用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static User GetUserById(int id)
        {
            string sql = "SELECT * FROM Users WHERE Id = " + id.ToString();
            SqlDataReader reader = SSMS.GetReader(sql);
            if (reader.Read())
            {
                User user = new User();

                user.Id = (int)reader["Id"];
                user.LoginId = (string)reader["LoginId"];
                user.LoginPwd = (string)reader["LoginPwd"];
                user.Name = (string)reader["Name"];
                user.QQ = (string)reader["QQ"];
                user.Mail = (string)reader["Mail"];

                reader.Close();

                return user;
            }
            else
            {
                reader.Close();
                return null;
            }
        }
        /// <summary>
        /// 通过用户名查找用户
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public static User GetUserByLoginId(string loginId)
        {
            string sql = "SELECT * FROM Users WHERE LoginId ='"+loginId+"'";
            SqlDataReader reader = SSMS.GetReader(sql);
            if (reader.Read())
            {
                User user = new User();
                user.Id = (int)reader["Id"];
                user.LoginId = (string)reader["LoginId"];
                user.LoginPwd = (string)reader["LoginPwd"];
                user.Name = (string)reader["Name"];
                user.QQ = (string)reader["QQ"];
                user.Mail = (string)reader["Mail"];

                reader.Close();

                return user;
            }
            else
            {
                reader.Close();
                return null;
            }
        }
        
    }
}
