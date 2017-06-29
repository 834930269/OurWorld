using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;
using BLL;
public partial class BeFriendly : System.Web.UI.Page
{
    public static List<FriendLink> fl;
    protected void Page_Load(object sender, EventArgs e)
    {
            if (Now_User.now_user == "") { Label3.Text += "游客"; }
            else { Label3.Text += Now_User.now_user=="admin"?"管理员":Now_User.now_user; }
            fl = FriendLinkManager.GetAllLinkList();
            bool flag = Now_User.now_user == "admin" ? true : false;//如果当前用户是管理员账户:账号admin,密码:admin则可进行删除
            if (fl.Count > 0)
            {
                for (int i = 0; i < fl.Count; ++i)
                {
                    HyperLink hl = new HyperLink();
                    hl.NavigateUrl = string.Format(fl[i].Lhref);
                    hl.Text = (i + 1).ToString() + ": " + fl[i].Ltitle;
                    hl.Target = "_blank";
                    hl.Height = 40;
                    Master.Rows.Add(new TableRow());
                    Master.Rows[i].Cells.Add(new TableCell());
                    Master.Rows[i].Cells[0].Controls.Add(hl);
                    if (flag)
                    {
                        Button bt = new Button();
                        bt.Text = "删除该友链";
                        bt.Click += btn_Click;
                        bt.ID = i.ToString();
                        bt.CssClass = "submit";
                        Master.Rows[i].Cells.Add(new TableCell());
                        Master.Rows[i].Cells[1].Controls.Add(bt);
                    }
                    else
                    {
                        Button bt = new Button();
                        bt.Text = "只有管理员可以删除哦";
                        bt.Click += btn_Tourist_Click;
                        bt.CssClass = "submit";
                        bt.Width = 150;
                        Master.Rows[i].Cells.Add(new TableCell());
                        Master.Rows[i].Cells[1].Controls.Add(bt);
                    }
                }
            }
            else
            {
                Header.Text += "抱歉啊,本站还没有友链..要不你来加点啊?";
            }
    }

    public void btn_Tourist_Click(object sender,EventArgs e)
    {
            Response.Write("<script>alert('请登录管理员账户在执行此操作!(偷偷告诉你,管理员账户:admin,密码:admin');" +
                     "window.location.href='BeFriendly.aspx';</script>");
    }

    public void btn_Click(object sender,EventArgs e)
    {
        int delid = Convert.ToInt32((sender as Button).ID);//待删除友链在fl中的index,控件中的ID
        int lid = fl[delid].Lid;
        if (FriendLinkManager.DeleteLinkById(lid))
        {
            Response.Write("<script>alert('您好," + urluid() + ",您已删除友链成功!');" +
                        "window.location.href='BeFriendly.aspx';</script>");
        }
        else
        {
            Response.Write("<script>alert('您好," + urluid() + ",您删除友链失败.');" +
                        "window.location.href='BeFriendly.aspx';</script>");
        }
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
            Response.Write("<script>alert('您好," + urluid() + ",填写错误!');</script>");
        }
        else
        {
            if (FriendLinkManager.AddNewFLink(TextBox1.Text, TextBox2.Text))
            {
                Response.Write("<script>alert('您好," + urluid() + ",您已添加友链成功!');"+
                "window.location.href='BeFriendly.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('您好," + urluid() + ",您添加友链失败.');"+
                    "window.location.href='BeFriendly.aspx';</script>");
            }
        }
    }
}