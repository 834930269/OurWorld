using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Model;
using BLL;
public partial class Comments_Control : System.Web.UI.Page
{
    public static List<comments> sigma;

    protected void GetAll()
    {
        sigma = CommentsManager.GetCommentByUid(Now_User.now_user_id);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Now_User.now_user == "")
            {
                Response.Write("<script>alert('抱歉,你当前用户组是游客,请登录或注册后重试.');window.location.href='index.aspx?uid=';</script>");
            }
            else
            {
                GetAll();
                if (sigma.Count == 0)
                {
                    Label1.Text = "你还没有写评论呢,快去写几篇吧.";
                }
                else
                {
                    for (int i = 0; i < sigma.Count; ++i)
                    {
                        ListItem Item = new ListItem(sigma[i].Title,i.ToString());
                        DropDownList1.Items.Add(Item);
                    }
                    int ind = DropDownList1.SelectedIndex;
                    TextBox1.Text = sigma[ind].Title;
                    TextBox2.Text = sigma[ind].Huifu;
                    Label4.Text = "来源文章: " + sigma[ind].Article.NTitle;
                }
            }
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
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int ind = DropDownList1.SelectedIndex;
        TextBox1.Text = sigma[ind].Title;
        TextBox2.Text = sigma[ind].Huifu;
        Label4.Text = "来源文章: " + sigma[ind].Article.NTitle;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (sigma.Count == 0)
        {
            Response.Write("<script>alert('请去评论..');</script>");
            return;
        }
        int Cid = sigma[DropDownList1.SelectedIndex].CId;//待删除评论Cid
        if (CommentsManager.DelCommentByCid(Cid))
        {
            Response.Write("<script>alert('删除成功.');window.location.href='Comments_Control.aspx';</script>");
        }
        else
        {
            //删除失败
            Response.Write("<script>alert('删除失败..');</script>");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (DropDownList1.Items.Count > 0)//你没有评论过干嘛点修改评论
        {
            int cid = sigma[DropDownList1.SelectedIndex].CId;//待修改评论id
            if (CommentsManager.UpdateCommentByCid(TextBox1.Text, TextBox2.Text, cid))
            {
                //修改成功
                Response.Write("<script>alert('修改成功.');window.location.href='Comments_Control.aspx';</script>");
            }
            else
            {
                //修改失败
                Response.Write("<script>alert('修改失败.');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('你还没有评论过呢,快去写几篇吧老师.');</script>");
        }
    }
}