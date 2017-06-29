using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
public partial class Login : System.Web.UI.Page
{
    //TextBox:1，2.登录用户名,密码
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        User user;
        if (TextBox1.Text == "" || TextBox2.Text == "")
        {
            Response.Write("<script>alert('抱歉,用户名/密码输入不能为空,请重新输入.');</script>");
        }
        else
        {
            if (UserManager.Login(TextBox1.Text, TextBox2.Text, out user))
            {
                Now_User.now_user = user.LoginId;
                Now_User.now_user_id = user.Id;
                Response.Write("<script>alert('Welcome Back Here,Dude/Girl!');window.location.href='index.aspx?uid=" + TextBox1.Text + "';</script>");
            }
            else
            {
                Response.Write("<script>alert('抱歉,用户名/密码错误,请重新输入.');</script>");
            }
            
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox3.Text == "" || TextBox4.Text == "" || TextBox5.Text == "")
        {
            Response.Write("<script>alert('抱歉,用户名/密码/昵称输入不能为空,请重新输入.');</script>");
           
        }
        else
        {
            int userid=UserManager.Regist(TextBox3.Text, TextBox4.Text, TextBox5.Text);
            if ( userid== -1)
            {
                Response.Write("<script>alert('抱歉,该用户已存在,请重新输入.');</script>");
            }
            else
            {
                Now_User.now_user = TextBox3.Text;
                Now_User.now_user_id = userid;
                Response.Write("<script>alert('Welcome To Join OurDream!');window.location.href='index.aspx?uid=" + TextBox3.Text + "';</script>");
            }
        }
    }
    //获取url参数
    public string urlaid()
    {
        string q = "";
        if (Request.QueryString["aid"] != null)//这里的aid是为了确认当前是登录还是注册,以便Page刷新的时候不会篡^_^
            q = Request.QueryString["aid"].ToString();
        return q;
    }
}