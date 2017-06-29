using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public static class SSMS
    {
        /// <summary>
        /// 登录模块
        /// </summary>
        private static SqlConnection con;

        public static SqlConnection Con
        {
            get
            {
                string constring = ConfigurationManager.ConnectionStrings["OurBlog"].ConnectionString;
                if (con == null)
                {
                    con = new SqlConnection(constring);
                    con.Open();
                }
                else if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                else if (con.State == ConnectionState.Broken)
                {
                    con.Close();
                    con.Open();
                }
                return con;

            }
        }

        /// <summary>
        /// 根据sql语句获得sqldatareader
        /// </summary>

        public static SqlDataReader GetReader(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, Con);
            //cmd.Parameters.AddRange(values);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        public static DataTable GetDataSet(string safeSql)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(safeSql, Con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            
            return ds.Tables[0];
        }
        /// <summary>
        /// 返回执行结果中的第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int GetScalar(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, Con);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }

        /// <summary>
        /// 返回受影响的行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static int ExecuteCommand(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, Con);
            int result = cmd.ExecuteNonQuery();
            return result;
        }
    }
}
