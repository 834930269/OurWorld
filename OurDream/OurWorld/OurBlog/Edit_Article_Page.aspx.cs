using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
public partial class Edit_Article_Page : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public string urluid()
    {
        if (Now_User.now_user == "") return "游客";
        if (Now_User.now_user == "admin") return "管理员";
        return Now_User.now_user;
    }
    public static string get_now_user()
    {
        return Now_User.now_user;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "" || TextBox2.Text == "")
        {
            Response.Write("<script>alert('标题和正文不能为空,请重新输入啊亲.');</script>");
        }
        else
        {
            if (ArticleManager.PublishNowPost(TextBox1.Text, TextBox2.Text, TextBox3.Text))
            {
                Response.Write("<script>alert('Color:Green--->Accept!(发表成功');window.location.href='index.aspx?uid=" + Now_User.now_user + "';</script>");
            }
            else
            {
                Response.Write("<script>alert('抱歉,输入超限,请重新输入.');</script>");
            }
        }    
    }
}