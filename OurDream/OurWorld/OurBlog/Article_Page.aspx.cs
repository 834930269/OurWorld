using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
public partial class Article_Page : System.Web.UI.Page
{
    public static List<comments> cm;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //显示文章
            Article art = new Article();
            string aids = Request.QueryString["aid"].ToString();
            int aid = Convert.ToInt32(aids);//文章id
            art = ArticleManager.GetArticleById(aid);
            Title.Text = art.NTitle;
            Author.Text = "作者: " + art.Author.Name + " 发表时间: " + art.NDate;
            Content.Text = art.NContent;

            //显示评论
            cm = new List<comments>();
            cm = CommentsManager.GetCommentByAid(aid);
        }
    }
    //评论
    public void ShowComment()
    {
        foreach(comments com in cm){
            Response.Write("<script type='text/javascript'>sendData(\""+com.Huifu+"\");</script>");
        }
    }
    public static string get_now_user()
    {
        return Now_User.now_user;
    }
    public string urluid()
    {
        if (Now_User.now_user == "") return "游客";
        if (Now_User.now_user == "admin") return "管理员";
        return Now_User.now_user;
    }
    //评论
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "" || TextBox2.Text == "")
        {
            Response.Write("<script>alert('标题/内容不能为空,请重新输入.');</script>");
        }
        else
        {
            if (CommentsManager.SetCommentByAid(TextBox1.Text, TextBox2.Text,Convert.ToInt32(Request.QueryString["aid"])))
            {
                string Now_User_Name=Now_User.now_user==""?"游客":Now_User.now_user;
                Response.Write("<script>alert('您好," + Now_User_Name + ",您已评论成功!');window.location.href='Article_Page.aspx?aid=" + Request.QueryString["aid"].ToString() + "'</script>");
            }
            else
            {
                Response.Write("<script>alert('评论失败.');</script>");
            }
        }
    }
}